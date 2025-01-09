namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class LineItemFulfillmentInstructions
    {
        public string DestinationTimeZone { get; set; }
        public bool? GuaranteedDelivery { get; set; }
        public string MaxEstimatedDeliveryDate { get; set; }
        public string MinEstimatedDeliveryDate { get; set; }
        public string ShipByDate { get; set; }
        public string SourceTimeZone { get; set; }
    }
}