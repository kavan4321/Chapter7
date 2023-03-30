using Chapter7.Database.Page3Database;
using Chapter7.Result;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter7.ViewModel.Page3ViewModel.ViewModelLogin
{
    public class LoginViewModel:INotifyPropertyChanged
    {
        private RegisterDetails _registerDetails;
        private string _userName;
        private string _password;
        private bool _isEnable;
     
        
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public bool IsEnable
        {
            get => _isEnable;
            set
            {
                _isEnable = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; private set; }
        
        public event EventHandler<RegisterResult> LoginEvent;
        public LoginViewModel()
        {
            _registerDetails = new RegisterDetails();
            _registerDetails.CreateDatabase();
            _=_registerDetails.CreateTableAsync();
            LoginCommand = new Command(Validation);
        }


        public void ButtonEnable()
        {
            if( !string.IsNullOrWhiteSpace(UserName) &&
                !string.IsNullOrWhiteSpace(Password))
            {
                IsEnable = true;
            }
            else
            {
                IsEnable= false;
            }
        }
       
        public void Validation()
        {
            if (string.IsNullOrWhiteSpace(UserName) &&
               string.IsNullOrWhiteSpace(Password)
               )
            {
                Toast.Make("Please Enter Value", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(UserName))
            {
                Toast.Make("Please Enter Username", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(Password))
            {
                Toast.Make("Please Enter Password", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (Password.Length < 8)
            {
                Toast.Make("Password lenght is small!", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }          
            else
            {
                Database();
            }
        }


        public async void Database()
        {
            _registerDetails.UserName = UserName;
            _registerDetails.Password = Password;
            var  result =await  _registerDetails.GetUserDetails();
            LoginEvent?.Invoke(this,result);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
