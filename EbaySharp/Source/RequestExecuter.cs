using EbaySharp.Entities.Develop.SellingApps.ListingManagement.Feed;
using EbaySharp.Entities.Developer.KeyManagement.SigningKey;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Serialization;

namespace EbaySharp.Source
{
    internal class RequestExecuter
    {
        private async Task<HttpResponseMessage> executeRequest(HttpMethod httpMethod, string requestUrl, string authenticationHeaderValue, string? contentLanguageHeaderValue,
            List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload, SigningKey? signingKey)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(httpMethod, requestUrl);
            request.Headers.Add("Authorization", authenticationHeaderValue);
            
            if (keyValuePayload!=null)
            {
                var content = new FormUrlEncodedContent(keyValuePayload);
                request.Content = content;
            }
            else if (signingKey != null)
            {
                request.GenerateEbaySignatureHeader(httpMethod, requestUrl, signingKey);
            }
            else if (JSONPayload != null)
            {
                var content = new StringContent(JSONPayload, null, "application/json");
                if (string.IsNullOrEmpty(contentLanguageHeaderValue) == false)
                {
                    content.Headers.Add("Content-Language", contentLanguageHeaderValue.Replace("_", "-"));
                }
                request.Content = content;
            }
            var response = await client.SendAsync(request);
            return response;
        }
        public async Task<T> ExecuteGetRequest<T>(string requestUrl, string authenticationHeaderValue)
        {
            return await ExecuteGetRequest<T>(requestUrl, authenticationHeaderValue, null);
        }
        public async Task<T> ExecuteGetRequest<T>(string requestUrl, string authenticationHeaderValue, SigningKey? signingKey)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Get, requestUrl, authenticationHeaderValue, null, null, null, signingKey);

            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                MediaTypeHeaderValue? contentType = response.Content.Headers.ContentType;
                if (contentType!=null && contentType.MediaType== "application/octet-stream")
                {
                    string? contentDisposition = response.Content.Headers.GetValues("Content-Disposition").FirstOrDefault();
                    if (contentDisposition!=null)
                    {
                        string fileName = contentDisposition.Split(";", StringSplitOptions.RemoveEmptyEntries)[1].Split("=", StringSplitOptions.RemoveEmptyEntries)[1];
                        if (contentDisposition != null)
                        {
                            ResultFile resultFile = new ResultFile() { FileContent = await response.Content.ReadAsStreamAsync(), FileName = fileName.Trim() };
                            return (T)Convert.ChangeType(resultFile, typeof(T));
                        }
                    }
                    
                }
                if (string.IsNullOrEmpty(responseContent))
                {
                    throw new Exception("No content found.");
                }
                return responseContent.DeserializeToObject<T>();
            }
            throw new Exception(responseContent);
        }
        public async Task ExecuteDeleteRequest(string requestUrl, string authenticationHeaderValue)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Delete, requestUrl, authenticationHeaderValue, null, null, null, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode==false)
            {
                throw new Exception(responseContent);
            }
        }
        private async Task<T> executePostRequest<T>(string requestUrl, string authenticationHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload, string? contentLanguage)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authenticationHeaderValue, contentLanguage, keyValuePayload, JSONPayload, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return responseContent.DeserializeToObject<T>();
            }
            throw new Exception((new { error = responseContent.DeserializeToObject<object>(), payload = JSONPayload?.DeserializeToObject<object>() }).SerializeToJson());
        }
        private async Task<T> executeLegacyPostRequest<T>(int siteId, string callName, string payload)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.API_SERVER_URL}{Constants.TRADIONAL.ENDPOINT_URL}");
            request.Headers.Add("X-EBAY-API-SITEID", siteId.ToString());
            request.Headers.Add("X-EBAY-API-COMPATIBILITY-LEVEL", "967");
            request.Headers.Add("X-EBAY-API-CALL-NAME", callName);
            var content = new StringContent(payload, null, "application/xml");
            request.Content = content;
            var response = await client.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            XmlSerializer ser = new XmlSerializer(typeof(T));
            T type;
            using (XmlReader reader = XmlReader.Create(new StringReader(responseContent)))
            {
                type = (T)ser.Deserialize(reader);
            }
            return type;
        }
        //private async Task executePostRequest(string requestUrl, string authenticationHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload, string? contentLanguage)
        //{
        //    HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authenticationHeaderValue, contentLanguage, keyValuePayload, JSONPayload);
        //    string responseContent = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode==false)
        //    {
        //        throw new Exception(responseContent);
        //    }
        //}
        public async Task<T?> ExecutePutRequest<T>(string requestUrl, string authenticationHeaderValue, string? JSONPayload, string? contentLanguage)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Put, requestUrl, authenticationHeaderValue, contentLanguage, null, JSONPayload, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return string.IsNullOrEmpty(responseContent) == true ? default(T) : responseContent.DeserializeToObject<T>();
            }
            throw new Exception((new { error = responseContent.DeserializeToObject<object>(), payload = JSONPayload.DeserializeToObject<object>() }).SerializeToJson());
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authenticationHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload)
        {
            return await executePostRequest<T>(requestUrl, authenticationHeaderValue, keyValuePayload, null, null);
        }
        public async Task<T> ExecuteLegacyPostRequest<T>(int siteId, string callName, string payload)
        {
            return await executeLegacyPostRequest<T>(siteId, callName, payload);
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authenticationHeaderValue, string? JSONPayload, string? contentLanguage)
        {
            return await executePostRequest<T>(requestUrl, authenticationHeaderValue, null, JSONPayload, contentLanguage);
        }
        public async Task ExecutePostRequest(string requestUrl, string authenticationHeaderValue, string JSONPayload, string? contentLanguage)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authenticationHeaderValue, contentLanguage, null, JSONPayload, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode==false)
            {
                throw new Exception((new { error = responseContent, payload = JSONPayload.DeserializeToObject<object>() }).SerializeToJson());
            }
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authenticationHeaderValue, string? JSONPayload)
        {
            return await executePostRequest<T>(requestUrl, authenticationHeaderValue, null, JSONPayload, null);
        }
    }
}
