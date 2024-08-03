// Ignore Spelling: SKU

using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.InventoryItem;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Listing;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Location;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Offer;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class InventoryController
    {
        private string accessToken;
        public InventoryController(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region LISTING
        public async Task<BulkMigrateListingResponse> BulkMigrate(BulkMigrateListingRequest bulkMigrateRequest)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{Constants.SELL.INVENTORY.METHODS.BULK_MIGRATE_LISTING}";
            return await new RequestExecuter().ExecutePostRequest<BulkMigrateListingResponse>(requestUrl, $"Bearer {accessToken}", bulkMigrateRequest.SerializeToJson());
        }

        #endregion

        #region INVENTORY_ITEM
        public async Task<InventoryItems> GetInventoryItems(int limit, int offset)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEMS, limit, offset)}";
            return await new RequestExecuter().ExecuteGetRequest<InventoryItems>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<InventoryItem> GetInventoryItem(string SKU)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEM, Uri.EscapeDataString(SKU))}";
            return await new RequestExecuter().ExecuteGetRequest<InventoryItem>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task DeleteInventoryItem(string SKU)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEM, Uri.EscapeDataString(SKU))}";
            await new RequestExecuter().ExecuteDeleteRequest(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<CreatedOrReplacedInventoryItem> CreateOrReplaceInventoryItem(string SKU, InventoryItem inventoryItem)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEM, Uri.EscapeDataString(SKU))}";
            return await new RequestExecuter().ExecutePutRequest<CreatedOrReplacedInventoryItem>(requestUrl, $"Bearer {accessToken}", inventoryItem.SerializeToJson(), inventoryItem.Locale);
        }

        #endregion

        #region OFFER

        public async Task<Offers> GetOffers(string SKU)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFERS, Uri.EscapeDataString(SKU))}";
            return await new RequestExecuter().ExecuteGetRequest<Offers>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<Offer> GetOffer(string offerId)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerId)}";
            return await new RequestExecuter().ExecuteGetRequest<Offer>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<OfferCreated> CreateOffer(Offer offer, string locale)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{Constants.SELL.INVENTORY.METHODS.CREATE_OFFER}";
            return await new RequestExecuter().ExecutePostRequest<OfferCreated>(requestUrl, $"Bearer {accessToken}", offer.SerializeToJson(), locale);
        }
        public async Task<OfferUpdated> UpdateOffer(string offerId, Offer offer, string locale)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerId)}";
            return await new RequestExecuter().ExecutePutRequest<OfferUpdated>(requestUrl, $"Bearer {accessToken}", offer.SerializeToJson(), locale);
        }
        public async Task<OfferPublished> PublishOffer(string offerId, string locale)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerId)}/publish";
            return await new RequestExecuter().ExecutePostRequest<OfferPublished>(requestUrl, $"Bearer {accessToken}", null, locale);
        }
        public async Task<OfferWithdrawn> WithdrawOffer(string offerId)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerId)}/withdraw";
            return await new RequestExecuter().ExecutePostRequest<OfferWithdrawn>(requestUrl, $"Bearer {accessToken}", null, null);
        }
        public async Task DeleteOffer(string offerId)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerId)}";
            await new RequestExecuter().ExecuteDeleteRequest(requestUrl, $"Bearer {accessToken}");
        }

        #endregion

        #region INVENTORY_LOCATION

        public async Task<InventoryLocations> GetInventoryLocations(int limit, int offset)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.LOCATIONS, limit, offset)}";
            return await new RequestExecuter().ExecuteGetRequest<InventoryLocations>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<InventoryLocation> GetInventoryLocation(string merchantLocationKey)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.LOCATION, merchantLocationKey)}";
            return await new RequestExecuter().ExecuteGetRequest<InventoryLocation>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task CreateInventoryLocation(InventoryLocation inventoryLocation)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.LOCATION, inventoryLocation.MerchantLocationKey)}";
            await new RequestExecuter().ExecutePostRequest(requestUrl, $"Bearer {accessToken}", inventoryLocation.SerializeToJson(), null);
        }
        public async Task DeleteInventoryLocation(string merchantLocationKey)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.LOCATION, merchantLocationKey)}";
            await new RequestExecuter().ExecuteDeleteRequest(requestUrl, $"Bearer {accessToken}");
        }

        #endregion
    }
}
