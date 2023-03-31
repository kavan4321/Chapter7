using Chapter7.ViewModel.Page5ViewModel.ViewModelNewTask;
using CommunityToolkit.Maui.Alerts;

namespace Chapter7.View.Page5View;

public partial class NewTaskScreen : ContentPage
{
	private NewTaskViewModel _viewModel;
	public NewTaskScreen()
	{
		InitializeComponent();
		_viewModel=(NewTaskViewModel)BindingContext;
        _viewModel.AddTaskEvent += AddTaskEvent;
	}

    private async void AddTaskEvent(object sender, bool e)
    {
		if (e)
		{
			_=Toast.Make("Task Created Successfully",CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
			await Navigation.PopAsync();
		}
		else
		{
            _ = Toast.Make("Somthing went Wrong", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}