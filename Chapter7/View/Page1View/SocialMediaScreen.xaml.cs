namespace Chapter7.View.Page1View;

public partial class SocialMediaScreen : FlyoutPage
{
	public SocialMediaScreen()
	{
		InitializeComponent();
        flyoutPage.SocialCollectionView.SelectionChanged += CollectionView_SelectionChanged;
	}

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SocialMediaItems item =e.CurrentSelection.FirstOrDefault() as SocialMediaItems;

        if (item != null)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));          
        }
    }
}