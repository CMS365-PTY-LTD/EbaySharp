﻿namespace EbaySharp.Entities.Develop.Taxonomy
{
    public class CategoryTreeNodeAncestor
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryTreeNodeLevel { get; set; }
        public string CategorySubtreeNodeHref { get; set; }
    }
}
