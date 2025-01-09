namespace EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item
{
    public class PaymentMethod
    {
        public PaymentMethodTypeEnum? PaymentMethodType { get; set; }
        public List<PaymentMethodBrand> PaymentMethodBrands { get; set; }
        public List<string> PaymentInstructions { get; set; }
        public List<string> SellerInstructions { get; set; }
    }
}