namespace EbaySharp.Entities.Sell.Metadata.Marketplace
{
    public class ReturnPolicy
    {
        public string CategoryTreeID { get; set; }
        public string CategoryID { get; set; }
        public ReturnPolicyDestination Domestic { get; set; }
        public ReturnPolicyDestination International { get; set; }
    }
}
