using EbaySharp.Entities.Develop.SellingApps.SellingMetadata.Metadata.Marketplace;
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
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.LISTING_METADATA.METADATA.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.LISTING_METADATA.METADATA.MARKETPLACE.ENDPOINT_URL}{string.Format(Constants.DEVELOP.SELLING_APPS.LISTING_METADATA.METADATA.MARKETPLACE.METHODS.GET_RETURN_POLICIES, marketplaceName)}";
            return await new RequestExecuter().ExecuteGetRequest<ReturnPolicies>(requestUrl, $"Bearer {accessToken}");
        }
    }
}
