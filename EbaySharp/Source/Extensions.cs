using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EbaySharp.Source
{
    internal static class Extensions
    {
        public static string SerializeToJson(this Object entity)
        {
            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Serialize(entity, options);
        }
        public static T DeserializeToObject<T>(this string json)
        {
            JsonSerializerOptions options = new();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
