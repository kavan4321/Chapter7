using Chapter7.Tables.Page5Table;
using Chapter7.ViewModel.Page5ViewModel.ViewModelTask;
using CommunityToolkit.Maui.Alerts;

namespace Chapter7.View.Page5View;

public partial class TaskManagerScreen : ContentPage
{
	private TaskManagerViewModel _viewModel;
	public TaskManagerScreen()
	{
		InitializeComponent();
		_viewModel=(TaskManagerViewModel)BindingContext;
		_=_viewModel.GetListAsync();
        _viewModel.EditEvent += EditEvent;
        _viewModel.DeleteEvent += DeleteEvent;
	}

    private void DeleteEvent(object sender, bool e)
    {
        if (e)
        {
            Toast.Make("Task Deleted Successfully",CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            Toast.Make("Somthing is wrong", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

    private async void EditEvent(object sender, Result.TaskResult e)
    {
        if (e.IsSuccess)
        {
            await Navigation.PushAsync(new UpdateTaskScreen(e.Id));
        }
    }

    private async void AddButtonClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new NewTaskScreen());
    }
}