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
        public async Task<CategoryTreeIDResponse> GetDefaultCategoryTreeID(string MarketplaceID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.TAXONOMY.METHODS.GET_DEFAULT_CategoryTreeID, MarketplaceID)}";
            return await new RequestExecuter().ExecuteRequest<CategoryTreeIDResponse>(requestUrl, this.accessToken);
        }
        public async Task<CategorySuggestionsResponse> GetCategorySuggestions(string CategoryTreeID, string query)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.TAXONOMY.METHODS.GET_CATEGORY_SUGGESTIONS, CategoryTreeID, query)}";
            return await new RequestExecuter().ExecuteRequest<CategorySuggestionsResponse>(requestUrl, this.accessToken);
        }
        public async Task<CategoryTreeResponse> GetCategoryTree(string CategoryTreeID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.TAXONOMY.METHODS.GET_CATEGORY_TREE, CategoryTreeID)}";
            return await new RequestExecuter().ExecuteRequest<CategoryTreeResponse>(requestUrl, this.accessToken);
        }
    }
}
