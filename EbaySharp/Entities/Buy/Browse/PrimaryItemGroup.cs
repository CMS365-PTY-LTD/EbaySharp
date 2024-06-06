﻿namespace EbaySharp.Entities.Buy.Browse
{
    public class PrimaryItemGroup
    {
        public List<Image> ItemGroupAdditionalImages { get; set; }
        public string ItemGroupHref { get; set; }
        public string ItemGroupId { get; set; }
        public Image ItemGroupImage { get; set; }
        public string ItemGroupTitle { get; set; }
        public ItemGroupTypeEnum? ItemGroupType { get; set; }
    }
}