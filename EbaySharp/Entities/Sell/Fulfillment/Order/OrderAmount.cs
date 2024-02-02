using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class OrderAmount : Amount
    {
        public CurrencyCodeEnum? ConvertedFromCurrency { get; set; }
        public string ConvertedFromValue { get; set; }
    }
}
