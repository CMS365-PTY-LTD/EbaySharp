using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item
{
    public class SellerLegalInfo
    {
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Imprint { get; set; }
        public string LegalContactFirstName { get; set; }
        public string LegalContactLastName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string RegistrationNumber { get; set; }
        public Address SellerProvidedLegalAddress { get; set; }
        public string TermsOfService { get; set; }
        public List<VatDetail> VatDetails { get; set; }
        public EconomicOperator EconomicOperator { get; set; }
        public string WeeeNumber { get; set; }
    }
}