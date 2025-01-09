using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class Buyer
    {
        public BuyerRegistrationAddress BuyerRegistrationAddress { get; set; }
        public Address TaxAddress { get; set; }
        public TaxIdentifier TaxIdentifier { get; set; }
        public string Username { get; set; }
    }
}
