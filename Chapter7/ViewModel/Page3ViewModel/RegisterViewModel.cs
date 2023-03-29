
using Chapter7.Database.Page3Database;
using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter7.ViewModel.Page3ViewModel.ViewModelRegister
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private RegisterDetails _registerDetails;
        private string _userName;
        private string _password;
        private string _confirmPassword;
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
            get=> _password;
            set
            {
                _password = value; 
                OnPropertyChanged();
            }
        } 
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }
        public bool IsEnable
        {
            get => _isEnable;
            set
            {
                _isEnable=value;
                OnPropertyChanged();
            }
        }
      
      
        public ICommand RegisterCommand { get;private set; }
       
        public event EventHandler RegisterEvent;
     
        public RegisterViewModel()
        {
            _registerDetails = new RegisterDetails();
            RegisterCommand = new Command(Validation);         
        }

        public void EnableButton()
        {
            if( !string.IsNullOrWhiteSpace(UserName) &&
                !string.IsNullOrWhiteSpace(Password) &&
                !string.IsNullOrWhiteSpace(ConfirmPassword)) 
            {
                IsEnable = true;
            }
            else
            {
                IsEnable = false;
            }
        }
        public void Validation()
        {
            if(string.IsNullOrWhiteSpace(UserName) && 
               string.IsNullOrWhiteSpace(Password) &&
               string.IsNullOrWhiteSpace(ConfirmPassword)
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
            else if (Password.Length<8)
            {
                Toast.Make("Password lenght is small!", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                Toast.Make("Please Enter ConfirmPassword", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else if (!Password.Equals(ConfirmPassword))
            {
                Toast.Make("Password and Confirm password not match", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            }
            else
            {
                DatabaseConnection();
                RegisterEvent?.Invoke(this, new EventArgs());
            }
        }


        public void DatabaseConnection()
        {
            _registerDetails.UserName = UserName;
            _registerDetails.Password = Password;
            _registerDetails.CreateDatabase();
            _ = _registerDetails.CreateTableAsync();
            _ = _registerDetails.InsertAsync();
            _ = _registerDetails.QueryAsync();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
