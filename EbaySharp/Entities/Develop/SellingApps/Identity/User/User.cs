namespace EbaySharp.Entities.Develop.SellingApps.Identity.User
{
    public class User
    {
        public string AccountType { get; set; }
        public BusinessAccount BusinessAccount { get; set; }
        public IndividualAccount IndividualAccount { get; set; }
        public string RegistrationMarketplaceId { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
    }
}
