using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EbaySharp.Entities.Sell.Inventory.Location
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StoreTypeEnum
    {
        STORE,
        WAREHOUSE
    }
}
