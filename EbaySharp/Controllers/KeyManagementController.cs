using EbaySharp.Entities.Developer.KeyManagement.SigningKey;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class KeyManagementController
    {
        private string accessToken;
        public KeyManagementController(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region SIGNING_KEY

        public async Task<SigningKeys> GetSigningKeys()
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.DEVELOPER.ENDPOINT_URL}{Constants.DEVELOPER.KEY_MANAGEMENT.ENDPOINT_URL}{Constants.DEVELOPER.KEY_MANAGEMENT.METHODS.GET_SIGNING_KEYS}";
            return await new RequestExecuter().ExecuteGetRequest<SigningKeys>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<SigningKey> GetSigningKey(string signingKeyId)
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.DEVELOPER.ENDPOINT_URL}{Constants.DEVELOPER.KEY_MANAGEMENT.ENDPOINT_URL}{string.Format(Constants.DEVELOPER.KEY_MANAGEMENT.METHODS.GET_SIGNING_KEY, signingKeyId)}";
            return await new RequestExecuter().ExecuteGetRequest<SigningKey>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<SigningKey> CreateSigningKey(SigningKeyCipher signingKeyCipher)
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.DEVELOPER.ENDPOINT_URL}{Constants.DEVELOPER.KEY_MANAGEMENT.ENDPOINT_URL}{Constants.DEVELOPER.KEY_MANAGEMENT.METHODS.CREATE_SIGNING_KEY}";
            return await new RequestExecuter().ExecutePostRequest<SigningKey>(requestUrl, $"Bearer {accessToken}", (new { signingKeyCipher = signingKeyCipher.ToString() }).SerializeToJson());
        }

        #endregion

    }
}
