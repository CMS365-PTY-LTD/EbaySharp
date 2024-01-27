using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class Offer
    {
        public int AvailableQuantity { get; set; }
        public string CategoryID { get; set; }
        public Charity Charity { get; set; }
        public ExtendedProducerResponsibility ExtendedProducerResponsibility { get; set; }
        public FormatTypeEnum Format { get; set; }
        public bool HIDeBuyerDetails { get; set; }
        public bool IncludeCatalogProductDetails { get; set; }
        public Listing Listing { get; set; }
        public string ListingDescription { get; set; }
        public ListingDurationEnum ListingDuration { get; set; }
        public ListingPolicies ListingPolicies { get; set; }
        public string ListingStartDate { get; set; }
        public int LotSize { get; set; }
        public MarketplaceEnum MarketplaceID { get; set; }
        public string MerchantLocationKey { get; set; }
        public string OfferID { get; set; }
        public PricingSummary PricingSummary { get; set; }
        public int QuantityLimitPerBuyer { get; set; }
        public Regulatory Regulatory { get; set; }
        public string SecondaryCategoryID { get; set; }
        public string SKU { get; set; }
        public OfferStatusEnum Status { get; set; }
        public string[] StoreCategoryNames { get; set; }
        public Tax Tax { get; set; }
    }
}
