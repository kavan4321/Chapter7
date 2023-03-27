namespace Chapter7.View.Page2View;
public partial class TelegramScreen : FlyoutPage
{
	public TelegramScreen()
	{
		InitializeComponent();
        TelegramMenuPage.TelegramCollection.SelectionChanged += TelegramCollection_SelectionChanged;

    }

    private void TelegramCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as TelegramItems;
        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        }
    }
}