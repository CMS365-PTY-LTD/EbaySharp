using EbaySharp.Entities.Developer.Analytics.RateLimit;
using EbaySharp.Entities.Sell.Fulfillment.Order.ShippingFulfillment;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class AnalyticsController
    {
        private string accessToken;
        public AnalyticsController(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region RATE_LIMIT

        public async Task<RateLimits> GetRateLimits()
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.DEVELOPER.ENDPOINT_URL}{Constants.DEVELOPER.ANALYTICS.ENDPOINT_URL}{Constants.DEVELOPER.ANALYTICS.METHODS.GET_RATE_LIMITS}";
            return await new RequestExecuter().ExecuteGetRequest<RateLimits>(requestUrl, $"Bearer {accessToken}");
        }

        #endregion
    }
}
