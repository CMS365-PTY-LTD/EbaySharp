using EbaySharp.Entities.Sell.Inventory.InventoryItem;
using EbaySharp.Entities.Sell.Inventory.Listing;
using EbaySharp.Entities.Sell.Inventory.Location;
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

        public async Task<CategoryTreeID> GetDefaultCategoryTreeID(string MarketplaceID)
        {
            return await new TaxonomyController(accessToken).GetDefaultCategoryTreeID(MarketplaceID);
        }
        public async Task<CategorySuggestions> GetCategorySuggestions(string CategoryTreeID, string query)
        {
            return await new TaxonomyController(accessToken).GetCategorySuggestions(CategoryTreeID, query);
        }
        public async Task<CategoryTree> GetCategoryTree(string CategoryTreeID)
        {
            return await new TaxonomyController(accessToken).GetCategoryTree(CategoryTreeID);
        }

        #endregion

        #region METADATA 

        public async Task<ReturnPolicies> GetReturnPoliciesAsync(string MarketplaceID)
        {
            return await new MetadataController(accessToken).GetReturnPolicies(MarketplaceID);
        }

        #endregion

        #region INVENTORY 

        public async Task<BulkMigrateListingResponse> BulkMigrate(BulkMigrateListingRequest bulkMigrateListingRequest)
        {
            return await new InventoryController(accessToken).BulkMigrate(bulkMigrateListingRequest);
        }
        public async Task<InventoryItems> GetInventoryItems(int limit, int offset)
        {
            return await new InventoryController(accessToken).GetInventoryItems(limit, offset);
        }
        public async Task<InventoryItem> GetInventoryItem(string SKU)
        {
            return await new InventoryController(accessToken).GetInventoryItem(SKU);
        }
        public async Task<Offers> GetOffers(string SKU)
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
        public async Task<InventoryLocations> GetInventoryLocations(int limit, int offset)
        {
            return await new InventoryController(accessToken).GetInventoryLocations(limit, offset);
        }
        public async Task<InventoryLocation> GetInventoryLocation(string merchantLocationKey)
        {
            return await new InventoryController(accessToken).GetInventoryLocation(merchantLocationKey);
        }

        #endregion
    }
}
