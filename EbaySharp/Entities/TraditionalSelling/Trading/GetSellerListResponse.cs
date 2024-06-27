using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.TraditionalSelling.Trading
{
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ebay:apis:eBLBaseComponents")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:ebay:apis:eBLBaseComponents", IsNullable = false)]
    public partial class GetSellerListResponse
    {
        [System.Xml.Serialization.XmlArrayItemAttribute("Item", IsNullable = false)]
        public List<LegacyItem> ItemArray { get; set; }
        public string Ack { get; set; }
        public bool HasMoreItems { get; set; }
        public int ItemsPerPage { get; set; }
        public PaginationResult PaginationResult { get; set; }
        public Errors Errors { get; set; }
        
    }
}
