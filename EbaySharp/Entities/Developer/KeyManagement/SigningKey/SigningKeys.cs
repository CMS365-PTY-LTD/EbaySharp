using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Developer.KeyManagement.SigningKey
{
    public class SigningKeys
    {
        [JsonPropertyName("signingKeys")]
        public SigningKey[] SigningKeyList { get; set; }
    }
}
