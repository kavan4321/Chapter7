
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter7.ViewModel.Page6ViewModel.ViewModelShopify
{
    public class ShopifyViewModel:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
