namespace EbaySharp.Entities.Sell.Metadata.Marketplace
{
    public class ReturnPolicy
    {
        public string CategoryTreeId { get; set; }
        public string CategoryId { get; set; }
        public ReturnPolicyDestination Domestic { get; set; }
        public ReturnPolicyDestination International { get; set; }
    }
}
