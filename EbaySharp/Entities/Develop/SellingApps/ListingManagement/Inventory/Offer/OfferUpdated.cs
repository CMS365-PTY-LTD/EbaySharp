using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Offer
{
    public class OfferUpdated
    {
        public string OfferId { get; set; }
        public Warning[] Warnings { get; set; }
    }
}
