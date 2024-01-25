namespace EbaySharp.Entities.Sell.Inventory.Location
{
    public class OperatingHour
    {
        public string DayOfWeekEnum { get; set; }
        public List<Interval> Intervals { get; set; }
    }
}
