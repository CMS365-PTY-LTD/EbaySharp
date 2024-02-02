using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class FulfillmentStartInstruction
    {
        public string DestinationTimeZone { get; set; }
        public bool? EbaySupportedFulfillment { get; set; }
        public Address FinalDestinationAddress { get; set; }
        public FulfillmentInstructionsType? FulfillmentInstructionsType { get; set; }
        public string MaxEstimatedDeliveryDate { get; set; }
        public string MinEstimatedDeliveryDate { get; set; }
        public PickupStep PickupStep { get; set; }
        public ShippingStep ShippingStep { get; set; }
    }
}