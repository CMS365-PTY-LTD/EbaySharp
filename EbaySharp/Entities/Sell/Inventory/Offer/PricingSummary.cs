using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class PricingSummary
    {
        public Amount AuctionReservePrice { get; set; }
        public Amount AuctionStartPrice { get; set; }
        public Amount MinimumAdvertisedPrice { get; set; }
        public SoldOnEnum? OriginallySoldForRetailPriceOn { get; set; }
        public Amount OriginalRetailPrice { get; set; }
        public Amount Price { get; set; }
        public MinimumAdvertisedPriceHandlingEnum? PricingVisibility { get; set; }
    }
}