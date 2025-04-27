namespace EbaySharp.Entities.TraditionalSelling.Trading.GetAccount
{
    public class AccountSummary
    {
        public string AccountState { get; set; }
        public float AmountPastDue { get; set; }
        public int BillingCycleDate { get; set; }
        public float CurrentBalance { get; set; }
        public float InvoiceBalance { get; set; }
        public float LastAmountPaid { get; set; }
        public bool PastDue { get; set; }
        public string PaymentMethod { get; set; }
    }
}
