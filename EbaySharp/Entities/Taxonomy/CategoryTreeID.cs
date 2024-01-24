using Newtonsoft.Json;

namespace EbaySharp.Entities.Taxonomy
{
    public class CategoryTreeID
    {
        [JsonProperty("categoryTreeID")]
        public string TreeID { get; set; }
        [JsonProperty("categoryTreeVersion")]
        public string TreeVersion { get; set; }
    }
}
