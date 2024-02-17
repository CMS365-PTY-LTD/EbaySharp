using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class OfferUpdated
    {
        public string OfferId { get; set; }
        public Warning[] Warnings { get; set; }
    }
}
