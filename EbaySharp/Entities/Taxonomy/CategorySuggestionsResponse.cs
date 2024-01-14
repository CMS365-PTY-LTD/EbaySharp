namespace EbaySharp.Entities.Taxonomy
{
    public class CategorySuggestionsResponse
    {
        public string CategoryTreeId { get; set; }
        public string CategoryTreeVersion { get; set; }
        public CategorySuggestion[] CategorySuggestions { get; set; }
    }
}
