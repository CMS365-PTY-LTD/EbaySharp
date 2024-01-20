using EbaySharp.Entities.Identity;
using Newtonsoft.Json;
using System.Text;

namespace EbaySharp.Controllers
{
    public class IdentityController
    {
        public async Task<ClientCredentialsResponse> GetClientCredentials(string clinetId, string clientSecret, string refreshToken, string scope)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.ebay.com/identity/v1/oauth2/token");

            string authorizationCode = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clinetId}:{clientSecret}"));
            request.Headers.Add("Authorization", $"Basic {authorizationCode}");
            var collection = new List<KeyValuePair<string, string>>
            {
                new("grant_type", "refresh_token"),
                new("refresh_token",refreshToken),
                new("scope", scope)
            };
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrEmpty(responseContent))
                {
                    throw new Exception("No content found.");
                }
                return JsonConvert.DeserializeObject<ClientCredentialsResponse>(responseContent);
            }
            throw new Exception($"Error, {response.Content}");
        }
    }
}
