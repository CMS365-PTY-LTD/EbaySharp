namespace EbaySharp.Entities.Develop.ApplicationSettingsInsights.Analytics.RateLimit
{
    public class RateLimit
    {
        public string ApiContext { get; set; }
        public string ApiName { get; set; }
        public string ApiVersion { get; set; }
        public List<Resource> Resources { get; set; }
    }
}
