using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vineyard.Activity.Work.Application;

namespace Vineyard.src.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class WorkController : ControllerBase
    {
        private readonly ILogger<WorkController> _logger;
        private readonly IWorkCreator _workCreator;

        public WorkController(ILogger<WorkController> logger, IWorkCreator workCreator)
        {
            _logger = logger;
            _workCreator = workCreator;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(string id, [FromBody] dynamic body)
        {
            body = JsonConvert.DeserializeObject(Convert.ToString(body));

            _workCreator.WorkCreate(body["Id"].ToString(), body["Name"].ToString(), body["UserId"].ToString());
            
            return CreatedAtAction(nameof(GetWorkBy), new { id = id }, body);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWorkBy(string id)
        {
            return Ok();
        }
    }
}
