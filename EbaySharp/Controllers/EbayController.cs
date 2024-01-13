using EbaySharp.Entities.Identity;
using EbaySharp.Entities.Taxonomy;

namespace EbaySharp.Controllers
{
    public class EbayController
    {
        private string accessToken;
        public EbayController(string longLivedAccessToken)
        {
            accessToken = longLivedAccessToken;
        }

        #region IDENTITY 

        public async Task<ClientCredentials> GetClientCredentials(string clinetId, string clientSecret)
        {
            return await new IdentityController().GetClientCredentials(clinetId, clientSecret);
        }

        #endregion


        #region TAXONOMY 

        public async Task<CategoryTree> GetDefaultCategoryTreeId(string marketplace_id)
        {
            return await new TaxonomyController(accessToken).GetDefaultCategoryTreeId(marketplace_id);
        }

        #endregion
    }
}
