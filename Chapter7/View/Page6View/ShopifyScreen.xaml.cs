using Chapter7.ViewModel.Page6ViewModel.ViewModelShopify;
using CommunityToolkit.Maui.Alerts;

namespace Chapter7.View.Page6View;

public partial class ShopifyScreen : ContentPage
{
	private ShopifyViewModel _shopifyViewModel;
	public ShopifyScreen()
	{
		InitializeComponent();
		_shopifyViewModel=(ShopifyViewModel)BindingContext;
		_ = GetShopifyList();
        _shopifyViewModel.GetShopifyEvent += GetShopifyEvent;
        _shopifyViewModel.AddDataEvent += AddDataEvent;
	}

    private void AddDataEvent(object sender, bool e)
    {
		if (e)
		{
			Toast.Make("Data Added Sucessfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
		else
		{
			Toast.Make("Somthing went wrong", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }

    private void GetShopifyEvent(object sender, Result.GetShopifyResult e)
    {
		if (e.IsSuccess)
		{
			Toast.Make("Data Fetch Sucessfully", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
		else
		{
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

    private async Task GetShopifyList()
	{
		await _shopifyViewModel.GetShopifyListApiAsync();
        await _shopifyViewModel.InsertAsync();
        await _shopifyViewModel.GetShopifyListDatabaseAsync();
    }
}