using EbaySharp.Entities.Taxonomy;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class TaxonomyController
    {
        private string accessToken;
        public TaxonomyController(string longLivedAccessToken)
        {
            accessToken = longLivedAccessToken;
        }
        public async Task<CategoryTreeIDResponse> GetDefaultCategoryTreeIDAsync(string MarketplaceID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.TAXONOMY.METHODS.GET_DEFAULT_CategoryTreeID, MarketplaceID)}";
            return await new RequestExecuter().ExecuteRequestAsync<CategoryTreeIDResponse>(requestUrl, this.accessToken);
        }
        public async Task<CategorySuggestionsResponse> GetCategorySuggestionsAsync(string CategoryTreeID, string query)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.TAXONOMY.METHODS.GET_CATEGORY_SUGGESTIONS, CategoryTreeID, query)}";
            return await new RequestExecuter().ExecuteRequestAsync<CategorySuggestionsResponse>(requestUrl, this.accessToken);
        }
        public async Task<CategoryTreeResponse> GetCategoryTreeAsync(string CategoryTreeID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.TAXONOMY.METHODS.GET_CATEGORY_TREE, CategoryTreeID)}";
            return await new RequestExecuter().ExecuteRequestAsync<CategoryTreeResponse>(requestUrl, this.accessToken);
        }
    }
}
