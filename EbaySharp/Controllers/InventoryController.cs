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
        public async Task<BulkMigrateListingResponse> BulkMigrateAsync(BulkMigrateListingRequest bulkMigrateRequest)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{Constants.SELL.INVENTORY.METHODS.BULK_MIGRATE_LISTING}";
            return await new RequestExecuter().ExecutePostRequestAsync<BulkMigrateListingResponse>(requestUrl, $"Bearer {accessToken}", JsonConvert.SerializeObject(bulkMigrateRequest));
        }
        public async Task<InventoryItemsResponse> GetInventoryItems(int limit, int offset)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEMS, limit, offset)}";
            return await new RequestExecuter().ExecuteGetRequestAsync<InventoryItemsResponse>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<InventoryItemResponse> GetInventoryItem(string SKU)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEM, SKU)}";
            return await new RequestExecuter().ExecuteGetRequestAsync<InventoryItemResponse>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task DeleteInventoryItem(string SKU)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.INVENTORY_ITEM, SKU)}";
            await new RequestExecuter().ExecuteDeleteRequestAsync<InventoryItemResponse>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<OffersResponse> GetOffers(string SKU)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.INVENTORY.ENDPOINT_URL}{string.Format(Constants.SELL.INVENTORY.METHODS.OFFER, SKU)}";
            return await new RequestExecuter().ExecuteGetRequestAsync<OffersResponse>(requestUrl, $"Bearer {accessToken}");
        }
    }
}
