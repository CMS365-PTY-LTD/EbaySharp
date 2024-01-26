namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class Listing
    {
        public string ListingID { get; set; }
        public bool ListingOnHold { get; set; }
        public ListingStatusEnum ListingStatus { get; set; }
        public int SoldQuantity { get; set; }
    }
}
