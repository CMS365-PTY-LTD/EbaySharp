using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.ApplicationSettingsInsights.Analytics.RateLimit
{
    public class RateLimits
    {
        [JsonPropertyName("rateLimits")]
        public List<RateLimit> RateLimitList { get; set; }
    }
}
