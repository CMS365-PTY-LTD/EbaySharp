using EbaySharp.Entities.Taxonomy;
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
        public async Task<CategoryTreeIDResponse> GetDefaultCategoryTreeIDAsync(string MarketplaceID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.COMMERCE.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.COMMERCE.TAXONOMY.METHODS.GET_DEFAULT_CategoryTreeID, MarketplaceID)}";
            return await new RequestExecuter().ExecuteGetRequestAsync<CategoryTreeIDResponse>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<CategorySuggestionsResponse> GetCategorySuggestionsAsync(string CategoryTreeID, string query)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.COMMERCE.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.COMMERCE.TAXONOMY.METHODS.GET_CATEGORY_SUGGESTIONS, CategoryTreeID, query)}";
            return await new RequestExecuter().ExecuteGetRequestAsync<CategorySuggestionsResponse>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<CategoryTreeResponse> GetCategoryTreeAsync(string CategoryTreeID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.COMMERCE.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.COMMERCE.TAXONOMY.METHODS.GET_CATEGORY_TREE, CategoryTreeID)}";
            return await new RequestExecuter().ExecuteGetRequestAsync<CategoryTreeResponse>(requestUrl, $"Bearer {accessToken}");
        }
    }
}
