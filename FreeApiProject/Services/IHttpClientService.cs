using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreeApiProject.Services
{
    public interface IHttpClientService : IDisposable
    {
        void AddBaseUrl(string baseUrl);
        Task<TOutput> GetAsync<TOutput>(string requestUrl);
        Task<HttpResponseMessage> PostAsync<TInput>(string requestUrl, TInput item);
        Task<HttpResponseMessage> PutAsync<TInput>(string requestUrl, TInput item);
        Task<HttpResponseMessage> DeleteAsync(string requestUrl);
        Task<HttpResponseMessage> DeleteAsync<TInput>(string requestUrl, TInput item);
        Task<HttpResponseMessage> PatchAsync<TInput>(string requestUrl, TInput item);

        Task<TOutPut> PostAsync<TInput, TOutPut>(string requestUrl, TInput item);
        Task<TOutPut> PutAsync<TInput, TOutPut>(string requestUrl, TInput item);
        Task<TOutPut> DeleteAsync<TOutPut>(string requestUrl);
        Task<TOutPut> DeleteAsync<TInput, TOutPut>(string requestUrl, TInput item);
        Task<TOutPut> PatchAsync<TInput, TOutPut>(string requestUrl, TInput item);
    }
}
