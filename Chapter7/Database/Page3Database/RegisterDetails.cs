using Chapter7.Tables.Page3Table;
using SQLite;

namespace Chapter7.Database.Page3Database
{
    public class RegisterDetails
    {
        private SQLiteAsyncConnection _connection;
      
        public int Id { get;set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void CreateDatabase()
        {
            if (_connection == null)
                return;            
            var databaseName = "RegisterDetails";
            var folderPath= Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath= Path.Combine(folderPath, databaseName);
            _connection = new SQLiteAsyncConnection(databasePath,true);
        }

        public async Task CreateTableAsync()
        {
            await _connection.CreateTableAsync<RegisterTable>();
        }


        public async Task<bool> InsertAsync()
        {
            var table = new RegisterTable()
            {
                Id = Id,
                UserName=UserName,
                Password= Password
            };

            return await _connection.InsertAsync(table) > 0;            
        }

        public async Task<List<RegisterDetails>> QueryAsync()
        {
            return await _connection.QueryAsync<RegisterDetails>("select * from RegisterDetails where Id>0");
        }
    }
}
