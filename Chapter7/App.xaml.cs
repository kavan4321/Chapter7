using Chapter7.View.Page1View;
using Chapter7.View.Page2View;
using Chapter7.View.Page3View;
using Chapter7.View.Page4View;
using Chapter7.View.Page5View;
using Chapter7.View.Page6View;

namespace Chapter7;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ShopifyScreen())
        //{ BarBackgroundColor = Color.FromArgb("#131313") };
        //{ BarBackgroundColor = Color.FromArgb("#075E40") };
        { BarBackgroundColor = Colors.DarkCyan };

    }
}
