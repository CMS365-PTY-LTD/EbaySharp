namespace EbaySharp.Entities.TraditionalSelling.Trading.GetAccount
{
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:ebay:apis:eBLBaseComponents")]
    [System.Xml.Serialization.XmlRoot(Namespace = "urn:ebay:apis:eBLBaseComponents", IsNullable = false)]
    public partial class GetAccountResponse
    {
        public string Ack { get; set; }
        public string AccountID { get; set; }
        public AccountSummary AccountSummary { get; set; }
        public string Currency { get; set; }
        [System.Xml.Serialization.XmlArrayItem("AccountEntry", IsNullable = false)]
        public List<AccountEntry> AccountEntries { get; set; }
        public PaginationResult PaginationResult { get; set; }
        public bool HasMoreEntries { get; set; }
        public int EntriesPerPage { get; set; }
        public int PageNumber { get; set; }
        public Errors Errors { get; set; }

    }
}
