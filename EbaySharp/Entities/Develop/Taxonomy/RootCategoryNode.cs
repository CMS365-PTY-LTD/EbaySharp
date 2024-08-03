namespace EbaySharp.Entities.Develop.Taxonomy
{
    public class RootCategoryNode
    {
        public Category Category { get; set; }
        public ChildCategoryTreeNode[] ChildCategoryTreeNodes { get; set; }
    }
}
