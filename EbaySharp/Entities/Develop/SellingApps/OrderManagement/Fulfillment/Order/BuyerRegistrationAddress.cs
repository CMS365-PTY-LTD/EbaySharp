using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class BuyerRegistrationAddress
    {
        public string CompanyName { get; set; }
        public Address ContactAddress { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public PrimaryPhone PrimaryPhone { get; set; }
    }
}
