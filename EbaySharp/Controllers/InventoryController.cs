using EbaySharp.Entities.Inventory;
using EbaySharp.Source;
using Newtonsoft.Json;

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
    }
}
