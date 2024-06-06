namespace EbaySharp.Entities.Buy.Browse
{
    public class ReturnTerms
    {
        public bool? ExtendedHolidayReturnsOffered { get; set; }
        public RefundMethodEnum? RefundMethod { get; set; }
        public string RestockingFeePercentage { get; set; }
        public string ReturnInstructions { get; set; }
        public ReturnMethodEnum? ReturnMethod { get; set; }
        public ReturnPeriod ReturnPeriod { get; set; }
        public bool? ReturnsAccepted { get; set; }
        public ReturnShippingCostPayerEnum? ReturnShippingCostPayer { get; set; }
    }
}