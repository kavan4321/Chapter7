using Chapter7.View.Page1View;
using Chapter7.View.Page2View;
using Chapter7.View.Page3View;

namespace Chapter7;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new RegisterScreen())
		{ BarBackgroundColor = Color.FromArgb("#131313") };
	}
}
