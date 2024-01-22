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
        public async Task<ReturnPoliciesResponse> GetReturnPoliciesAsync(string marketplaceName)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.METADATA.ENDPOINT_URL}{string.Format(Constants.SELL.METADATA.METHODS.GET_RETURN_POLICIES, marketplaceName)}";
            return await new RequestExecuter().ExecuteGetRequestAsync<ReturnPoliciesResponse>(requestUrl, $"Bearer {accessToken}");
        }
    }
}
