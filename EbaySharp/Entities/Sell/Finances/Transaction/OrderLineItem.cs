using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Finances.Transaction
{
    public class OrderLineItem
    {
        public List<Donation> Donations { get; set; }
        public Amount FeeBasisAmount { get; set; }
        public string LineItemId { get; set; }
        public List<MarketplaceFee> MarketplaceFees { get; set; }
    }
}
