namespace EbaySharp.Entities.Sell.Inventory.Location
{
    public class OperatingHour
    {
        public DayOfWeek DayOfWeekEnum { get; set; }
        public List<Interval> Intervals { get; set; }
    }
}
