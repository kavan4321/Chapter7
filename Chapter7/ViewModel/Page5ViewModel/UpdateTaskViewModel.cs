
using Chapter7.Database.Page5Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter7.ViewModel.Page5ViewModel.ViewModel.UpdateTask
{
    public class UpdateTaskViewModel:INotifyPropertyChanged
    {
        private TaskManagerDatabase _database;

        private string _taskName;
        private string _description;
        private DateTime _completionTime;
        private DateTime _startTime;
        private DateTime _endTime;

        public int Id { get; set; }
        public string TaskName
        {
            get => _taskName;
            set
            {
                _taskName = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public DateTime CompletionTime
        {
            get => _completionTime;
            set
            {
                _completionTime = value;
                OnPropertyChanged();
            }
        }
        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                OnPropertyChanged();
            }
        }
        public DateTime EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                OnPropertyChanged();
            }
        }


        public event EventHandler<bool> UpdateEvent;
        public ICommand UpdateCommand { get;private set; }
        public UpdateTaskViewModel()
        {
            _database= new TaskManagerDatabase();
            _database.CreateDatabase();
            _=_database.CreateTableAsync();
            UpdateCommand = new Command(() => { _ = UpdateAsync(); });
        }

        public async Task GetDataFromDatabase()
        {
            _database.Id = Id;
            await _database.GetDataAsync();
            TaskName = _database.TaskName;
            Description = _database.Description;
            CompletionTime = _database.CompletionDate;
            StartTime=_database.StartTime;
            EndTime=_database.EndTime;

        }

        public async Task UpdateAsync()
        {
            _database.Id= Id;
            _database.TaskName = TaskName;
            _database.Description = Description;
            _database.CompletionDate = CompletionTime;
            _database.StartTime= StartTime;
            _database.EndTime= EndTime;
            var result = await _database.UpdateAsync();
            UpdateEvent?.Invoke(this,result);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
