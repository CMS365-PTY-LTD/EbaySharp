using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class LinkedOrderLineItem
    {
        public List<Parameter> LineItemAspects { get; set; }
        public string LineItemId { get; set; }
        public string MaxEstimatedDeliveryDate { get; set; }
        public string MinEstimatedDeliveryDate { get; set; }
        public string OrderId { get; set; }
        public string SellerId { get; set; }
        public List<Shipment> Shipments { get; set; }
        public string Title { get; set; }
    }
}