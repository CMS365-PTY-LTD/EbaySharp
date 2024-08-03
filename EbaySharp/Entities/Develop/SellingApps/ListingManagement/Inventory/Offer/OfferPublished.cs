using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Offer
{
    public class OfferPublished
    {
        public string ListingId { get; set; }
        public Warning[] Warnings { get; set; }
    }
}
