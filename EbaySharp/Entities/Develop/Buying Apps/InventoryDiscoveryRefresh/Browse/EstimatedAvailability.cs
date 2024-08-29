namespace EbaySharp.Entities.Buy.Browse
{
    public class EstimatedAvailability
    {
        public int? AvailabilityThreshold { get; set; }
        public AvailabilityThresholdEnum? AvailabilityThresholdType { get; set; }
        public List<string> DeliveryOptions { get; set; }
        public AvailabilityStatusEnum? EstimatedAvailabilityStatus { get; set; }
        public int? EstimatedAvailableQuantity { get; set; }
        public int? EstimatedSoldQuantity { get; set; }
    }
}