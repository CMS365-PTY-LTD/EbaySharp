using EbaySharp.Entities.Common;
using EbaySharp.Entities.Sell.Fulfillment.Order.ShippingFulfillment;
using EbaySharp.Entities.Taxonomy;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class FulfillmentController
    {
        private string accessToken;
        public FulfillmentController(string accessToken)
        {
            this.accessToken = accessToken;
        }
        #region ORDER

        #region SHIPPING_FULFILLEMENT

        public async Task<Fulfillments> GetShippingFulfillments(string orderId)
        {
            string requestUrl = $"{Constants.SERVER_URL}{Constants.SELL.FULFILLEMENT.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ORDER.ENDPOINT_URL}{string.Format(Constants.SELL.FULFILLEMENT.ORDER.METHODS.GET_SHIPPING_FULFILLEMENTS, orderId)}";
            return await new RequestExecuter().ExecuteGetRequest<Fulfillments>(requestUrl, $"Bearer {accessToken}");
        }

        #endregion


        #endregion

    }
}
