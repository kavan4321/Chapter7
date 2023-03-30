using Chapter7.ViewModel.Page3ViewModel.ViewModelDashBoard;

namespace Chapter7.View.Page3View;

public partial class DashboardScreen : ContentPage
{
	private DashboardViewModel _viewModel;
	public DashboardScreen(int Id)
	{
		InitializeComponent();
		_viewModel=(DashboardViewModel)BindingContext;
		_viewModel.Id = Id;
		_ = _viewModel.GetUserDetails();
	}



    private void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
    }
}