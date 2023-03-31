
using Chapter7.Database.Page4Database;
using CommunityToolkit.Maui.Alerts;
using SQLitePCL;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter7.ViewModel.Page4ViewModel.ViewModelAddActivity
{
    public class AddActivityViewModel:INotifyPropertyChanged
    {
        private ActivityDatabase _activityDatabase;       

        private string _name;
        private DateTime _dueDate = DateTime.Now;
        private bool _isComplete;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
                OnPropertyChanged();
            }
        }
        public bool IsComplete
        {
            get => _isComplete;
            set
            {
                _isComplete = value;
                OnPropertyChanged();
            }
        }


        public event EventHandler<bool> AddActivityEvent;
        public ICommand AddCommand { get; private set; }
      
        public AddActivityViewModel()
        {
            _activityDatabase=new ActivityDatabase();
            _activityDatabase.CreateDatebase();
            _ = _activityDatabase.CreateTableAsync();
            _ = _activityDatabase.GetActivityListAsync();
            AddCommand = new Command(Validation);
        }

        public void Validation()
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                Toast.Make("Please Enter Activity Name", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                AddValueToDatabase();
            }
        }

        public async void AddValueToDatabase()
        {
            _activityDatabase.Name=Name;
            _activityDatabase.DueDate = DueDate;
            _activityDatabase.IsComplete=IsComplete;
            var result =await _activityDatabase.InsertAsync();
            AddActivityEvent?.Invoke(this, result);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
