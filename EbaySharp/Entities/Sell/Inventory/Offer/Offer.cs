using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class Offer
    {
        public string CategoryId { get; set; }
        public Charity Charity { get; set; }
        public ExtendedProducerResponsibility ExtendedProducerResponsibility { get; set; }
        public FormatTypeEnum? Format { get; set; }
        public bool? HideBuyerDetails { get; set; }
        public bool? IncludeCatalogProductDetails { get; set; }
        public Listing Listing { get; set; }
        public string ListingDescription { get; set; }
        public ListingDurationEnum? ListingDuration { get; set; }
        public ListingPolicies ListingPolicies { get; set; }
        public string ListingStartDate { get; set; }
        public int? LotSize { get; set; }
        public MarketplaceEnum? MarketplaceId { get; set; }
        public string MerchantLocationKey { get; set; }
        public string OfferId { get; set; }
        public PricingSummary PricingSummary { get; set; }
        public int? QuantityLimitPerBuyer { get; set; }
        public Regulatory Regulatory { get; set; }
        public string SecondaryCategoryId { get; set; }
        public string SKU { get; set; }
        public OfferStatusEnum? Status { get; set; }
        public string[] StoreCategoryNames { get; set; }
        public Tax Tax { get; set; }
    }
}
