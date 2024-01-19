namespace EbaySharp.Entities.Metadata
{
    public class ReturnPolicyDestination
    {
        public bool ReturnsAcceptanceEnabled { get; set; }
        public string[] ReturnShippingCostPayers { get; set; }
        public string[] RefundMethods { get; set; }
        public ReturnPeriod[] ReturnPeriods { get; set; }
    }
}
