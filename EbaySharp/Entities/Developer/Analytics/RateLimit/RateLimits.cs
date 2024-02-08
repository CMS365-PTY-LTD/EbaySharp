using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Developer.Analytics.RateLimit
{
    public class RateLimits
    {
        [JsonPropertyName("rateLimits")]
        public List<RateLimit> RateLimitList { get; set; }
    }
}
