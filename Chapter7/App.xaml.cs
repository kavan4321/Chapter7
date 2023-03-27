using Chapter7.View.Page1View;
using Chapter7.View.Page2View;

namespace Chapter7;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new TelegramScreen());
	}
}
