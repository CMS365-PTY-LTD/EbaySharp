namespace EbaySharp.Entities.Taxonomy
{
    public class CategorySuggestionsList
    {
        public string CategoryTreeID { get; set; }
        public string CategoryTreeVersion { get; set; }
        public CategorySuggestion[] CategorySuggestions { get; set; }
    }
}
