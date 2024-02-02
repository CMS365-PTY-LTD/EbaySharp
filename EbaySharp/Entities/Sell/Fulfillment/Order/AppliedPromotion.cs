namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class AppliedPromotion
    {
        public string Description { get; set; }
        public OrderAmount DiscountAmount { get; set; }
        public string PromotionId { get; set; }
    }
}