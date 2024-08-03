namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Stores.Store
{
    public class ChildrenCategory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ChildrenCategory> ChildrenCategories { get; set; }
        public int? Level { get; set; }
        public int? Order { get; set; }
    }
}
