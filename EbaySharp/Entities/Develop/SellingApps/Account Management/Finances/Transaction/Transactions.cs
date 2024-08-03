using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Sell.Finances.Transaction
{
    public class Transactions
    {
        public string Href { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public string Prev { get; set; }
        public int Total { get; set; }
        [JsonPropertyName("transactions")]
        public List<Transaction> TransactionList { get; set; }
    }
}
