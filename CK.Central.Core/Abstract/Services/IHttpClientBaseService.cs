using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Abstract.Services
{
    public interface IHttpClientBaseService
    {
        Task<HttpResponseMessage> Post(string url, JsonContent content);
        Task<HttpResponseMessage> Get(string url, string parameters, string token);
    }
}
