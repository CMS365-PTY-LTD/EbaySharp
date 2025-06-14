using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Feed.InventoryTask;
using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Feed.Task;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class FeedController
    {
        private string accessToken;
        public FeedController(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region TASK

        public async Task<ResultFile> GetResultFile(string taskId)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.LISTING_MANAGEMENT.FEED.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.LISTING_MANAGEMENT.FEED.TASK.ENDPOINT_URL}{string.Format(Constants.DEVELOP.SELLING_APPS.LISTING_MANAGEMENT.FEED.TASK.METHODS.GET_DOWNLOAD_RESULT_FILE, taskId)}";
            return await new RequestExecuter().ExecuteGetRequest<ResultFile>(requestUrl, $"Bearer {accessToken}");
        }

        #endregion

            #region INVENTORY_TASK

        public async Task CreateInventoryTask(CreateInventoryRequest createInventoryRequest)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.LISTING_MANAGEMENT.FEED.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.LISTING_MANAGEMENT.FEED.INVENTORY_TASK.ENDPOINT_URL}";
            await new RequestExecuter().ExecutePostRequest(requestUrl, $"Bearer {accessToken}", createInventoryRequest.SerializeToJson());
        }

        #endregion
    }
}
