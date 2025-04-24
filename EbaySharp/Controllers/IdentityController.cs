using EbaySharp.Entities.Develop.SellingApps.Identity.User;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class IdentityController
    {
        private string accessToken;
        public IdentityController(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region USER

        public async Task<User> GetUser()
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.OTHERS.IDENTITY.GET_USER}";
            return await new RequestExecuter().ExecuteGetRequest<User>(requestUrl, $"Bearer {accessToken}");
        }

        #endregion

    }
}
