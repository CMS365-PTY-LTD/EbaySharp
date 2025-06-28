namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order.ShippingFulfillment
{
    public class Fulfillment : Shipment
    {
        public string FulfillmentId { get; set; }
        public List<LineItem> LineItems { get; set; }
        public string ShippedDate { get; set; }
    }
}
