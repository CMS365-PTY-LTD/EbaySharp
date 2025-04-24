using EbaySharp.Entities.Develop.KeyManagement.SigningKey;
using EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Payout;
using EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Transaction;
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

        #region TRANSACTION
        public async Task<Transactions> GetTransactions(SigningKey signingKey, string filter, string sort, int limit = 0, int offset = 0)
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.ENDPOINT_URL}{string.Format(Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.METHODS.GET_TRANSACTIONS, limit, offset)}";
            requestUrl = string.IsNullOrEmpty(filter) ? requestUrl : $"{requestUrl}&filter=" + filter;
            requestUrl = string.IsNullOrEmpty(sort) ? requestUrl : $"{requestUrl}&sort=" + sort;
            return await new RequestExecuter().ExecuteGetRequest<Transactions>(requestUrl, $"Bearer {accessToken}", signingKey);
        }
        public async Task<TransactionSummary> GetTransactionSummary(SigningKey signingKey, string filter)
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.METHODS.GET_TRANSACTION_SUMMARY}";
            requestUrl = string.IsNullOrEmpty(filter) ? requestUrl : $"{requestUrl}?filter=" + filter;
            return await new RequestExecuter().ExecuteGetRequest<TransactionSummary>(requestUrl, $"Bearer {accessToken}", signingKey);
        }

        #endregion

        #region PAYOUT

        public async Task<PayoutSummary> GetPayoutSummary(SigningKey signingKey, string filter)
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.METHODS.GET_PAYOUT_SUMMARY}";
            requestUrl = string.IsNullOrEmpty(filter) ? requestUrl : $"{requestUrl}?filter=" + filter;
            return await new RequestExecuter().ExecuteGetRequest<PayoutSummary>(requestUrl, $"Bearer {accessToken}", signingKey);
        }
        public async Task<PayoutList> GetPayouts(SigningKey signingKey, string filter, string sort, int limit = 0, int offset = 0)
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.ENDPOINT_URL}{string.Format(Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.METHODS.GET_PAYOUTS, limit, offset)}";
            requestUrl = string.IsNullOrEmpty(filter) ? requestUrl : $"{requestUrl}?filter=" + filter;
            requestUrl = string.IsNullOrEmpty(sort) ? requestUrl : $"{requestUrl}&sort=" + sort;
            return await new RequestExecuter().ExecuteGetRequest<PayoutList>(requestUrl, $"Bearer {accessToken}", signingKey);
        }
        public async Task<Payout> GetPayout(SigningKey signingKey, long payoutNumber)
        {
            string requestUrl = $"{Constants.APIZ_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.ENDPOINT_URL}{string.Format(Constants.DEVELOP.SELLING_APPS.ACCOUNT_MANAGEMENT.FINANCES.METHODS.GET_PAYOUT, payoutNumber)}";
            return await new RequestExecuter().ExecuteGetRequest<Payout>(requestUrl, $"Bearer {accessToken}", signingKey);
        }

        #endregion
    }
}
