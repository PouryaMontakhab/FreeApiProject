using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FreeApiProject.Services
{
    public class HttpClientService : IHttpClientService
    {
        #region Fields
        public readonly HttpClient _httpClient;

        #endregion
        #region Constructors
        public HttpClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromHours(48);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
        #region Methods
        #region Crud

        public async Task<TOutput> GetAsync<TOutput>(string requestUrl)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                var strContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TOutput>(strContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<HttpResponseMessage> PostAsync<TInput>(string requestUrl, TInput item)
        {
            try
            {
                var dataAsString = JsonConvert.SerializeObject(item);
                var content = new StringContent(dataAsString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await _httpClient.PostAsync(requestUrl, content);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TOutPut> PostAsync<TInput, TOutPut>(string requestUrl, TInput item)
        {
            var response = await PostAsync<TInput>(requestUrl, item);
            var responseStream = await response.Content.ReadAsStringAsync();
            var resultResponse = JsonConvert.DeserializeObject<TOutPut>(responseStream);
            return resultResponse;
        }
        public async Task<HttpResponseMessage> PutAsync<TInput>(string requestUrl, TInput item)
        {
            try
            {
                var dataAsString = JsonConvert.SerializeObject(item);
                var content = new StringContent(dataAsString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await _httpClient.PutAsync(requestUrl, content);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TOutPut> PutAsync<TInput, TOutPut>(string requestUrl, TInput item)
        {
            var response = await PutAsync<TInput>(requestUrl, item);
            var responseStream = await response.Content.ReadAsStringAsync();
            var resultResponse = JsonConvert.DeserializeObject<TOutPut>(responseStream);
            return resultResponse;
        }
        public async Task<HttpResponseMessage> PatchAsync<TInput>(string requestUrl, TInput item)
        {

            try
            {
                var dataAsString = JsonConvert.SerializeObject(item);
                var content = new StringContent(dataAsString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await _httpClient.PatchAsync(requestUrl, content);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TOutPut> PatchAsync<TInput, TOutPut>(string requestUrl, TInput item)
        {
            var response = await PatchAsync<TInput>(requestUrl, item);
            var responseStream = await response.Content.ReadAsStringAsync();
            var resultResponse = JsonConvert.DeserializeObject<TOutPut>(responseStream);
            return resultResponse;
        }
        public async Task<HttpResponseMessage> DeleteAsync(string requestUrl)
        {
            try
            {

                var response = await _httpClient.DeleteAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TOutPut> DeleteAsync<TOutPut>(string requestUrl)
        {
            var response = await DeleteAsync(requestUrl);
            var responseStream = await response.Content.ReadAsStringAsync();
            var resultResponse = JsonConvert.DeserializeObject<TOutPut>(responseStream);
            return resultResponse;
        }
        public async Task<HttpResponseMessage> DeleteAsync<TInput>(string requestUrl, TInput item)
        {
            try
            {
                var dataAsString = JsonConvert.SerializeObject(item);
                var content = new StringContent(dataAsString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUrl)
                {
                    Content = content
                });
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TOutPut> DeleteAsync<TInput, TOutPut>(string requestUrl, TInput item)
        {
            var response = await DeleteAsync<TInput>(requestUrl, item);
            var responseStream = await response.Content.ReadAsStringAsync();
            var resultResponse = JsonConvert.DeserializeObject<TOutPut>(responseStream);
            return resultResponse;
        }
        #endregion
        #region Functions
        public void AddBaseUrl(string baseUrl)
        {
            _httpClient.BaseAddress = new Uri(baseUrl);

        }
        public void Dispose()
        {
            _httpClient.Dispose();
        }
        #endregion
        #endregion
    }
}
