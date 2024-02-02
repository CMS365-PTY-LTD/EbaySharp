namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class AuthenticityVerification
    {
        public AuthenticityVerificationReasonEnum? OutcomeReason { get; set; }
        public AuthenticityVerificationStatusEnum? Status { get; set; }
    }
}