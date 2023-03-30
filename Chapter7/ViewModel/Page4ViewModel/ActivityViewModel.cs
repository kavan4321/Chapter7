using Chapter7.Database.Page4Database;
using Chapter7.Result;
using Chapter7.Tables.Page4Table;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter7.ViewModel.Page4ViewModel.ViewModelActivity
{
    public class ActivityViewModel:INotifyPropertyChanged
    {
        private ActivityDatabase _activityDatabase;

        private ObservableCollection<ActivityTable> _activityDatails;
        public ObservableCollection<ActivityTable> ActivityDatails
        {
            get => _activityDatails;
            set
            {
                _activityDatails = value;
                OnPropertyChanged();
            }
        }


        public event EventHandler<ActivityResult> UpdateEvent;
        public ICommand UpdateCommand { get;private set; }
     
        public ActivityViewModel()
        {
            _activityDatabase= new ActivityDatabase();
            _activityDatabase.CreateDatebase();
            _=_activityDatabase.CreateTableAsync();
            _ = GetListAsync();
            UpdateCommand = new Command<ActivityTable>((ActivityTable) => { _ = UpdateDetail(ActivityTable); } );
        }

        public async Task UpdateDetail(ActivityTable activityTable)
        {
            _activityDatabase.Id=activityTable.Id;
            var result =await  _activityDatabase.GetUserData();
            UpdateEvent?.Invoke(this,result);
        }
        public async Task GetListAsync()
        {
            await _activityDatabase.GetActivityListAsync();
           ActivityDatails = _activityDatabase.ActivityList.ToObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
