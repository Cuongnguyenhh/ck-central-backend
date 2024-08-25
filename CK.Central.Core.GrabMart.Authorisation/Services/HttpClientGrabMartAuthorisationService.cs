using CK.Central.Core.GrabMart.Authorisation.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Authorisation.Services
{
    public class HttpClientGrabMartAuthorisationService : HttpClientBaseService, IHttpClientGrabMartAuthorisationService
    {
        private readonly HttpClient _httpClient;
        public HttpClientGrabMartAuthorisationService(HttpClient httpClient) : base(httpClient) => this._httpClient = httpClient;
    }
}
