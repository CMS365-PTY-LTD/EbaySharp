using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Buy.Browse
{
    public class EconomicOperator: Address
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}