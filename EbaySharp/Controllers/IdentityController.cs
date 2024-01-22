using EbaySharp.Entities.Identity;
using EbaySharp.Source;
using System.Text;
using System.Web;

namespace EbaySharp.Controllers
{
    public class IdentityController
    {
        public async Task<string> GetRefreshTokenAsync(string clinetId, string clientSecret, string authSuccessPageURL, string RUName)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.IDENTITY.ENDPOINT_URL}{Constants.IDENTITY.METHODS.TOKEN}";
            string authorizationCode = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clinetId}:{clientSecret}"));
            var parsed = HttpUtility.ParseQueryString(authSuccessPageURL);
            var collection = new List<KeyValuePair<string, string>>
            {
                new("redirect_uri", RUName),
                new("grant_type", "authorization_code"),
                new("code",HttpUtility.UrlDecode(parsed["code"]))
            };
            ClientCredentialsResponse clientCredentialsResponse = await new RequestExecuter().ExecutePostRequestAsync<ClientCredentialsResponse>(requestUrl, $"Basic {authorizationCode}", collection);
            return clientCredentialsResponse.RefreshToken;
        }
        public async Task<ClientCredentialsResponse> GetClientCredentialsAsync(string clinetId, string clientSecret, string refreshToken, string scope)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.IDENTITY.ENDPOINT_URL}{Constants.IDENTITY.METHODS.TOKEN}";
            string authorizationCode = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clinetId}:{clientSecret}"));
            var collection = new List<KeyValuePair<string, string>>
            {
                new("grant_type", "refresh_token"),
                new("refresh_token",refreshToken),
                new("scope", scope)
            };
            return await new RequestExecuter().ExecutePostRequestAsync<ClientCredentialsResponse>(requestUrl, $"Basic {authorizationCode}", collection);
        }
    }
}
