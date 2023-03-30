using Chapter7.Result;
using Chapter7.Tables.Page3Table;
using SQLite;
namespace Chapter7.Database.Page3Database
{
    public class RegisterDetails
    {
        private SQLiteAsyncConnection _connection;
      
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public int Id { get;set; }
        public string DashBoardName { get; set; }

        public void CreateDatabase()
        {         
            var databaseName = "RegisterDetails";
            var folderPath= Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath= Path.Combine(folderPath, databaseName);
            _connection = new SQLiteAsyncConnection(databasePath,true);
        }

        public async Task CreateTableAsync()
        {
            await _connection.CreateTableAsync<RegisterTable>();
        }

        public async Task<List<RegisterTable>> GetRegisterListAsync()
        {
            var list= await _connection.Table<RegisterTable>().ToListAsync();
            return list;
        }

      
        public async Task<bool> InsertAsync()
        {
            var table = new RegisterTable()
            {

                UserName=UserName,
                Password= Password
            };

            try
            {
                var insertData = await _connection.InsertAsync(table);
                var result = insertData > 0;
                _ = GetRegisterListAsync();
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;        
        }

        public async Task<RegisterResult> GetUserDetails()
        {
            try
            {
                var list = await _connection.Table<RegisterTable>().ToListAsync();
                var userlist = list.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
                if (userlist == null)
                {
                    return new RegisterResult()
                    {
                        IsSuccess = false,
                    };

                }
                else
                {
                    return new RegisterResult()
                    {
                        IsSuccess = true,
                        Id = userlist.Id
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task DashBoardDetail()
        {
            try
            {
                var list = await _connection.Table<RegisterTable>().ToListAsync();
                var userDetail = list.Where(x => x.Id == Id).FirstOrDefault();
                DashBoardName = userDetail.UserName;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
