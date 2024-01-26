namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class ListingPolicies
    {
        public BestOfferTerms BestOfferTerms { get; set; }
        public bool EBayPlusIfEligible { get; set; }
        public string FulfillmentPolicyID { get; set; }
        public string PaymentPolicyID { get; set; }
        public List<string> ProductCompliancePolicyIDs { get; set; }
        public RegionalProductCompliancePolicies RegionalProductCompliancePolicies { get; set; }
        public RegionalTakeBackPolicies RegionalTakeBackPolicies { get; set; }
        public string ReturnPolicyID { get; set; }
        public List<ShippingCostOverride> ShippingCostOverrides { get; set; }
        public string TakeBackPolicyID { get; set; }
    }
}