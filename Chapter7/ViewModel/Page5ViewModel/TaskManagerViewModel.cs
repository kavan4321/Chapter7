using Chapter7.Database.Page5Database;
using Chapter7.Result;
using Chapter7.Tables.Page5Table;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter7.ViewModel.Page5ViewModel.ViewModelTask
{
    public class TaskManagerViewModel:INotifyPropertyChanged
    {
        private TaskManagerDatabase _database;

        private ObservableCollection<TaskManagerTable> _taskList;
        public ObservableCollection<TaskManagerTable> TaskList
        {
            get => _taskList;
            set
            {
                _taskList= value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;
        private bool _isShow;
        private bool _isRefresh;
      
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
        public bool IsShow
        {
            get => _isShow;
            set
            {
                _isShow = value;
                OnPropertyChanged();
            }
        }
        public bool IsRefresh
        {
            get => _isRefresh;
            set
            {
                _isRefresh = value;
                OnPropertyChanged();
            }
        }

        public event EventHandler<TaskResult> EditEvent;     
        public event EventHandler<bool> DeleteEvent;
     
        public ICommand EditCommand { get;private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        
        public TaskManagerViewModel()
        {           
            _database= new TaskManagerDatabase();
            IsLoading = true;
            IsShow = false;
            _database.CreateDatabase();
            _=_database.CreateTableAsync();
            _ = GetListAsync();
            EditCommand = new Command<TaskManagerTable>((TaskManagerTable) => { _ = PushDataToUpdateAsync(TaskManagerTable); });
            DeleteCommand = new Command<TaskManagerTable>((TaskManagerTable) => { _ = DeleteAsync(TaskManagerTable); });
            RefreshCommand = new Command(()=> { _ = RefreshDetails(); });
        }


        public async Task RefreshDetails()
        {
            IsRefresh = true;
            await GetListAsync();
        }
        public async Task GetListAsync()
        {
            IsLoading = true;
            IsShow = false;
            await _database.GetTaskListAsync();
            TaskList = _database.TaskList.ToObservableCollection();
            IsLoading = false;
            IsShow = true;
            IsRefresh = false;
        }

        public async Task PushDataToUpdateAsync(TaskManagerTable taskManagerTable)
        {
            _database.Id = taskManagerTable.Id;
            var result=await _database.GetDataAsync();
            EditEvent?.Invoke(this, result);
        }

        public async Task DeleteAsync(TaskManagerTable taskManagerTable)
        {
            _database.Id = taskManagerTable.Id;
            var result = await _database.DeleteAsync();
            _ = GetListAsync();
            DeleteEvent?.Invoke(this, result);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
