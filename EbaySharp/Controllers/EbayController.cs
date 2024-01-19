using EbaySharp.Entities.Metadata;
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

        public async Task<CategoryTreeIDResponse> GetDefaultCategoryTreeID(string MarketplaceID)
        {
            return await new TaxonomyController(accessToken).GetDefaultCategoryTreeID(MarketplaceID);
        }
        public async Task<CategorySuggestionsResponse> GetCategorySuggestions(string CategoryTreeID, string query)
        {
            return await new TaxonomyController(accessToken).GetCategorySuggestions(CategoryTreeID, query);
        }
        public async Task<CategoryTreeResponse> GetCategoryTree(string CategoryTreeID)
        {
            return await new TaxonomyController(accessToken).GetCategoryTree(CategoryTreeID);
        }

        #endregion

        #region metadata 

        public async Task<ReturnPoliciesResponse> GetReturnPolicies(string MarketplaceID)
        {
            return await new MetadataController(accessToken).GetReturnPolicies(MarketplaceID);
        }

        #endregion
    }
}
