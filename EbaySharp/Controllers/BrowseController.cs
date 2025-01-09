using EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class BrowseController
    {
        private string accessToken;
        public BrowseController(string accessToken)
        {
            this.accessToken = accessToken;
        }
        #region ITEM

        public async Task<Item> GetItem(string itemId)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.BUY.ENDPOINT_URL}{Constants.BUY.BROWSE.ENDPOINT_URL}{Constants.BUY.BROWSE.ITEM.ENDPOINT_URL}{String.Format(Constants.BUY.BROWSE.ITEM.METHODS.GET_ITEM, itemId)}";
            return await new RequestExecuter().ExecuteGetRequest<Item>(requestUrl, $"Bearer {accessToken}");
        }

        #endregion
    }
}
