
using Chapter7.Database.Page4Database;
using Chapter7.Tables.Page4Table;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter7.ViewModel.Page4ViewModel.ViewModelUpdate
{
    public class EditActivityViewModel:INotifyPropertyChanged
    {
        private ActivityDatabase _activityDatabase;


        private string _name;
        private DateTime _dueDate;
        private bool _isComplete;

        public int Id { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                _name= value;
                OnPropertyChanged();
            }
        }
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate= value;
                OnPropertyChanged();
            }
        }
        public bool IsComplete
        {
            get=>_isComplete;
            set
            {
                _isComplete= value;
                OnPropertyChanged();
            }
        }

     
        public event EventHandler<bool> UpdateEvent;
        public ICommand UpdateCommand { get; private set; }
      
        
        public EditActivityViewModel()
        {
            _activityDatabase = new ActivityDatabase();
            _activityDatabase.CreateDatebase();
            _ = _activityDatabase.CreateTableAsync();
           // UpdateCommand = new Command(() => { _ = GetData(); });
        }
       
        
        public async Task GetData()
        {
            _activityDatabase.Id = Id;
            await _activityDatabase.GetUserData();
            Name = _activityDatabase.Name;
            IsComplete = _activityDatabase.IsComplete;
            DueDate= _activityDatabase.DueDate;
        }

     
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
