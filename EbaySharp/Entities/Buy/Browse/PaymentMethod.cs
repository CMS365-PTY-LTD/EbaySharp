namespace EbaySharp.Entities.Buy.Browse
{
    public class PaymentMethod
    {
        public PaymentMethodTypeEnum? PaymentMethodType { get; set; }
        public List<PaymentMethodBrand> PaymentMethodBrands { get; set; }
        public List<string> PaymentInstructions { get; set; }
        public List<string> SellerInstructions { get; set; }
    }
}