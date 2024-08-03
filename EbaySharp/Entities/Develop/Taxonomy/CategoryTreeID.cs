using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.Taxonomy
{
    public class CategoryTreeId
    {
        [JsonPropertyName("categoryTreeId")]
        public string TreeId { get; set; }
        public string CategoryTreeVersion { get; set; }
    }
}
