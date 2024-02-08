namespace EbaySharp.Entities.Developer.Analytics.RateLimit
{
    public class Resource
    {
        public string Name { get; set; }
        public List<Rate> Rates { get; set; }
    }
}