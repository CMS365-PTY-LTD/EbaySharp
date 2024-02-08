namespace EbaySharp.Entities.Commerce.Taxonomy
{
    public class RootCategoryNode
    {
        public Category Category { get; set; }
        public ChildCategoryTreeNode[] ChildCategoryTreeNodes { get; set; }
    }
}
