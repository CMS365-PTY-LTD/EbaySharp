using Newtonsoft.Json;

namespace EbaySharp.Entities.Taxonomy
{
    public class CategorySuggestions
    {
        public string CategoryTreeID { get; set; }
        public string CategoryTreeVersion { get; set; }
        [JsonProperty("categorySuggestions")]
        public CategorySuggestion[] CategorySuggestionsList { get; set; }
    }
}
