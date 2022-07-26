using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Vineyard.src.Api;
using Xunit;

namespace Vineyard.AcceptanceTest
{
    public class WorkControllerTests : ContextAcceptanceTest
    {
        private readonly string requestURI;

        public WorkControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
            CreateAnonymousClient();
            requestURI = "/Work";
        }        

        [Fact]
        public async Task create_a_valid_non_existing_work_refactor()
        {
            await AssertRequestWithBody(
                HttpMethod.Put,
                $"{requestURI}/Create/1aab45ba-3c7a-4344-8936-78466eca77fa",
                "{\"Id\": \"1aab45ba-3c7a-4344-8936-78466eca77fa\", \"Name\": \"Fragar\", \"UserId\": \"f2bf0079-75c0-45e4-89bf-0a767593de98\"}",
                201);
        }        
    }
}  
