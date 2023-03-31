using Chapter7.Database.Page5Database;
using Chapter7.ViewModel.Page5ViewModel.ViewModelTask;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter7.ViewModel.Page5ViewModel.ViewModelNewTask
{
    public class NewTaskViewModel:INotifyPropertyChanged
    {
        private TaskManagerDatabase _taskManagerDatabase;

        private string _taskName;
        private string _description;
        private DateTime _completionTime=DateTime.Now;
        private DateTime _startTime;
        private DateTime _endTime;

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
                _completionTime= value;
                OnPropertyChanged();
            }
        }   
        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                _startTime=value;
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

        public event EventHandler<bool> AddTaskEvent;
        public ICommand AddCommand { get;private set; }

        public NewTaskViewModel()
        {
            _taskManagerDatabase = new TaskManagerDatabase();
            _taskManagerDatabase.CreateDatabase();
            _=_taskManagerDatabase.CreateTableAsync();
            _=_taskManagerDatabase.GetTaskListAsync();
            AddCommand = new Command(Validation);
        }

        public void Validation()
        {
            if(string.IsNullOrWhiteSpace(TaskName) &&
                string.IsNullOrWhiteSpace(Description)
                )
            {
                Toast.Make("Please Enter Values", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(TaskName))
            {
                Toast.Make("Please Enter Task Name", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Description))
            {
                Toast.Make("Please Enter Description", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                InsertAsync();
            }
        }


        public async void InsertAsync()
        {
            _taskManagerDatabase.TaskName = TaskName;
            _taskManagerDatabase.Description= Description;
            _taskManagerDatabase.CompletionDate= CompletionTime;
            _taskManagerDatabase.StartTime= StartTime;
            _taskManagerDatabase.EndTime= EndTime;  
            var result= await _taskManagerDatabase.InsertAsync();
            AddTaskEvent?.Invoke(this,result);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
