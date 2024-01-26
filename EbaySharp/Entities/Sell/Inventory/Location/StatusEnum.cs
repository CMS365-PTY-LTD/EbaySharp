using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Sell.Inventory.Location
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        DISABLED,
        ENABLED
    }
}
