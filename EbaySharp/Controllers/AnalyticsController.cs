using EbaySharp.Entities.Develop.ApplicationSettingsInsights.Analytics.RateLimit;
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
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.DEVELOPER.ENDPOINT_URL}{Constants.DEVELOPER.ANALYTICS.ENDPOINT_URL}{Constants.DEVELOPER.ANALYTICS.METHODS.GET_RATE_LIMITS}";
            return await new RequestExecuter().ExecuteGetRequest<RateLimits>(requestUrl, $"Bearer {accessToken}");
        }

        #endregion

        #region USER_RATE_LIMIT

        public async Task<RateLimits> GetUserRateLimits()
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.DEVELOPER.ENDPOINT_URL}{Constants.DEVELOPER.ANALYTICS.ENDPOINT_URL}{Constants.DEVELOPER.ANALYTICS.METHODS.GET_USER_RATE_LIMITS}";
            return await new RequestExecuter().ExecuteGetRequest<RateLimits>(requestUrl, $"Bearer {accessToken}");
        }

        #endregion
    }
}
