using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using doWhileLoops.Services.Storage;
using Microsoft.Azure.Cosmos.Table;
using doWhileLoops.Services.API;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace doWhileLoops.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshController : ControllerBase
    {
        string connString;

        public RefreshController(IOptions<MyOptions> optionsAccessor)
        {
            connString = optionsAccessor.Value.ConnString;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ExternalAPIEntry>>> Get()
        {
            var worker = new APIPublicClient(connString);
            bool success = await worker.CallSourcesAndPopulateStorage();
            return new JsonResult(success.ToString());
        }
    }
}
