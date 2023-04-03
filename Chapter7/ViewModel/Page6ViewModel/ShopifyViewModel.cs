
using Chapter7.Database.Page6Database;
using Chapter7.HttpModel;
using Chapter7.Model;
using Chapter7.Result;
using Chapter7.Tables.Page6Table;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter7.ViewModel.Page6ViewModel.ViewModelShopify
{
    public class ShopifyViewModel:INotifyPropertyChanged
    {
        private GetShopifyModel _getShopifyModel;
        private ShopifyDatabase _shopifyDatabase;

        private List<ProductDetail> _shopifyDetails;
        public List<ProductDetail> ShopifyDetails
        {
            get => _shopifyDetails;
            set
            {
                _shopifyDetails= value;
                OnPropertyChanged();
            }
        }

        private List<ShopifyTable> _shopifyTable;
        public List<ShopifyTable> ShopifyTable
        {
            get => _shopifyTable;
            set
            {
                _shopifyTable = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;
        private bool _isEnable;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading=value;
                OnPropertyChanged();
            }
        }
        public bool IsEnable
        {
            get => _isEnable;
            set
            {
                _isEnable = value;
                OnPropertyChanged();
            }
        }


        public event EventHandler<GetShopifyResult> GetShopifyEvent;
        public event EventHandler<bool> AddDataEvent;
     
        public ShopifyViewModel()
        {
            _getShopifyModel=new GetShopifyModel();
            _shopifyDatabase = new ShopifyDatabase();
            _shopifyDatabase.CreateDatabase();
            _ = _shopifyDatabase.CreateTableAsync();
            _ = _shopifyDatabase.GetShopifyListAsync();
            _ = InsertAsync();        
        }



        public async Task GetShopifyListApiAsync()
        {
            var result = await _getShopifyModel.GetShopifyDetailsAsync();
            ShopifyDetails = _getShopifyModel.ShopifiyDetails;
            GetShopifyEvent?.Invoke(this, result);
        } 

        public async Task GetShopifyListDatabaseAsync()
        {
            if (ShopifyDetails.Count == 0)
            {
                _= GetShopifyListApiAsync();
            }
            else
            {
                await _shopifyDatabase.GetShopifyListAsync();
                ShopifyTable = _shopifyDatabase.ShopifyList;
            }
        }

        public async Task InsertAsync()
        {
            foreach(var item in ShopifyDetails)
            {
                _shopifyDatabase.Id=item.Id;
                _shopifyDatabase.Title = item.Title;
                _shopifyDatabase.Price = item.Price;
                _shopifyDatabase.Stock = item.Stock;
                _shopifyDatabase.Brand =item.Brand;
                _shopifyDatabase.Thumbnail = item.Thumbnail;
                var result = await _shopifyDatabase.InsertAsync();
                AddDataEvent?.Invoke(this, result);
            }
           _=GetShopifyListDatabaseAsync();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
