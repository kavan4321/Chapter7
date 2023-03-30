using Chapter7.View.Page1View;
using Chapter7.View.Page2View;
using Chapter7.View.Page3View;
using Chapter7.View.Page4View;

namespace Chapter7;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ActivitysScreen());
		//{ BarBackgroundColor = Color.FromArgb("#131313") };
		//{ BarBackgroundColor = Color.FromArgb("#075E40") };
    }
}
