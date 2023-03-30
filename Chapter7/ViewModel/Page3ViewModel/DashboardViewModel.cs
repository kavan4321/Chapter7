
using Chapter7.Database.Page3Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter7.ViewModel.Page3ViewModel.ViewModelDashBoard
{
    public class DashboardViewModel:INotifyPropertyChanged
    {

        private RegisterDetails _registerDetails;

        private int _id;
        private string _userName;

        public int Id
        {
            get => _id;
            set
            {
                _id=value;
                OnPropertyChanged();
            }
        }
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public DashboardViewModel()
        {
            _registerDetails = new RegisterDetails();
            _registerDetails.CreateDatabase();
            _=_registerDetails.CreateTableAsync();
        }
        public async Task GetUserDetails()
        {
            _registerDetails.Id = Id;
            await _registerDetails.DashBoardDetail();
            UserName = _registerDetails.DashBoardName;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
