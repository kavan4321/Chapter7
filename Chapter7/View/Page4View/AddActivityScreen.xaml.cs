using Chapter7.ViewModel.Page4ViewModel.ViewModelAddActivity;
using CommunityToolkit.Maui.Alerts;

namespace Chapter7.View.Page4View;

public partial class AddActivityScreen : ContentPage
{
	private AddActivityViewModel _viewModel;
	public AddActivityScreen()
	{
		InitializeComponent();
		_viewModel=(AddActivityViewModel)BindingContext;
        _viewModel.AddActivityEvent += AddActivityEvent;
	}

    private async void AddActivityEvent(object sender, bool e)
    {
		if (e)
		{
			_=Toast.Make("Activity Added Successfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
			await Navigation.PushAsync(new ActivitysScreen());
		}
		else
		{
			_ = Toast.Make("Somthing went wrong", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}