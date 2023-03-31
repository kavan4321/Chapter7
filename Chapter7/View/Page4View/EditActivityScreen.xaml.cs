using Chapter7.Tables.Page4Table;
using Chapter7.ViewModel.Page4ViewModel.ViewModelUpdate;
using CommunityToolkit.Maui.Alerts;

namespace Chapter7.View.Page4View;

public partial class EditActivityScreen : ContentPage
{
	private EditActivityViewModel _viewModel;
	public EditActivityScreen(int Id)
	{
		InitializeComponent();
		_viewModel=(EditActivityViewModel)BindingContext;
		_viewModel.Id=Id;
		_=_viewModel.GetData();
        _viewModel.UpdateEvent += UpdateEvent;
	}

    private async void UpdateEvent(object sender, bool e)
    {
        if (e)
        {
            _=Toast.Make("Activity Update Successfully”", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
            await Navigation.PushAsync(new ActivitysScreen());
        }
        else
        {
            _=Toast.Make("Somthingwent wrong",CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}