namespace EbaySharp.Entities.Taxonomy
{
    public class CategorySuggestions
    {
        public string CategoryTreeID { get; set; }
        public string CategoryTreeVersion { get; set; }
        public CategorySuggestion[] CategorySuggestionsList { get; set; }
    }
}
