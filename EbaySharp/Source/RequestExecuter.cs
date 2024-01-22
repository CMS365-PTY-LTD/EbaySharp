using Newtonsoft.Json;

namespace EbaySharp.Source
{
    internal class RequestExecuter
    {
        private async Task<HttpResponseMessage> executeRequestAsync(HttpMethod httpMethod, string requestUrl, string authHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload)
        {
            var client = Helpers.GetHttpClient();
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
                request.Content = content;
            }
            var response = await client.SendAsync(request);
            return response;
        }
        public async Task<T> ExecuteGetRequestAsync<T>(string requestUrl, string authHeaderValue)
        {
            HttpResponseMessage response = await executeRequestAsync(HttpMethod.Get, requestUrl, authHeaderValue, null, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrEmpty(responseContent))
                {
                    throw new Exception("No content found.");
                }
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            throw new Exception(responseContent);
        }
        public async Task<T> ExecutePostRequestAsync<T>(string requestUrl, string authHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload)
        {
            HttpResponseMessage response = await executeRequestAsync(HttpMethod.Post, requestUrl, authHeaderValue, keyValuePayload, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            throw new Exception(responseContent);
        }
        public async Task<T> ExecutePostRequestAsync<T>(string requestUrl, string authHeaderValue, string? JSONPayload)
        {
            HttpResponseMessage response = await executeRequestAsync(HttpMethod.Post, requestUrl, authHeaderValue, null, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            throw new Exception(responseContent);
        }
    }
}
