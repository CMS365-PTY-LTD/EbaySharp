namespace EbaySharp.Entities.Sell.Stores.Store
{
    public class StoreCategory
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ChildrenCategory> ChildrenCategories { get; set; }
        public int? Level { get; set; }
        public int? Order { get; set; }
    }
}
