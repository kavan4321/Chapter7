using Chapter7.Tables.Page4Table;
using Chapter7.ViewModel.Page4ViewModel.ViewModelActivity;
using CommunityToolkit.Maui.Alerts;

namespace Chapter7.View.Page4View;

public partial class ActivitysScreen : ContentPage
{
	private ActivityViewModel _viewmodel;
	public ActivitysScreen()
	{
		InitializeComponent();
		_viewmodel=(ActivityViewModel)BindingContext;
		_=_viewmodel.GetListAsync();
        _viewmodel.UpdateEvent += UpdateEventAsync;
        _viewmodel.DeleteEvent += DeleteEvent; ;
	}

    private void DeleteEvent(object sender, bool e)
    {
        if (e)
        {
            Toast.Make("Activity Delete Successfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            Toast.Make("Somthing went wrong", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }


    private async void UpdateEventAsync(object sender, Result.ActivityResult e)
    {
        if (e.IsSuccess)
        {
            await Navigation.PushAsync(new EditActivityScreen(e.Id));
        }
    }


    private async void AddButtonClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddActivityScreen());
    }
}