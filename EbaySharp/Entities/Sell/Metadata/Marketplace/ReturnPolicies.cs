using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Sell.Metadata.Marketplace
{
    public class ReturnPolicies
    {
        [JsonPropertyName("returnPolicies")]
        public ReturnPolicy[] ReturnPolicyList { get; set; }
    }
}
