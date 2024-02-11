using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Commerce.Taxonomy
{
    public class CategorySuggestions
    {
        public string CategoryTreeId { get; set; }
        public string CategoryTreeVersion { get; set; }
        [JsonPropertyName("categorySuggestions")]
        public CategorySuggestion[] CategorySuggestionList { get; set; }
    }
}
