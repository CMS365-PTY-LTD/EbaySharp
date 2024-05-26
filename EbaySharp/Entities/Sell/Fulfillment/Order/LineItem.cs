using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class LineItem
    {
        public List<AppliedPromotion> AppliedPromotions { get; set; }
        public DeliveryCost DeliveryCost { get; set; }
        public Amount DiscountedLineItemCost { get; set; }
        public List<EbayCollectAndRemitTaxis> EbayCollectAndRemitTaxes { get; set; }
        public EbayCollectedCharges EbayCollectedCharges { get; set; }
        public GiftDetails GiftDetails { get; set; }
        public ItemLocation ItemLocation { get; set; }
        public string LegacyItemId { get; set; }
        public string LegacyVariationId { get; set; }
        public Amount LineItemCost { get; set; }
        public LineItemFulfillmentInstructions LineItemFulfillmentInstructions { get; set; }
        public LineItemFulfillmentStatusEnum? LineItemFulfillmentStatus { get; set; }
        public string LineItemId { get; set; }
        public List<LinkedOrderLineItem> LinkedOrderLineItems { get; set; }
        public MarketplaceIdEnum? ListingMarketplaceId { get; set; }
        public Properties Properties { get; set; }
        public MarketplaceIdEnum? PurchaseMarketplaceId { get; set; }
        public int Quantity { get; set; }
        public List<Refund> Refunds { get; set; }
        public string SKU { get; set; }
        public SoldFormatEnum? SoldFormat { get; set; }
        public List<Taxis> Taxes { get; set; }
        public string Title { get; set; }
        public Amount Total { get; set; }
        public List<Parameter> VariationAspects { get; set; }
    }
}
