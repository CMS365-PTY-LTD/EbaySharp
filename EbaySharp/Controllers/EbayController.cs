using EbaySharp.Entities.Commerce.Taxonomy;
using EbaySharp.Entities.Common;
using EbaySharp.Entities.Developer.Analytics.RateLimit;
using EbaySharp.Entities.Sell.Fulfillment.Order;
using EbaySharp.Entities.Sell.Fulfillment.Order.ShippingFulfillment;
using EbaySharp.Entities.Sell.Inventory.InventoryItem;
using EbaySharp.Entities.Sell.Inventory.Listing;
using EbaySharp.Entities.Sell.Inventory.Location;
using EbaySharp.Entities.Sell.Inventory.Offer;
using EbaySharp.Entities.Sell.Metadata.Marketplace;
using EbaySharp.Source;
using static EbaySharp.Source.Constants.SELL;

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

        public async Task<CategoryTreeID> GetDefaultCategoryTreeId(MarketplaceIdEnum MarketplaceId)
        {
            return await new TaxonomyController(accessToken).GetDefaultCategoryTreeId(MarketplaceId);
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

        public async Task<ReturnPolicies> GetReturnPolicies(string MarketplaceId)
        {
            return await new MetadataController(accessToken).GetReturnPolicies(MarketplaceId);
        }

        #endregion

        #region INVENTORY 

        #region LISTING

        public async Task<BulkMigrateListingResponse> BulkMigrate(BulkMigrateListingRequest bulkMigrateListingRequest)
        {
            return await new InventoryController(accessToken).BulkMigrate(bulkMigrateListingRequest);
        }

        #endregion

        #region INVENTORY_ITEM

        public async Task<InventoryItems> GetInventoryItems(int limit=25, int offset = 0)
        {
            return await new InventoryController(accessToken).GetInventoryItems(limit, offset);
        }
        public async Task<InventoryItem> GetInventoryItem(string SKU)
        {
            return await new InventoryController(accessToken).GetInventoryItem(SKU);
        }
        public async Task CreateOrReplaceInventoryItem(string SKU, InventoryItem inventoryItem)
        {
            await new InventoryController(accessToken).CreateOrReplaceInventoryItem(SKU, inventoryItem);
        }
        public async Task DeleteInventoryItem(string SKU)
        {
            await new InventoryController(accessToken).DeleteInventoryItem(SKU);
        }

        #endregion

        #region OFFER

        public async Task<Offers> GetOffers(string SKU)
        {
            return await new InventoryController(accessToken).GetOffers(SKU);
        }
        public async Task<Offer> GetOffer(string offerID)
        {
            return await new InventoryController(accessToken).GetOffer(offerID);
        }
        public async Task<OfferCreated> CreateOffer(Offer offer, string locale)
        {
            return await new InventoryController(accessToken).CreateOffer(offer, locale);
        }
        public async Task UpdateOffer(string offerId, Offer offer, string locale)
        {
            await new InventoryController(accessToken).UpdateOffer(offerId, offer, locale);
        }
        public async Task<OfferPublished> PublishOffer(string offerId, string locale)
        {
            return await new InventoryController(accessToken).PublishOffer(offerId, locale);
        }
        public async Task<OfferWithdrawn> WithdrawOffer(string offerId)
        {
            return await new InventoryController(accessToken).WithdrawOffer(offerId);
        }
        public async Task DeleteOffer(string offerId)
        {
            await new InventoryController(accessToken).DeleteOffer(offerId);
        }

        #endregion

        #region INVENTORY_LOCATION

        public async Task<InventoryLocations> GetInventoryLocations(int limit, int offset)
        {
            return await new InventoryController(accessToken).GetInventoryLocations(limit, offset);
        }
        public async Task<InventoryLocation> GetInventoryLocation(string merchantLocationKey)
        {
            return await new InventoryController(accessToken).GetInventoryLocation(merchantLocationKey);
        }
        public async Task CreateInventoryLocation(InventoryLocation inventoryLocation)
        {
            await new InventoryController(accessToken).CreateInventoryLocation(inventoryLocation);
        }
        public async Task DeleteInventoryLocation(string merchantLocationKey)
        {
            await new InventoryController(accessToken).DeleteInventoryLocation(merchantLocationKey);
        }

        #endregion

        #endregion

        #region FULFILLMENT

        #region ORDER

        #region SHIPPING_FULFILLEMENT

        public async Task<Fulfillments> GetShippingFulfillments(string orderId)
        {
            return await new FulfillmentController(accessToken).GetShippingFulfillments(orderId);
        }
        public async Task<Fulfillment> GetShippingFulfillment(string orderId, string fulfillmentId)
        {
            return await new FulfillmentController(accessToken).GetShippingFulfillment(orderId, fulfillmentId);
        }
        public async Task CreateShippingFulfillment(string orderId, Fulfillment fulfillment)
        {
            await new FulfillmentController(accessToken).CreateShippingFulfillment(orderId, fulfillment);
        }

        #endregion

        public async Task<Orders> GetOrders(string[] orderNumbers)
        {
            return await new FulfillmentController(accessToken).GetOrders(orderNumbers);
        }
        public async Task<Order> GetOrder(string orderNumber)
        {
            return await new FulfillmentController(accessToken).GetOrder(orderNumber);
        }
        public async Task<Orders> GetOrders(string filter, int limit=0, int offset=0)
        {
            return await new FulfillmentController(accessToken).GetOrders(filter, limit, offset);
        }

        #endregion

        #endregion

        #region ANALYTICS

        public async Task<RateLimits> GetRateLimits()
        {
            return await new AnalyticsController(accessToken).GetRateLimits();
        }

        #endregion
    }
}
