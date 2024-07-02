using EbaySharp.Entities.Developer.KeyManagement.SigningKey;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.ComponentModel.Design;
using System.Text;
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
        public static void GenerateEbaySignatureHeader(this HttpRequestMessage request, HttpMethod httpMethod, string requestUrl, SigningKey signingKey)
        {
            // Extract method, path, and authority from the request URL and HTTP method
            string method = httpMethod.Method.ToUpper();
            Uri uri = new(requestUrl);
            string path = uri.AbsolutePath;
            string authority = uri.Host;

            // Generate the current Unix timestamp
            long unixTimeNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            // Create the signature input string
            string signatureParams = $"(\"x-ebay-signature-key\" \"@method\" \"@path\" \"@authority\");created={unixTimeNow}";

            // Create the signature base string
            string signatureBase =
                $"\"x-ebay-signature-key\": {signingKey.JWE}\n" +
                $"\"@method\": {method}\n" +
                $"\"@path\": {path}\n" +
                $"\"@authority\": {authority}\n" +
                $"\"@signature-params\": {signatureParams}";

            byte[] signatureBaseBytes = Encoding.UTF8.GetBytes(signatureBase);

            // Convert private key from base64 and load the private key
            string privKeyString = $"-----BEGIN PRIVATE KEY-----\n{signingKey.PrivateKey}\n-----END PRIVATE KEY-----";
            PemReader pemReader = new(new StringReader(privKeyString));
            AsymmetricKeyParameter pemPrivKey = (AsymmetricKeyParameter)pemReader.ReadObject();

            // Sign the signature base string
            ISigner signer = SignerUtilities.GetSigner(signingKey.SigningKeyCipher.ToString());
            signer.Init(true, pemPrivKey);
            signer.BlockUpdate(signatureBaseBytes, 0, signatureBaseBytes.Length);
            byte[] signedSignatureBytes = signer.GenerateSignature();
            string signatureBase64 = Convert.ToBase64String(signedSignatureBytes);

            // Verify 
            string pubKeyString = $"-----BEGIN PUBLIC KEY-----\n{signingKey.PublicKey}\n-----END PUBLIC KEY-----";
            PemReader pemPubReader = new(new StringReader(pubKeyString));
            AsymmetricKeyParameter pemPubKey = (AsymmetricKeyParameter)pemPubReader.ReadObject();
            ISigner verifier = SignerUtilities.GetSigner(signingKey.SigningKeyCipher.ToString());
            verifier.Init(false, pemPubKey);
            verifier.BlockUpdate(signatureBaseBytes, 0, signatureBaseBytes.Length);
            bool verified = verifier.VerifySignature(signedSignatureBytes);
            if (!verified) throw new InvalidOperationException("Signature verification failed");

            // Add Signature and Signature-Input headers to the request
            request.Headers.Add("Signature", $"sig1=:{signatureBase64}:");
            request.Headers.Add("Signature-Input", $"sig1={signatureParams}");
            request.Headers.Add("x-ebay-signature-key", signingKey.JWE);
            request.Headers.Add("x-ebay-enforce-signature", "true");
        }
    }
}
