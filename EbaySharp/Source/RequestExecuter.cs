using Newtonsoft.Json;

namespace EbaySharp.Source
{
    internal class RequestExecuter
    {
        public async Task<T> ExecuteRequestAsync<T>(string requestUrl, string accessToken)
        {
            var client = Helpers.GetHttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Authorization", $"Bearer {accessToken}");
            var response = await client.SendAsync(request);
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
    }
}
