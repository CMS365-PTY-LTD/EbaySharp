using System.Text.Json;

namespace EbaySharp.Source
{
    internal class RequestExecuter
    {
        private async Task<HttpResponseMessage> executeRequest(HttpMethod httpMethod, string requestUrl, string authHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload)
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
                request.Content = content;
            }
            var response = await client.SendAsync(request);
            return response;
        }
        public async Task<T> ExecuteGetRequest<T>(string requestUrl, string authHeaderValue)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Get, requestUrl, authHeaderValue, null, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrEmpty(responseContent))
                {
                    throw new Exception("No content found.");
                }
                return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            throw new Exception(responseContent);
        }
        public async Task ExecuteDeleteRequest(string requestUrl, string authHeaderValue)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Delete, requestUrl, authHeaderValue, null, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode==false)
            {
                throw new Exception(responseContent);
            }
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authHeaderValue, keyValuePayload, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            throw new Exception(responseContent);
        }
        public async Task ExecutePostRequest(string requestUrl, string authHeaderValue, string JSONPayload)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authHeaderValue, null, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode==false)
            {
                throw new Exception(responseContent);
            }
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authHeaderValue, string? JSONPayload)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authHeaderValue, null, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            throw new Exception(responseContent);
        }
    }
}
