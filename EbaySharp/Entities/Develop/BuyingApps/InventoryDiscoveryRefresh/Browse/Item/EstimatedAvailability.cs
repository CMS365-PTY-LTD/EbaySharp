namespace EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item
{
    public class EstimatedAvailability
    {
        public int? AvailabilityThreshold { get; set; }
        public AvailabilityThresholdEnum? AvailabilityThresholdType { get; set; }
        public List<string> DeliveryOptions { get; set; }
        public AvailabilityStatusEnum? EstimatedAvailabilityStatus { get; set; }
        public int? EstimatedAvailableQuantity { get; set; }
        public int? EstimatedRemainingQuantity { get; set; }
        public int? EstimatedSoldQuantity { get; set; }
    }
}