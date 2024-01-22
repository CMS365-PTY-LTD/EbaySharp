namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class Offer
    {
        public string AvailableQuantity { get; set; }
        public string CategoryID { get; set; }
        public Charity Charity { get; set; }
        public ExtendedProducerResponsibility ExtendedProducerResponsibility { get; set; }
        public string Format { get; set; }
        public string HIDeBuyerDetails { get; set; }
        public string IncludeCatalogProductDetails { get; set; }
        public Listing Listing { get; set; }
        public string ListingDescription { get; set; }
        public string ListingDuration { get; set; }
        public ListingPolicies ListingPolicies { get; set; }
        public string ListingStartDate { get; set; }
        public string LotSize { get; set; }
        public string MarketplaceID { get; set; }
        public string MerchantLocationKey { get; set; }
        public string OfferID { get; set; }
        public PricingSummary PricingSummary { get; set; }
        public string QuantityLimitPerBuyer { get; set; }
        public Regulatory Regulatory { get; set; }
        public string SecondaryCategoryID { get; set; }
        public string Sku { get; set; }
        public string Status { get; set; }
        public List<string> StoreCategoryNames { get; set; }
        public Tax Tax { get; set; }
    }
}
