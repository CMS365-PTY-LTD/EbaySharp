namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class CancelRequest
    {
        public string CancelCompletedDate { get; set; }
        public string CancelInitiator { get; set; }
        public string CancelReason { get; set; }
        public string CancelRequestedDate { get; set; }
        public string CancelRequestId { get; set; }
        public CancelRequestStateEnum? CancelRequestState { get; set; }
    }
}