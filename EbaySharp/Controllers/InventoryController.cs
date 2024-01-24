// Ignore Spelling: SKU

using EbaySharp.Entities.Sell.Inventory.InventoryItem;
using EbaySharp.Entities.Sell.Inventory.Listing;
using EbaySharp.Entities.Sell.Inventory.Offer;
using EbaySharp.Source;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EbaySharp.Controllers
{
    class InventoryController
    {
        private string accessToken;
        public InventoryController(string accessToken)
        {
            this.accessToken = accessToken;
        }
        public async Task<BulkMigrateListingResponse> BulkMigrate(BulkMigrateListingRequest bulkMigrateRequest)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{Constants.SELL.INVENTORY.METHODS.BULK_MIGRATE_LISTING}";
            return await new RequestExecuter().ExecutePostRequest<BulkMigrateListingResponse>(requestUrl, $"Bearer {accessToken}", JsonConvert.SerializeObject(bulkMigrateRequest));
        }
        public async Task<InventoryItemsList> GetInventoryItems(int limit, int offset)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEMS, limit, offset)}";
            return await new RequestExecuter().ExecuteGetRequest<InventoryItemsList>(requestUrl, $"Bearer {accessToken}");
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
        public async Task<OffersList> GetOffers(string SKU)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFERS, SKU)}";
            return await new RequestExecuter().ExecuteGetRequest<OffersList>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<Offer> GetOffer(string offerID)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, offerID)}";
            return await new RequestExecuter().ExecuteGetRequest<Offer>(requestUrl, $"Bearer {accessToken}");
        }
    }
}
