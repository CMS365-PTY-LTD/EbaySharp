using Newtonsoft.Json;

namespace EbaySharp.Entities.Taxonomy
{
    public class CategoryTreeResponse
    {
        [JsonProperty("categoryTreeId")]
        public string TreeId { get; set; }
        [JsonProperty("categoryTreeVersion")]
        public string TreeVersion { get; set; }
    }
}
