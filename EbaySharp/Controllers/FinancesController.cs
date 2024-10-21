using EbaySharp.Entities.Developer.KeyManagement.SigningKey;
using EbaySharp.Entities.Sell.Finances.Transaction;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class FinancesController
    {
        private string accessToken;
        public FinancesController(string accessToken)
        {
            this.accessToken = accessToken;
        }

        #region TRANSACTIONS
        public async Task<Transactions> GetTransactions(SigningKey? signingKey, string filter, string sort, int limit = 0, int offset = 0)
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.SELL.ENDPOINT_URL}{Constants.SELL.FINANCES.ENDPOINT_URL}{string.Format(Constants.SELL.FINANCES.METHODS.GET_TRANSACTIONS, limit, offset)}";
            requestUrl = string.IsNullOrEmpty(filter) ? requestUrl : $"{requestUrl}&filter=" + filter;
            requestUrl = string.IsNullOrEmpty(sort) ? requestUrl : $"{requestUrl}&sort=" + sort;
            return await new RequestExecuter().ExecuteGetRequest<Transactions>(requestUrl, $"Bearer {accessToken}", signingKey);
        }

        #endregion
    }
}
