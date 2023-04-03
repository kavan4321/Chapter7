
using Chapter7.HttpModel;
using Chapter7.Tables.Page6Table;
using SQLite;

namespace Chapter7.Database.Page6Database
{
    public class ShopifyDatabase
    {
        private SQLiteAsyncConnection _connection;
      
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Thumbnail { get; set; }

        public List<ShopifyTable> ShopifyList { get; set; }

        public void CreateDatabase()
        {
            var databaseName = "ShopifyDatabase";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath = Path.Combine(folderPath, databaseName);
            _connection = new SQLiteAsyncConnection(databasePath, true);
        }

        public async Task CreateTableAsync()
        {
            await _connection.CreateTableAsync<ShopifyTable>();
        }

        public async Task<List<ShopifyTable>> GetShopifyListAsync()
        {
            var list = await _connection.Table<ShopifyTable>().ToListAsync();
            ShopifyList = list;
            return list;
        }

        public async Task<bool> InsertAsync()
        {
            var table = new ShopifyTable()
            {
                Id = Id,
                Title = Title,
                Price = Price,
                Stock = Stock,  
                Brand = Brand,
                Thumbnail = Thumbnail,
            };
            try
            {
                var insertData = await _connection.InsertAsync(table);
                var result = insertData > 0;
                _ = GetShopifyListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}
