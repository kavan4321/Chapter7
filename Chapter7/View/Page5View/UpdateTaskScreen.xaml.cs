using Chapter7.ViewModel.Page5ViewModel.ViewModel.UpdateTask;
using Chapter7.ViewModel.Page5ViewModel.ViewModelTask;
using CommunityToolkit.Maui.Alerts;

namespace Chapter7.View.Page5View;

public partial class UpdateTaskScreen : ContentPage
{
	private UpdateTaskViewModel _viewModel;
	public UpdateTaskScreen(int Id)
	{
		InitializeComponent();
		_viewModel = (UpdateTaskViewModel)BindingContext;
		_viewModel.Id = Id;
		_=_viewModel.GetDataFromDatabase();
        _viewModel.UpdateEvent += UpdateEvent;
	}

    private async void UpdateEvent(object sender, bool e)
    {
		if (e)
		{
            await Navigation.PopAsync();
            _ =Toast.Make("Task Updated Successfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
		else
		{
			_=Toast.Make("Somthing is wrong", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}