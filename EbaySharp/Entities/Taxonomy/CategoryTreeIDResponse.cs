using Newtonsoft.Json;

namespace EbaySharp.Entities.Taxonomy
{
    public class CategoryTreeIDResponse
    {
        [JsonProperty("categoryTreeId")]
        public string TreeID { get; set; }
        [JsonProperty("categoryTreeVersion")]
        public string TreeVersion { get; set; }
    }
}
