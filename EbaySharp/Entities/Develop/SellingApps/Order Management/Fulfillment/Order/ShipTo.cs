using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class ShipTo
    {
        public string CompanyName { get; set; }
        public Address ContactAddress { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public PrimaryPhone PrimaryPhone { get; set; }
    }
}