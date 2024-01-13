using EbaySharp.Entities.Taxonomy;
using EbaySharp.Source;
using Newtonsoft.Json;

namespace EbaySharp.Controllers
{
    class TaxonomyController
    {
        private string accessToken;
        public TaxonomyController(string longLivedAccessToken)
        {
            accessToken = longLivedAccessToken;
        }
        public async Task<CategoryTree> GetDefaultCategoryTreeId(string marketplace_id)
        {
            var client = Helpers.GetHttpClient();
            string requestUrl = $"{Constants.SERVER_URL}/{Constants.TAXONOMY.ENDPOINT_URL}/{string.Format(Constants.TAXONOMY.METHODS.GET_DEFAULT_CATEGORY_TREE_ID, marketplace_id)}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Authorization", $"Bearer {accessToken}");
            var response = await client.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrEmpty(responseContent))
                {
                    throw new Exception("No content found.");
                }
                return JsonConvert.DeserializeObject<CategoryTree>(responseContent);
            }
            throw new Exception($"Error, {response.Content}");
        }
    }
}
