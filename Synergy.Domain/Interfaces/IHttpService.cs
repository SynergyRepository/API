using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Synergy.Domain.Interfaces
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> SendAsync<T>(HttpMethod httpMethod, T model, string baseUrl, string referenceUrl, List<KeyValuePair<string, string>> headers, string authorizationToken, HttpMessageHandler messageHandler = null, string authenticationScheme = "Bearer");
        Task<HttpResponseMessage> GetAsync(string baseUrl, string referenceUrl, string authorizationToken, HttpMessageHandler messageHandler = null, string authenticationScheme = "Bearer");
        Task<HttpResponseMessage> GetAsync(string baseUrl, string referenceUrl, List<KeyValuePair<string, string>> headers = null);
        Task<HttpResponseMessage> PostAsync<T>(T model, string baseUrl, string authorizationToken, string referenceUrl, HttpMessageHandler messageHandler = null, string authenticationScheme = "Bearer");
        Task<HttpResponseMessage> PostAsync<T>(T model, string baseUrl, string referenceUrl, List<KeyValuePair<string, string>> headers = null);
        Task<HttpResponseMessage> PostEncrytionAsync(string model, string baseUrl, string referenceUrl, List<KeyValuePair<string, string>> headers = null, HttpMessageHandler messageHandler = null, string authenticationScheme = "Bearer");

    }
}
