
using Refit;

namespace Chapter7.Interface
{
    public interface ShopifyApi
    {
        [Get("/products")]
        Task<HttpResponseMessage> GetShopifyList();
    }
}
