using EbaySharp.Entities.Common;
using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.SellingApps.SellingMetadata.Metadata.Marketplace
{
    public class ReturnPolicies
    {
        [JsonPropertyName("returnPolicies")]
        public ReturnPolicy[] ReturnPolicyList { get; set; }
        public Warning[] Warnings { get; set; }
    }
}
