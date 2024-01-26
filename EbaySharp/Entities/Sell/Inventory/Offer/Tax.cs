namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class Tax
    {
        public bool ApplyTax { get; set; }
        public string ThirdPartyTaxCategory { get; set; }
        public int VatPercentage { get; set; }
    }
}