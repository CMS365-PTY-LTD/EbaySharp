namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class Hazmat
    {
        public string Component { get; set; }
        public List<string> Pictograms { get; set; }
        public string SignalWord { get; set; }
        public List<string> Statements { get; set; }
    }
}