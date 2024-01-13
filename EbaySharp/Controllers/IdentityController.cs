using EbaySharp.Entities.Identity;
using EbaySharp.Source;
using Newtonsoft.Json;
using System.Text;

namespace EbaySharp.Controllers
{
    public class IdentityController
    {
        //private string clinetId;
        //private string clientSecret;
        //public IdentityController(string clinetId, string clientSecret) {
        //    this.clinetId = clinetId;
        //    this.clientSecret = clientSecret;
        //}
        public async Task<ClientCredentials> GetClientCredentials(string clinetId, string clientSecret)
        {
            var client = Helpers.GetHttpClient();
            string requestUrl = $"{Constants.SERVER_URL}/{Constants.IDENTITY.ENDPOINT_URL}/{Constants.IDENTITY.METHODS.TOKEN}";
            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            var clientCreds = Encoding.UTF8.GetBytes($"{clinetId}:{clientSecret}");
            request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(clientCreds)}");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("grant_type", "client_credentials"));
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
                return JsonConvert.DeserializeObject<ClientCredentials>(responseContent);
            }
            throw new Exception($"Error, {response.Content}");
        }
    }
}
