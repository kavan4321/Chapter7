using Chapter7.Result;
using Chapter7.Tables.Page5Table;
using SQLite;
namespace Chapter7.Database.Page5Database
{
    public class TaskManagerDatabase
    {
        private SQLiteAsyncConnection _connection;

        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
       
        public List<TaskManagerTable> TaskList {  get; set; }   
     
        
        public void CreateDatabase()
        {
            var databaseName = "TaskManagerDatabase";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var databasePath=Path.Combine(folderPath, databaseName);
            _connection= new SQLiteAsyncConnection(databasePath,true);
        }


        public async Task CreateTableAsync()
        {
            await _connection.CreateTableAsync<TaskManagerTable>();
        }

        public async Task<List<TaskManagerTable>> GetTaskListAsync()
        {
            var list=await _connection.Table<TaskManagerTable>().ToListAsync();
            TaskList = list;
            return list;
        }

    
        
        public async Task<bool> InsertAsync()
        {

            var table = new TaskManagerTable()
            {
                TaskName=TaskName,
                Description=Description,
                CompletionDate=CompletionDate,
                StartTime=StartTime,
                EndTime=EndTime,
            };

            try
            {
                var insertData = await _connection.InsertAsync(table);
                var result = insertData > 0;
                _ = GetTaskListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }


        public async Task<TaskResult> GetDataAsync()
        {
            try
            {
                var list = await _connection.Table<TaskManagerTable>().ToListAsync();
                var userList = list.Where(x => x.Id == Id).FirstOrDefault();
                TaskName = userList.TaskName;
                Description = userList.Description;
                CompletionDate = userList.CompletionDate;
                StartTime = userList.StartTime;
                EndTime = userList.EndTime;
                if (userList == null)
                {
                    return new TaskResult()
                    {
                        IsSuccess = false
                    };
                }
                else
                {
                    return new TaskResult()
                    {
                        IsSuccess = true,
                        Id = Id
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
            var table = new TaskManagerTable()
            {
                Id= Id,
                TaskName=TaskName,
                Description=Description,
                CompletionDate=CompletionDate,
                StartTime=StartTime, 
                EndTime=EndTime,
            };
            try
            {
                var updateList=await _connection.UpdateAsync(table);
                var result = updateList > 0;
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
            var table = new TaskManagerTable()
            {
                Id = Id,
            };
            try
            {
                var deleteDetail = await _connection.DeleteAsync(table);
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
