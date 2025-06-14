namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Location
{
    public class OperatingHour
    {
        public DayOfWeek? DayOfWeekEnum { get; set; }
        public List<Interval> Intervals { get; set; }
    }
}
