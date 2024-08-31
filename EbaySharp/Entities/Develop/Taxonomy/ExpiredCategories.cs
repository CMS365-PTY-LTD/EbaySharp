using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.Taxonomy
{
    public class ExpiredCategories
    {
        [JsonPropertyName("expiredCategories")]
        public ExpiredCategory[] expiredCategories { get; set; }
    }
}
