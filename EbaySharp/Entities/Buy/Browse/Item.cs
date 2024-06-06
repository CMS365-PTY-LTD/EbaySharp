﻿using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Buy.Browse
{
    public class Item
    {
        public List<Image> AdditionalImages { get; set; }
        public List<AddonService> AddonServices { get; set; }
        public bool? AdultOnly { get; set; }
        public string AgeGroup { get; set; }
        public AuthenticityGuarantee AuthenticityGuarantee { get; set; }
        public AuthenticityVerification AuthenticityVerification { get; set; }
        public List<AvailableCoupon> AvailableCoupons { get; set; }
        public int? BidCount { get; set; }
        public string Brand { get; set; }
        public List<string> BuyingOptions { get; set; }
        public string CategoryId { get; set; }
        public string CategoryIdPath { get; set; }
        public string CategoryPath { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public string ConditionDescription { get; set; }
        public List<ConditionDescriptor> ConditionDescriptors { get; set; }
        public string ConditionId { get; set; }
        public Amount CurrentBidPrice { get; set; }
        public string Description { get; set; }
        public Amount EcoParticipationFee { get; set; }
        public bool? EligibleForInlineCheckout { get; set; }
        public bool? EnabledForGuestCheckout { get; set; }
        public string EnergyEfficiencyClass { get; set; }
        public string Epid { get; set; }
        public List<EstimatedAvailability> EstimatedAvailabilities { get; set; }
        public string Gender { get; set; }
        public string Gtin { get; set; }
        public HazardousMaterialsLabels HazardousMaterialsLabels { get; set; }
        public Image Image { get; set; }
        public string InferredEpid { get; set; }
        public string ItemAffiliateWebUrl { get; set; }
        public string ItemCreationDate { get; set; }
        public string ItemEndDate { get; set; }
        public string ItemId { get; set; }
        public Address ItemLocation { get; set; }
        public string ItemWebUrl { get; set; }
        public string LegacyItemId { get; set; }
        public MarketplaceIdEnum? ListingMarketplaceId { get; set; }
        public List<LocalizedAspect> LocalizedAspects { get; set; }
        public int? LotSize { get; set; }
        public MarketingPrice MarketingPrice { get; set; }
        public string Material { get; set; }
        public Amount MinimumPriceToBid { get; set; }
        public string Mpn { get; set; }
        public string Pattern { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public Amount Price { get; set; }
        public PriceDisplayConditionEnum? PriceDisplayCondition { get; set; }
        public PrimaryItemGroup PrimaryItemGroup { get; set; }
        public PrimaryProductReviewRating PrimaryProductReviewRating { get; set; }
        public bool? PriorityListing { get; set; }
        public Product Product { get; set; }
        public string ProductFicheWebUrl { get; set; }
        public List<string> QualifiedPrograms { get; set; }
        public int? QuantityLimitPerBuyer { get; set; }
        public string RepairScore { get; set; }
        public bool? ReservePriceMet { get; set; }
        public ReturnTerms ReturnTerms { get; set; }
        public Seller Seller { get; set; }
        public List<SellerCustomPolicy> SellerCustomPolicies { get; set; }
        public string SellerItemRevision { get; set; }
        public List<ShippingOption> ShippingOptions { get; set; }
        public ShipToLocations ShipToLocations { get; set; }
        public string ShortDescription { get; set; }
        public string Size { get; set; }
        public string SizeSystem { get; set; }
        public string SizeType { get; set; }
        public string Subtitle { get; set; }
        public List<Taxis> Taxes { get; set; }
        public string Title { get; set; }
        public bool? TopRatedBuyingExperience { get; set; }
        public string TyreLabelImageUrl { get; set; }
        public int? UniqueBidderCount { get; set; }
        public Amount UnitPrice { get; set; }
        public string UnitPricingMeasure { get; set; }
        public List<Warning> Warnings { get; set; }
        public int? WatchCount { get; set; }
    }
}
