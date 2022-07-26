using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Vineyard.src.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class WorkController : ControllerBase
    {
        private readonly ILogger<WorkController> _logger;

        public WorkController(ILogger<WorkController> logger)
        {
            _logger = logger;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(string id, [FromBody] dynamic body)
        {
            body = JsonConvert.DeserializeObject(Convert.ToString(body));
            
            return CreatedAtAction(nameof(GetWorkBy), new { id = body.Id }, body);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWorkBy(string id)
        {
            return Ok();
        }
    }
}
