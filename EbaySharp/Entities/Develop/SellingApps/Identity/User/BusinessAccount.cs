using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.Identity.User
{
    public class BusinessAccount
    {
        public Address Address { get; set; }
        public string DoingBusinessAs { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Contact PrimaryContact { get; set; }
        public Phone PrimaryPhone { get; set; }
        public Phone SecondaryPhone { get; set; }
        public string Website { get; set; }
    }
}
