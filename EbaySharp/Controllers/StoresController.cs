﻿using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Stores.Store;
using EbaySharp.Source;

namespace EbaySharp.Controllers
{
    class StoresController
    {
        private string accessToken;
        public StoresController(string accessToken)
        {
            this.accessToken = accessToken;
        }
        public async Task<StoreCategories> GetStoreCategories()
        {
            string requestUrl = $"{Constants.API_SERVER_URL}{Constants.DEVELOP.SELLING_APPS.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.LISTING_MANAGEMENT.STORES.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.LISTING_MANAGEMENT.STORES.STORE.ENDPOINT_URL}{Constants.DEVELOP.SELLING_APPS.LISTING_MANAGEMENT.STORES.STORE.METHODS.GET_STORE_CATEGORIES}";
            return await new RequestExecuter().ExecuteGetRequest<StoreCategories>(requestUrl, $"Bearer {accessToken}");
        }
    }
}
