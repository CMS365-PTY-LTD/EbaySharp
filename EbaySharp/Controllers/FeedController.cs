using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Feed;
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
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.FEED.ENDPOINT_URL}{string.Format(Constants.SELL.FEED.METHODS.GET_DOWNLOAD_RESULT_FILE, taskId)}";
            return await new RequestExecuter().ExecuteGetRequest<ResultFile>(requestUrl, $"Bearer {accessToken}");
        }

        #endregion
    }
}
