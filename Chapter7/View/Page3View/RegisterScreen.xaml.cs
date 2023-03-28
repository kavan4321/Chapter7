using Chapter7.ViewModel.Page3ViewModel.ViewModelRegister;

namespace Chapter7.View.Page3View;

public partial class RegisterScreen : ContentPage
{
	private RegisterViewModel _viewModel;
	public RegisterScreen()
	{
		InitializeComponent();
		_viewModel = (RegisterViewModel)BindingContext;
        _viewModel.RegisterEvent += ViewModelRegisterEvent;
	}

    private async void ViewModelRegisterEvent(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DashboardScreen());
    }

    private async void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new LoginScreen());
    }
}