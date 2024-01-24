using EbaySharp.Entities.Sell.Inventory.InventoryItem;
using EbaySharp.Entities.Sell.Inventory.Listing;
using EbaySharp.Entities.Sell.Inventory.Offer;
using EbaySharp.Entities.Sell.Metadata.Marketplace;
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

        public async Task<CategoryTreeID> GetDefaultCategoryTreeIDAsync(string MarketplaceID)
        {
            return await new TaxonomyController(accessToken).GetDefaultCategoryTreeID(MarketplaceID);
        }
        public async Task<CategorySuggestionsList> GetCategorySuggestionsAsync(string CategoryTreeID, string query)
        {
            return await new TaxonomyController(accessToken).GetCategorySuggestions(CategoryTreeID, query);
        }
        public async Task<CategoryTree> GetCategoryTreeAsync(string CategoryTreeID)
        {
            return await new TaxonomyController(accessToken).GetCategoryTree(CategoryTreeID);
        }

        #endregion

        #region METADATA 

        public async Task<ReturnPoliciesList> GetReturnPoliciesAsync(string MarketplaceID)
        {
            return await new MetadataController(accessToken).GetReturnPolicies(MarketplaceID);
        }

        #endregion

        #region INVENTORY 

        public async Task<BulkMigrateListingResponse> BulkMigrateAsync(BulkMigrateListingRequest bulkMigrateListingRequest)
        {
            return await new InventoryController(accessToken).BulkMigrate(bulkMigrateListingRequest);
        }
        public async Task<InventoryItemsList> GetInventoryItems(int limit, int offset)
        {
            return await new InventoryController(accessToken).GetInventoryItems(limit, offset);
        }
        public async Task<InventoryItem> GetInventoryItem(string SKU)
        {
            return await new InventoryController(accessToken).GetInventoryItem(SKU);
        }
        public async Task<OffersList> GetOffers(string SKU)
        {
            return await new InventoryController(accessToken).GetOffers(SKU);
        }
        public async Task<Offer> GetOffer(string offerID)
        {
            return await new InventoryController(accessToken).GetOffer(offerID);
        }
        public async Task DeleteInventoryItem(string SKU)
        {
            await new InventoryController(accessToken).DeleteInventoryItem(SKU);
        }

        #endregion
    }
}
