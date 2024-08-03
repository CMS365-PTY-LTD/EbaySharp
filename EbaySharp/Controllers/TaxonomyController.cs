using EbaySharp.Entities.Common;
using EbaySharp.Entities.Develop.Taxonomy;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class TaxonomyController
    {
        private string accessToken;
        public TaxonomyController(string accessToken)
        {
            this.accessToken = accessToken;
        }
        public async Task<CategoryTreeId> GetDefaultCategoryTreeId(MarketplaceIdEnum MarketplaceId)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.COMMERCE.ENDPOINT_URL}{Constants.COMMERCE.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.COMMERCE.TAXONOMY.METHODS.GET_DEFAULT_CATEGORY_TREE_ID, MarketplaceId)}";
            return await new RequestExecuter().ExecuteGetRequest<CategoryTreeId>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<CategorySuggestions> GetCategorySuggestions(string CategoryTreeId, string query)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.COMMERCE.ENDPOINT_URL}{Constants.COMMERCE.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.COMMERCE.TAXONOMY.METHODS.GET_CATEGORY_SUGGESTIONS, CategoryTreeId, query)}";
            return await new RequestExecuter().ExecuteGetRequest<CategorySuggestions>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<CategoryTree> GetCategoryTree(string CategoryTreeId)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.COMMERCE.ENDPOINT_URL}{Constants.COMMERCE.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.COMMERCE.TAXONOMY.METHODS.GET_CATEGORY_TREE, CategoryTreeId)}";
            return await new RequestExecuter().ExecuteGetRequest<CategoryTree>(requestUrl, $"Bearer {accessToken}");
        }
    }
}
