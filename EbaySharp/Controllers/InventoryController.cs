﻿// Ignore Spelling: SKU

using EbaySharp.Entities.Sell.Inventory.InventoryItem;
using EbaySharp.Entities.Sell.Inventory.Listing;
using EbaySharp.Entities.Sell.Inventory.Location;
using EbaySharp.Entities.Sell.Inventory.Offer;
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
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{Constants.SELL.INVENTORY.METHODS.BULK_MIGRATE_LISTING}";
            return await new RequestExecuter().ExecutePostRequest<BulkMigrateListingResponse>(requestUrl, $"Bearer {accessToken}", bulkMigrateRequest.SerializeToJson());
        }

        #endregion

        #region INVENTORY_ITEM
        public async Task<InventoryItems> GetInventoryItems(int limit, int offset)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEMS, limit, offset)}";
            return await new RequestExecuter().ExecuteGetRequest<InventoryItems>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<InventoryItem> GetInventoryItem(string SKU)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEM, SKU)}";
            return await new RequestExecuter().ExecuteGetRequest<InventoryItem>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task DeleteInventoryItem(string SKU)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEM, SKU)}";
            await new RequestExecuter().ExecuteDeleteRequest(requestUrl, $"Bearer {accessToken}");
        }
        public async Task CreateOrReplaceInventoryItem(string SKU, InventoryItem inventoryItem)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEM, SKU)}";
            await new RequestExecuter().ExecutePutRequest(requestUrl, $"Bearer {accessToken}", inventoryItem.SerializeToJson(), inventoryItem.Locale);
        }

        #endregion

        #region OFFER

        public async Task<Offers> GetOffers(string SKU)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFERS, SKU)}";
            return await new RequestExecuter().ExecuteGetRequest<Offers>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<Offer> GetOffer(string offerID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerID)}";
            return await new RequestExecuter().ExecuteGetRequest<Offer>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<OfferCreated> CreateOffer(Offer offer, string locale)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{Constants.SELL.INVENTORY.METHODS.CREATE_OFFER}";
            return await new RequestExecuter().ExecutePostRequest<OfferCreated>(requestUrl, $"Bearer {accessToken}", offer.SerializeToJson(), locale);
        }
        public async Task UpdateOffer(string offerID, Offer offer, string locale)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerID)}";
            await new RequestExecuter().ExecutePutRequest(requestUrl, $"Bearer {accessToken}", offer.SerializeToJson(), locale);
        }
        public async Task<OfferPublished> PublishOffer(string offerID, string locale)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerID)}/publish";
            return await new RequestExecuter().ExecutePostRequest<OfferPublished>(requestUrl, $"Bearer {accessToken}", null, locale);
        }
        public async Task<OfferWithdrawn> WithdrawOffer(string offerID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerID)}/withdraw";
            return await new RequestExecuter().ExecutePostRequest<OfferWithdrawn>(requestUrl, $"Bearer {accessToken}", null, null);
        }
        public async Task DeleteOffer(string offerID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerID)}";
            await new RequestExecuter().ExecuteDeleteRequest(requestUrl, $"Bearer {accessToken}");
        }

        #endregion

        #region INVENTORY_LOCATION

        public async Task<InventoryLocations> GetInventoryLocations(int limit, int offset)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.LOCATIONS, limit, offset)}";
            return await new RequestExecuter().ExecuteGetRequest<InventoryLocations>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<InventoryLocation> GetInventoryLocation(string merchantLocationKey)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.LOCATION, merchantLocationKey)}";
            return await new RequestExecuter().ExecuteGetRequest<InventoryLocation>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task CreateInventoryLocation(InventoryLocation inventoryLocation)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.LOCATION, inventoryLocation.MerchantLocationKey)}";
            await new RequestExecuter().ExecutePostRequest(requestUrl, $"Bearer {accessToken}", inventoryLocation.SerializeToJson(), null);
        }
        public async Task DeleteInventoryLocation(string merchantLocationKey)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.LOCATION, merchantLocationKey)}";
            await new RequestExecuter().ExecuteDeleteRequest(requestUrl, $"Bearer {accessToken}");
        }

        #endregion
    }
}
