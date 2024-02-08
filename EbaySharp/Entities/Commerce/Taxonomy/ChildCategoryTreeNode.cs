namespace EbaySharp.Entities.Commerce.Taxonomy
{
    public class ChildCategoryTreeNode
    {
        public Category Category { get; set; }
        public string ParentCategoryTreeNodeHref { get; set; }
        public ChildCategoryTreeNode[] ChildCategoryTreeNodes { get; set; }
        public int CategoryTreeNodeLevel { get; set; }
        public bool LeafCategoryTreeNode { get; set; }
    }
}
