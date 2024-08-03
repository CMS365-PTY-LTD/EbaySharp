using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Location
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        DISABLED,
        ENABLED
    }
}
