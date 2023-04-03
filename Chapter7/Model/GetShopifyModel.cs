
using Chapter7.EndPoint;
using Chapter7.HttpModel;
using Chapter7.Result;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter7.Model
{
    public class GetShopifyModel
    {
        private GetShopifyEndPoint _getShopifyEndPoint;

        public List<ProductDetail> ShopifiyDetails { get; set; }

        public GetShopifyModel()
        {
            _getShopifyEndPoint = new GetShopifyEndPoint();
        }

        public async Task<GetShopifyResult> GetShopifyDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var response=await _getShopifyEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data=await response.Content.ReadAsStringAsync();
                    var shopify = JsonConvert.DeserializeObject<ShopifyResponceModel>(data);
                    ShopifiyDetails = shopify.ProductsDetails;
                    return new GetShopifyResult()
                    {
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new GetShopifyResult()
                    {
                        IsSuccess = false,
                        Message = "Somthing went Wrong"
                    };
                }
            }
            else
            {
                return new GetShopifyResult()
                {
                    IsSuccess=false,
                    IsInternetError=true,
                    Message="No internet Connection"
                };
            }
        }
    }
}
