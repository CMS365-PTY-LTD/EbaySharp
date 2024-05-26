namespace EbaySharp.Entities.Common
{
    public class Amount
    {
        public CurrencyCodeEnum? Currency { get; set; }
        public string Value { get; set; }
        public CurrencyCodeEnum? ConvertedFromCurrency { get; set; }
        public string ConvertedFromValue { get; set; }
        public CurrencyCodeEnum? ConvertedToCurrency { get; set; }
        public string ConvertedToValue { get; set; }
        public string ExchangeRate { get; set; }
    }
}
