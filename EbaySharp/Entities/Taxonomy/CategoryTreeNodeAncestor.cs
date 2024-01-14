namespace EbaySharp.Entities.Taxonomy
{
    public class CategoryTreeNodeAncestor
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryTreeNodeLevel { get; set; }
        public string CategorySubtreeNodeHref { get; set; }
    }
}
