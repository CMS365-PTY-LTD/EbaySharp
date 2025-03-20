using EbaySharp.Entities.Common;
using EbaySharp.Entities.Develop.ApplicationSettingsInsights.Analytics.RateLimit;
using EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item;
using EbaySharp.Entities.Develop.KeyManagement.SigningKey;
using EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Transaction;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Feed.Task;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.InventoryItem;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Listing;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Location;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Offer;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Stores.Store;
using EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order;
using EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order.ShippingFulfillment;
using EbaySharp.Entities.Develop.SellingApps.SellingMetadata.Metadata.Marketplace;
using EbaySharp.Entities.Develop.Taxonomy;
using EbaySharp.Entities.Exceptions;
using EbaySharp.Entities.TraditionalSelling.Trading;

namespace EbaySharp.Controllers
{
    public class EbayController
    {
        private string accessToken;
        public EbayController(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region DEVELOP

        #region Application Settings Insights

        #region ANALYTICS

        #region RATE_LIMIT
        public async Task<RateLimits> GetRateLimits()
        {
            return await new AnalyticsController(accessToken).GetRateLimits();
        }

        #endregion

        #region USER_RATE_LIMIT
        public async Task<RateLimits> GetUserRateLimits()
        {
            return await new AnalyticsController(accessToken).GetUserRateLimits();
        }

        #endregion

        #endregion

        #region KEY_MANAGEMENT

        #region SIGNING_KEY

        public async Task<SigningKeys> GetSigningKeys()
        {
            return await new KeyManagementController(accessToken).GetSigningKeys();
        }
        public async Task<SigningKey> GetSigningKey(string signingKeyId)
        {
            return await new KeyManagementController(accessToken).GetSigningKey(signingKeyId);
        }
        public async Task<SigningKey> CreateSigningKey(SigningKeyCipher signingKeyCipher = SigningKeyCipher.ED25519)
        {
            return await new KeyManagementController(accessToken).CreateSigningKey(signingKeyCipher);
        }

        #endregion

        #endregion

        #endregion

        #region Buying Apps

        #region Inventory Discovery Refresh

        #region BROWSE

        public async Task<Item> GetItem(string itemId)
        {
            return await new BrowseController(accessToken).GetItem(itemId);
        }

        #endregion

        #endregion

        #endregion

        #region SELLING_APPS

        #region ACCOUNT_MANAGEMENT

        #region FINANCES
        public async Task<Transactions> GetTransactions(string? filter = null, string? sort = null, int limit = 20, int offset = 0)
        {
            return await new FinancesController(accessToken).GetTransactions(null, filter, sort, limit, offset);
        }
        public async Task<Transactions> GetTransactions(SigningKey? signingKey, string? filter = null, string? sort = null, int limit = 20, int offset = 0)
        {
            return await new FinancesController(accessToken).GetTransactions(signingKey, filter, sort, limit, offset);
        }
        public async Task<TransactionSummary> GetTransactionSummary(SigningKey? signingKey, string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                throw new FilterRequiredException();
            }
            return await new FinancesController(accessToken).GetTransactionSummary(signingKey, filter);
        }
        public async Task<TransactionSummary> GetTransactionSummary(string filter)
        {
            return await this.GetTransactionSummary(null, filter);
        }

        #endregion

        #endregion

        #region LISTING_MANAGEMENT

        #region FEED

        public async Task<ResultFile> GetResultFile(string taskId)
        {
            return await new FeedController(this.accessToken).GetResultFile(taskId);
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

        public async Task<InventoryItems> GetInventoryItems(int limit = 25, int offset = 0)
        {
            return await new InventoryController(accessToken).GetInventoryItems(limit, offset);
        }
        public async Task<InventoryItem> GetInventoryItem(string SKU)
        {
            return await new InventoryController(accessToken).GetInventoryItem(SKU);
        }
        public async Task<CreatedOrReplacedInventoryItem> CreateOrReplaceInventoryItem(string SKU, InventoryItem inventoryItem)
        {
            return await new InventoryController(accessToken).CreateOrReplaceInventoryItem(SKU, inventoryItem);
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
        public async Task<Offer> GetOffer(string offerId)
        {
            return await new InventoryController(accessToken).GetOffer(offerId);
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

        public async Task<InventoryLocations> GetInventoryLocations(int limit, int offset = 0)
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

        #region STORES

        #region STORE

        public async Task<StoreCategories> GetStoreCategories()
        {
            return await new StoresController(accessToken).GetStoreCategories();
        }

        #endregion

        #endregion

        #endregion

        #region Order Management

        #region FULFILLMENT

        #region ORDER

        #region SHIPPING_FULFILLEMENT

        public async Task<Fulfillments> GetShippingFulfillments(string? orderId)
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
        public async Task<Orders> GetOrders(string filter, int limit = 0, int offset = 0)
        {
            return await new FulfillmentController(accessToken).GetOrders(filter, limit, offset);
        }

        #endregion

        #endregion

        #endregion

        #region Selling Metadata

        #region METADATA 

        public async Task<ReturnPolicies> GetReturnPolicies(string MarketplaceId)
        {
            return await new MetadataController(accessToken).GetReturnPolicies(MarketplaceId);
        }

        #endregion

        #endregion

        #endregion

        #region TAXONOMY 

        public async Task<CategoryTreeId> GetDefaultCategoryTreeId(MarketplaceIdEnum MarketplaceId)
        {
            return await new TaxonomyController(accessToken).GetDefaultCategoryTreeId(MarketplaceId);
        }
        public async Task<CategorySuggestions> GetCategorySuggestions(string CategoryTreeId, string query)
        {
            return await new TaxonomyController(accessToken).GetCategorySuggestions(CategoryTreeId, query);
        }
        public async Task<CategoryTree> GetCategoryTree(string CategoryTreeId)
        {
            return await new TaxonomyController(accessToken).GetCategoryTree(CategoryTreeId);
        }

        #endregion

        #endregion

        #region TRADITIONAL_SELLING

        #region TRADING

        public async Task<GetSellerListResponse> GetItems(int siteId, int pageNumber, int entriesPerPage, string endTimeFrom, string endTimeTo)
        {
            return await new TradingController(accessToken).GetItems(siteId, pageNumber, entriesPerPage, endTimeFrom, endTimeTo);
        }

        #endregion

        #endregion
    }
}
