using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using doWhileLoops.Services.Storage;
using Microsoft.Azure.Cosmos.Table;
using doWhileLoops.Services.API;

namespace doWhileLoops.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<ExternalAPIEntry>>> Get()
        {
            //var worker = new APIPublicClient();
            //bool success = await worker.CallSourcesAndPopulateStorage();
            //return new JsonResult(success.ToString());
            return new JsonResult("value");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
