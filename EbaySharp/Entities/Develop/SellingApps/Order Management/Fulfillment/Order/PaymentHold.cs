using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class PaymentHold
    {
        public string ExpectedReleaseDate { get; set; }
        public Amount HoldAmount { get; set; }
        public string HoldReason { get; set; }
        public string HoldState { get; set; }
        public string ReleaseDate { get; set; }
        public List<SellerActionsToRelease> SellerActionsToRelease { get; set; }
    }
}