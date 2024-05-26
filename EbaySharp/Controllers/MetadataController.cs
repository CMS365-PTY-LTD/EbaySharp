using EbaySharp.Entities.Sell.Metadata.Marketplace;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class MetadataController
    {
        private string accessToken;
        public MetadataController(string accessToken)
        {
            this.accessToken = accessToken;
        }
        public async Task<ReturnPolicies> GetReturnPolicies(string marketplaceName)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.METADATA.ENDPOINT_URL}{string.Format(Constants.SELL.METADATA.METHODS.GET_RETURN_POLICIES, marketplaceName)}";
            return await new RequestExecuter().ExecuteGetRequest<ReturnPolicies>(requestUrl, $"Bearer {accessToken}");
        }
    }
}
