﻿namespace EbaySharp.Entities.Taxonomy
{
    public class CategoryTreeResponse
    {
        public string CategoryTreeID { get; set; }
        public string CategoryTreeVersion { get; set; }
        public RootCategoryNode RootCategoryNode { get; set; }
    }
}
