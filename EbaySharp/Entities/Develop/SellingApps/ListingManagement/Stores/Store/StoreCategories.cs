using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Stores.Store
{
    public class StoreCategories
    {
        [JsonPropertyName("storeCategories")]
        public List<StoreCategory> StoreCategoriesList { get; set; }
    }
}
