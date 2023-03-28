using Chapter7.ViewModel.Page3ViewModel.ViewModelLogin;

namespace Chapter7.View.Page3View;

public partial class LoginScreen : ContentPage
{
	private LoginViewModel _viewModel;
	public LoginScreen()
	{
		InitializeComponent();
		_viewModel = (LoginViewModel)BindingContext;
        _viewModel.LoginEvent += ViewModelLoginEvent;
	}

    private async void ViewModelLoginEvent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DashboardScreen());
    }

    private async void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		await Navigation.PopAsync();
    }
}