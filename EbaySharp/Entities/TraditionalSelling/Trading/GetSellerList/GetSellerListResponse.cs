namespace EbaySharp.Entities.TraditionalSelling.Trading.GetSellerList
{
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ebay:apis:eBLBaseComponents")]
    [System.Xml.Serialization.XmlRoot(Namespace = "urn:ebay:apis:eBLBaseComponents", IsNullable = false)]
    public partial class GetSellerListResponse
    {
        [System.Xml.Serialization.XmlArrayItem("Item", IsNullable = false)]
        public List<Item> ItemArray { get; set; }
        public string Ack { get; set; }
        public bool HasMoreItems { get; set; }
        public int ItemsPerPage { get; set; }
        public PaginationResult PaginationResult { get; set; }
        public Errors Errors { get; set; }

    }
}
