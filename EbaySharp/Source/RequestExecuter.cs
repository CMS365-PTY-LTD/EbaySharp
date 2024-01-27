namespace EbaySharp.Source
{
    internal class RequestExecuter
    {
        private async Task<HttpResponseMessage> executeRequest(HttpMethod httpMethod, string requestUrl, string authHeaderValue, string? contentLanguageHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload
            , string? JSONPayload)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(httpMethod, requestUrl);
            request.Headers.Add("Authorization", authHeaderValue);
            
            if (keyValuePayload!=null)
            {
                var content = new FormUrlEncodedContent(keyValuePayload);
                request.Content = content;
            }
            else if (JSONPayload != null)
            {
                var content = new StringContent(JSONPayload, null, "application/json");
                if (string.IsNullOrEmpty(contentLanguageHeaderValue) == false)
                {
                    content.Headers.Add("Content-Language", contentLanguageHeaderValue);
                }
                request.Content = content;
            }
            var response = await client.SendAsync(request);
            return response;
        }
        public async Task<T> ExecuteGetRequest<T>(string requestUrl, string authHeaderValue)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Get, requestUrl, authHeaderValue, null, null, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrEmpty(responseContent))
                {
                    throw new Exception("No content found.");
                }
                return responseContent.DeserializeToObject<T>();
            }
            throw new Exception(responseContent);
        }
        public async Task ExecuteDeleteRequest(string requestUrl, string authHeaderValue)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Delete, requestUrl, authHeaderValue, null, null, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode==false)
            {
                throw new Exception(responseContent);
            }
        }
        private async Task<T> executePostRequest<T>(string requestUrl, string authHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authHeaderValue, null, keyValuePayload, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return responseContent.DeserializeToObject<T>();
            }
            throw new Exception(responseContent);
        }
        public async Task ExecutePutRequest(string requestUrl, string authHeaderValue, string JSONPayload, string contentLanguage)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Put, requestUrl, authHeaderValue, contentLanguage, null, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode==false)
            {
                throw new Exception(responseContent);
            }
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authHeaderValue, List<KeyValuePair<string, string>> keyValuePayload)
        {
            return await executePostRequest<T>(requestUrl, authHeaderValue, keyValuePayload, null);
        }
        public async Task ExecutePostRequest(string requestUrl, string authHeaderValue, string JSONPayload)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authHeaderValue, null, null, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode==false)
            {
                throw new Exception(responseContent);
            }
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authHeaderValue, string? JSONPayload)
        {
            return await executePostRequest<T>(requestUrl, authHeaderValue, null, JSONPayload);
        }
    }
}
