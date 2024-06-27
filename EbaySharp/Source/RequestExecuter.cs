﻿using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

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
                    content.Headers.Add("Content-Language", contentLanguageHeaderValue.Replace("_", "-"));
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
        private async Task<T> executePostRequest<T>(string requestUrl, string authHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload, string? contentLanguage)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authHeaderValue, contentLanguage, keyValuePayload, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return responseContent.DeserializeToObject<T>();
            }
            throw new Exception((new { error = responseContent.DeserializeToObject<object>(), payload = JSONPayload?.DeserializeToObject<object>() }).SerializeToJson());
        }
        private async Task<T> executeLegacyPostRequest<T>(string callName, string payload)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{Constants.API_SERVER_URL}{Constants.TRADIONAL.ENDPOINT_URL}");
            request.Headers.Add("X-EBAY-API-SITEID", "15");
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
        //private async Task executePostRequest(string requestUrl, string authHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload, string? JSONPayload, string? contentLanguage)
        //{
        //    HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authHeaderValue, contentLanguage, keyValuePayload, JSONPayload);
        //    string responseContent = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode==false)
        //    {
        //        throw new Exception(responseContent);
        //    }
        //}
        public async Task<T?> ExecutePutRequest<T>(string requestUrl, string authHeaderValue, string? JSONPayload, string? contentLanguage)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Put, requestUrl, authHeaderValue, contentLanguage, null, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return string.IsNullOrEmpty(responseContent) == true ? default(T) : responseContent.DeserializeToObject<T>();
            }
            throw new Exception((new { error = responseContent.DeserializeToObject<object>(), payload = JSONPayload.DeserializeToObject<object>() }).SerializeToJson());
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authHeaderValue, List<KeyValuePair<string, string>>? keyValuePayload)
        {
            return await executePostRequest<T>(requestUrl, authHeaderValue, keyValuePayload, null, null);
        }
        public async Task<T> ExecuteLegacyPostRequest<T>(string callName, string payload)
        {
            return await executeLegacyPostRequest<T>(callName, payload);
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authHeaderValue, string? JSONPayload, string? contentLanguage)
        {
            return await executePostRequest<T>(requestUrl, authHeaderValue, null, JSONPayload, contentLanguage);
        }
        public async Task ExecutePostRequest(string requestUrl, string authHeaderValue, string JSONPayload, string? contentLanguage)
        {
            HttpResponseMessage response = await executeRequest(HttpMethod.Post, requestUrl, authHeaderValue, contentLanguage, null, JSONPayload);
            string responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode==false)
            {
                throw new Exception((new { error = responseContent, payload = JSONPayload.DeserializeToObject<object>() }).SerializeToJson());
            }
        }
        public async Task<T> ExecutePostRequest<T>(string requestUrl, string authHeaderValue, string? JSONPayload)
        {
            return await executePostRequest<T>(requestUrl, authHeaderValue, null, JSONPayload, null);
        }
    }
}
