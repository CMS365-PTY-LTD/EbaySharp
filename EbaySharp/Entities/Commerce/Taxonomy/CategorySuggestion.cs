namespace EbaySharp.Entities.Commerce.Taxonomy
{
    public class CategorySuggestion
    {
        public Category Category { get; set; }
        public int CategoryTreeNodeLevel { get; set; }
        public CategoryTreeNodeAncestor[] CategoryTreeNodeAncestors { get; set; }
    }
}
