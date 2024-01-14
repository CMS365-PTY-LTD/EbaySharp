using EbaySharp.Entities.Taxonomy;

namespace EbaySharp.Controllers
{
    public class EbayController
    {
        private string accessToken;
        public EbayController(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region TAXONOMY 

        public async Task<CategoryTreeResponse> GetDefaultCategoryTreeID(string marketplace_id)
        {
            return await new TaxonomyController(accessToken).GetDefaultCategoryTreeID(marketplace_id);
        }
        public async Task<CategorySuggestionsResponse> GetCategorySuggestions(string category_tree_id, string query)
        {
            return await new TaxonomyController(accessToken).GetCategorySuggestions(category_tree_id, query);
        }

        #endregion
    }
}
