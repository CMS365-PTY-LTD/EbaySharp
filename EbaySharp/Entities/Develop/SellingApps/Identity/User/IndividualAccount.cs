using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.Identity.User
{
    public class IndividualAccount
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Phone PrimaryPhone { get; set; }
        public Address RegistrationAddress { get; set; }
        public Phone SecondaryPhone { get; set; }
    }
}
