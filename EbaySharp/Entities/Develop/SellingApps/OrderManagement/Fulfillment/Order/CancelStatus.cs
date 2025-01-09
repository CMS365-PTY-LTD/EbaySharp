namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class CancelStatus
    {
        public string CancelledDate { get; set; }
        public List<CancelRequest> CancelRequests { get; set; }
        public CancelStateEnum CancelState { get; set; }
    }
}