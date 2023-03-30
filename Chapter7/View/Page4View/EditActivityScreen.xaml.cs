using Chapter7.Tables.Page4Table;
using Chapter7.ViewModel.Page4ViewModel.ViewModelUpdate;

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
	}

    private void AddButton_Clicked(object sender, EventArgs e)
    {

    }
}