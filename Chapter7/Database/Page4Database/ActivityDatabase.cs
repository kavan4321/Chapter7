
using Chapter7.Result;
using Chapter7.Tables.Page4Table;
using SQLite;

namespace Chapter7.Database.Page4Database
{
    public class ActivityDatabase
    {
        private SQLiteAsyncConnection _connection;

        public int Id { get; set; }
        public string Name { get; set; }    
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public List<ActivityTable> ActivityList { get; set; }
      
        public void CreateDatebase()
        {
            var databaseName = "ActivityDetails";
            var folderPath=Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath=Path.Combine(folderPath, databaseName);
            _connection=new SQLiteAsyncConnection(databasePath, true);
        }

        public async Task CreateTableAsync()
        {
            await _connection.CreateTableAsync<ActivityTable>();
        }

      
        public async Task<List<ActivityTable>> GetActivityListAsync()
        {
            var list = await _connection.Table<ActivityTable>().ToListAsync();
            ActivityList = list;
            return list;
        }

        public async Task<bool> InsertAsync()
        {
            var table = new ActivityTable()
            {
                ActivityName=Name,
                DueDate=DueDate,
                IsComplete=IsComplete,
            };
            try
            {
                var insertDate = await _connection.InsertAsync(table);
                var result = insertDate > 0;
                _ = GetActivityListAsync();
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }


        public async Task<ActivityResult> GetUserData()
        {
            try
            {
                var list = await _connection.Table<ActivityTable>().ToListAsync();
                var userList = list.Where(x => x.Id == Id).FirstOrDefault();
                Name = userList.ActivityName;
                DueDate=userList.DueDate;
                IsComplete=userList.IsComplete;
                if (userList == null)
                {
                    return new ActivityResult()
                    {
                        IsSuccess = false
                    };                 
                }
                else
                {
                    return new ActivityResult()
                    {
                        IsSuccess = true,
                        Id=Id
                    };
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }  
        

        public async Task<bool> UpdateAsync()
        {
            var table = new ActivityTable()
            {
                Id= Id,
                ActivityName = Name,
                IsComplete= IsComplete,
                DueDate = DueDate,
            };

            try
            {
                var updateDetail = await _connection.UpdateAsync(table);
                var result = updateDetail > 0;
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }


        public async Task<bool> DeleteAsync()
        {
            var table = new ActivityTable()
            {
                Id = Id
            };
            try
            {
                var deleteDetail =await _connection.DeleteAsync(table);
                var result = deleteDetail > 0;
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
