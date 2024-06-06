using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Buy.Browse
{
    public class ShippingOption
    {
        public Amount AdditionalShippingCostPerUnit { get; set; }
        public string CutOffDateUsedForEstimate { get; set; }
        public FulfilledThroughEnum? FulfilledThrough { get; set; }
        public bool? GuaranteedDelivery { get; set; }
        public Amount ImportCharges { get; set; }
        public string MaxEstimatedDeliveryDate { get; set; }
        public string MinEstimatedDeliveryDate { get; set; }
        public int? QuantityUsedForEstimate { get; set; }
        public string ShippingCarrierCode { get; set; }
        public Amount ShippingCost { get; set; }
        public string ShippingCostType { get; set; }
        public string ShippingServiceCode { get; set; }
        public ShipToLocationUsedForEstimate ShipToLocationUsedForEstimate { get; set; }
        public string TrademarkSymbol { get; set; }
        public string Type { get; set; }
    }
}