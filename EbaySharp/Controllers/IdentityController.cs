using EbaySharp.Entities.Identity;
using EbaySharp.Source;
using Newtonsoft.Json;
using System.Text;

namespace EbaySharp.Controllers
{
    public class IdentityController
    {
        public async Task<ClientCredentialsResponse> GetClientCredentials(string clinetId, string clientSecret)
        {
            var client = Helpers.GetHttpClient();
            string requestUrl = $"{Constants.SERVER_URL}/{Constants.IDENTITY.ENDPOINT_URL}/{Constants.IDENTITY.METHODS.TOKEN}";
            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            var clientCreds = Encoding.UTF8.GetBytes($"{clinetId}:{clientSecret}");
            request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(clientCreds)}");
            var collection = new List<KeyValuePair<string, string>>
            {
                new("grant_type", "client_credentials"),
                new("scope", "https://api.ebay.com/oauth/api_scope")
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
