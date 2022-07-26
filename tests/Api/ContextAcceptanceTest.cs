using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vineyard.src.Api;
using Xunit;

namespace Vineyard.AcceptanceTest
{
    public class ContextAcceptanceTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _httpClient;

        public ContextAcceptanceTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        protected void CreateAnonymousClient()
        {
            _httpClient = _factory.CreateClient();
        }

        protected async Task AssertRequestWithBody(HttpMethod method, string endpoint, string body,
            int expectedStatusCode)
        {
            using (var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(endpoint, UriKind.Relative),
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            })
            {
                var response = await _httpClient.SendAsync(request);

                Assert.Equal(expectedStatusCode, (int) response.StatusCode);
            }
        }

        protected async Task AssertResponse(HttpMethod method, string endpoint, int expectedStatusCode,
            string expectedResponse)
        {
            using (var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(endpoint, UriKind.Relative)
            })
            {
                var response = await _httpClient.SendAsync(request);
                var result = response.Content.ReadAsStringAsync().Result;
                Assert.Equal(expectedStatusCode, (int) response.StatusCode);
                Assert.Equal(expectedResponse, result);
            }
        }
    }
}