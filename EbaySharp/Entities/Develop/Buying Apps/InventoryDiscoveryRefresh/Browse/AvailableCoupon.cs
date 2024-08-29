using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Buy.Browse
{
    public class AvailableCoupon
    {
        public Constraint Constraint { get; set; }
        public Amount DiscountAmount { get; set; }
        public CouponDiscountTypeEnum? DiscountType { get; set; }
        public string Message { get; set; }
        public string RedemptionCode { get; set; }
        public string TermsWebUrl { get; set; }
    }
}