namespace EbaySharp.Entities.Sell.Fulfillment.Order.ShippingFulfillment
{
    public class Fulfillment
    {
        public string FulfillmentId { get; set; }
        public List<LineItem> LineItems { get; set; }
        public string ShipmentTrackingNumber { get; set; }
        public string ShippedDate { get; set; }
        public string ShippingCarrierCode { get; set; }
    }
}
