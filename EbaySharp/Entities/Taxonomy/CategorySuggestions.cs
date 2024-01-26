using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Taxonomy
{
    public class CategorySuggestions
    {
        public string CategoryTreeID { get; set; }
        public string CategoryTreeVersion { get; set; }
        [JsonPropertyName("categorySuggestions")]
        public CategorySuggestion[] CategorySuggestionsList { get; set; }
    }
}
