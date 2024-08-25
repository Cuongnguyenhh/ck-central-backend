using CK.Central.Core.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Services
{
    public class HttpClientBaseService : IHttpClientBaseService
    {
        private readonly HttpClient httpClient;
        public HttpClientBaseService(HttpClient httpClient) => this.httpClient = httpClient;

        public async Task<HttpResponseMessage> Post(string url, JsonContent content)
        {
            try
            {
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return await httpClient.PostAsync(url, content);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }

        public async Task<HttpResponseMessage> Get(string url, string parameters, string token)
        {
            try
            {
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer", token);
                return await httpClient.GetAsync(parameters);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }
    }
}
