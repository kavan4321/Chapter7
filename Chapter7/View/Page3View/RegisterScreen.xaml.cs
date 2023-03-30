using Chapter7.ViewModel.Page3ViewModel.ViewModelRegister;
using CommunityToolkit.Maui.Alerts;

namespace Chapter7.View.Page3View;

public partial class RegisterScreen : ContentPage
{
	private RegisterViewModel _viewModel;
	public RegisterScreen()
	{
		InitializeComponent();
		_viewModel = (RegisterViewModel)BindingContext;
        _viewModel.RegisterEvent += ViewModelRegisterEvent;
        _viewModel.EnableButton();
	}

    private async void ViewModelRegisterEvent(object sender, bool e)
    {
        if (e)
        {
            await Navigation.PushAsync(new LoginScreen());
            await Toast.Make("Registered Successfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            await Toast.Make("Somthing went wrong", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

    private async void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new LoginScreen());
    }

    private void EntryTextChanged(object sender, TextChangedEventArgs e)
    {
        _viewModel.EnableButton();
    }
}