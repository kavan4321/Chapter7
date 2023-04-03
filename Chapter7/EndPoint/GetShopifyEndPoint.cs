
using Chapter7.Interface;
using Refit;

namespace Chapter7.EndPoint
{
    public class GetShopifyEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
            For<ShopifyApi>("https://dummyjson.com/").
            GetShopifyList();
        }
    }
}
