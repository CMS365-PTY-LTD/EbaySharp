using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class AppliedPromotion
    {
        public string Description { get; set; }
        public Amount DiscountAmount { get; set; }
        public string PromotionId { get; set; }
    }
}