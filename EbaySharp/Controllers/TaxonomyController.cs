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
        public async Task<CategoryTreeID> GetDefaultCategoryTreeID(string MarketplaceID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.COMMERCE.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.COMMERCE.TAXONOMY.METHODS.GET_DEFAULT_CategoryTreeID, MarketplaceID)}";
            return await new RequestExecuter().ExecuteGetRequest<CategoryTreeID>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<CategorySuggestions> GetCategorySuggestions(string CategoryTreeID, string query)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.COMMERCE.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.COMMERCE.TAXONOMY.METHODS.GET_CATEGORY_SUGGESTIONS, CategoryTreeID, query)}";
            return await new RequestExecuter().ExecuteGetRequest<CategorySuggestions>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<CategoryTree> GetCategoryTree(string CategoryTreeID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.COMMERCE.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.COMMERCE.TAXONOMY.METHODS.GET_CATEGORY_TREE, CategoryTreeID)}";
            return await new RequestExecuter().ExecuteGetRequest<CategoryTree>(requestUrl, $"Bearer {accessToken}");
        }
    }
}
