using EbaySharp.Entities.Sell.Fulfillment.Order;
using EbaySharp.Entities.Sell.Fulfillment.Order.ShippingFulfillment;
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
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ORDER.ENDPOINT_URL}{string.Format(Constants.SELL.FULFILLEMENT.ORDER.SHIPPING_FULFILLEMENT.METHODS.GET_SHIPPING_FULFILLEMENTS, orderId)}";
            return await new RequestExecuter().ExecuteGetRequest<Fulfillments>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<Fulfillment> GetShippingFulfillment(string orderId, string fulfillmentId)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ORDER.ENDPOINT_URL}{string.Format(Constants.SELL.FULFILLEMENT.ORDER.SHIPPING_FULFILLEMENT.METHODS.GET_SHIPPING_FULFILLEMENT, orderId, fulfillmentId)}";
            return await new RequestExecuter().ExecuteGetRequest<Fulfillment>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task CreateShippingFulfillment(string orderId, Fulfillment fulfillment)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ORDER.ENDPOINT_URL}{string.Format(Constants.SELL.FULFILLEMENT.ORDER.SHIPPING_FULFILLEMENT.METHODS.CREATE_SHIPPING_FULFILLEMENTS, orderId)}";
            await new RequestExecuter().ExecutePostRequest(requestUrl, $"Bearer {accessToken}", fulfillment.SerializeToJson(), null);
        }

        #endregion

        public async Task<Orders> GetOrders(string[] orderNumbers)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ORDER.ENDPOINT_URL}{string.Format(Constants.SELL.FULFILLEMENT.ORDER.METHODS.GET_ORDERS_BY_ORDER_NUMBERS, string.Join(',', orderNumbers))}";
            return await new RequestExecuter().ExecuteGetRequest<Orders>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<Order> GetOrder(string orderNumber)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ORDER.ENDPOINT_URL}{string.Format(Constants.SELL.FULFILLEMENT.ORDER.METHODS.GET_ORDER, orderNumber)}";
            return await new RequestExecuter().ExecuteGetRequest<Order>(requestUrl, $"Bearer {accessToken}");
        }
        public async Task<Orders> GetOrders(string filter, int limit, int offset)
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ENDPOINT_URL}{Constants.SELL.FULFILLEMENT.ORDER.ENDPOINT_URL}" +
                $"{string.Format(Constants.SELL.FULFILLEMENT.ORDER.METHODS.GET_ORDERS_BY_FILTER, filter, limit, offset)}";
            return await new RequestExecuter().ExecuteGetRequest<Orders>(requestUrl, $"Bearer {accessToken}");
        }

        #endregion

    }
}
