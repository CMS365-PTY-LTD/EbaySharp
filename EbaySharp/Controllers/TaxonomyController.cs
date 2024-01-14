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
        public async Task<CategoryTreeResponse> GetDefaultCategoryTreeID(string marketplace_id)
        {
            string requestUrl = $"{Constants.SERVER_URL}/{Constants.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.TAXONOMY.METHODS.GET_DEFAULT_CATEGORY_TREE_ID, marketplace_id)}";
            return await new RequestExecuter().ExecuteRequest<CategoryTreeResponse>(requestUrl, this.accessToken);
        }
        public async Task<CategorySuggestionsResponse> GetCategorySuggestions(string category_tree_id, string query)
        {
            string requestUrl = $"{Constants.SERVER_URL}/{Constants.TAXONOMY.ENDPOINT_URL}{string.Format(Constants.TAXONOMY.METHODS.GET_CATEGORY_SUGGESTIONS, category_tree_id, query)}";
            return await new RequestExecuter().ExecuteRequest<CategorySuggestionsResponse>(requestUrl, this.accessToken);
        }
    }
}
