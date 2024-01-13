using EbaySharp.Entities.Identity;
using EbaySharp.Entities.Taxonomy;

namespace EbaySharp.Controllers
{
    public class EbayController
    {
        private string accessToken;
        public EbayController(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region TAXONOMY 

        public async Task<CategoryTree> GetDefaultCategoryTreeId(string marketplace_id)
        {
            return await new TaxonomyController(accessToken).GetDefaultCategoryTreeId(marketplace_id);
        }

        #endregion
    }
}
