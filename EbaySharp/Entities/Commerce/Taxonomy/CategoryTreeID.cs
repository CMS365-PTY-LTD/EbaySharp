using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Commerce.Taxonomy
{
    public class CategoryTreeID
    {
        [JsonPropertyName("categoryTreeId")]
        public string TreeID { get; set; }
        public string CategoryTreeVersion { get; set; }
    }
}
