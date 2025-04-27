namespace EbaySharp.Entities.TraditionalSelling.Trading.GetAccount
{
    public class AccountEntry
    {
        public string AccountDetailsEntryType { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public float GrossDetailAmount { get; set; }
        public long ItemID { get; set; }
        public string Memo { get; set; }
        public float NetDetailAmount { get; set; }
        public long RefNumber { get; set; }
        public float VATPercent { get; set; }
        public string Title { get; set; }
        public string OrderLineItemID { get; set; }
        public long TransactionID { get; set; }
        public string OrderId { get; set; }
    }
}
