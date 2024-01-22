﻿using EbaySharp.Entities.Inventory;
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

        public async Task<CategoryTreeIDResponse> GetDefaultCategoryTreeIDAsync(string MarketplaceID)
        {
            return await new TaxonomyController(accessToken).GetDefaultCategoryTreeIDAsync(MarketplaceID);
        }
        public async Task<CategorySuggestionsResponse> GetCategorySuggestionsAsync(string CategoryTreeID, string query)
        {
            return await new TaxonomyController(accessToken).GetCategorySuggestionsAsync(CategoryTreeID, query);
        }
        public async Task<CategoryTreeResponse> GetCategoryTreeAsync(string CategoryTreeID)
        {
            return await new TaxonomyController(accessToken).GetCategoryTreeAsync(CategoryTreeID);
        }

        #endregion

        #region METADATA 

        public async Task<ReturnPoliciesResponse> GetReturnPoliciesAsync(string MarketplaceID)
        {
            return await new MetadataController(accessToken).GetReturnPoliciesAsync(MarketplaceID);
        }

        #endregion

        #region INVENTORY 

        public async Task<BulkMigrateListingResponse> BulkMigrateAsync(BulkMigrateListingRequest bulkMigrateListingRequest)
        {
            return await new InventoryController(accessToken).BulkMigrateAsync(bulkMigrateListingRequest);
        }

        #endregion
    }
}
