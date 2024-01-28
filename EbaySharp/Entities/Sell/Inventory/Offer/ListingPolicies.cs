namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class ListingPolicies
    {
        public BestOfferTerms BestOfferTerms { get; set; }
        public bool? EBayPlusIfEligible { get; set; }
        public string FulfillmentPolicyId { get; set; }
        public string PaymentPolicyId { get; set; }
        public string[] ProductCompliancePolicyIds { get; set; }
        public RegionalProductCompliancePolicies RegionalProductCompliancePolicies { get; set; }
        public RegionalTakeBackPolicies RegionalTakeBackPolicies { get; set; }
        public string ReturnPolicyId { get; set; }
        public List<ShippingCostOverride> ShippingCostOverrides { get; set; }
        public string TakeBackPolicyId { get; set; }
    }
}