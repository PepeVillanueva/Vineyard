using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vineyard.src.Api;
using Xunit;

namespace Vineyard.AcceptanceTest
{
    public class WorkControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _httpClient;
        private readonly string requestURI;

        public WorkControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
            requestURI = "/Work";
        }        

        [Fact]
        public async Task create_a_valid_non_existing_work()
        {
            dynamic body = new System.Dynamic.ExpandoObject();
            body.Id = "1aab45ba-3c7a-4344-8936-78466eca77fa"; 
            body.Name = "Fragar";
            body.UserId= "f2bf0079-75c0-45e4-89bf-0a767593de98";

            StringContent contentFromBody = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{requestURI}/Create/1aab45ba-3c7a-4344-8936-78466eca77fa", contentFromBody);

            Assert.Equal(201, (int)response.StatusCode);
        }
    }
}  
