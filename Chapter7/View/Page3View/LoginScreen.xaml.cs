using Chapter7.ViewModel.Page3ViewModel.ViewModelLogin;
using CommunityToolkit.Maui.Alerts;

namespace Chapter7.View.Page3View;

public partial class LoginScreen : ContentPage
{
	private LoginViewModel _viewModel;
	public LoginScreen()
	{
		InitializeComponent();
		_viewModel = (LoginViewModel)BindingContext;
        _viewModel.LoginEvent += ViewModelLoginEvent;
        _viewModel.ButtonEnable();
    }

    private async void ViewModelLoginEvent(object sender, Result.RegisterResult e)
    {
        if (e.IsSuccess)
        {
            await Navigation.PushAsync(new DashboardScreen(e.Id));
            _ = Toast.Make("Login successfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();          
        }
        else
        {
            _ = Toast.Make("No User Found!!!", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }


    private async void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		await Navigation.PopAsync();
    }

    private void EntryTextChanged(object sender, TextChangedEventArgs e)
    {
        _viewModel.ButtonEnable();
    }
}