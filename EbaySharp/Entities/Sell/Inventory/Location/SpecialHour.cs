namespace EbaySharp.Entities.Sell.Inventory.Location
{
    public class SpecialHour
    {
        public string Date { get; set; }
        public List<Interval> Intervals { get; set; }
    }
}
