using EbaySharp.Entities.Metadata;
using EbaySharp.Entities.Taxonomy;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class MetadataController
    {
        private string accessToken;
        public MetadataController(string longLivedAccessToken)
        {
            accessToken = longLivedAccessToken;
        }
        public async Task<ReturnPoliciesResponse> GetReturnPolicies(string marketplaceName)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.METADATA.ENDPOINT_URL}{string.Format(Constants.METADATA.METHODS.GET_RETURN_POLICIES, marketplaceName)}";
            return await new RequestExecuter().ExecuteRequest<ReturnPoliciesResponse>(requestUrl, this.accessToken);
        }
    }
}
