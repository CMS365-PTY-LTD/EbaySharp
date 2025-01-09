namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class ShippingStep
    {
        public string ShippingCarrierCode { get; set; }
        public string ShippingServiceCode { get; set; }
        public ShipTo ShipTo { get; set; }
        public string ShipToReferenceId { get; set; }
    }
}