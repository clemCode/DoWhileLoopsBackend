using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using doWhileLoops.Services.Storage;
using Microsoft.Azure.Cosmos.Table;

namespace doWhileLoops.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExternalAPIEntry>>> Get()
        {
            TableClient client = new TableClient();
            var entries = await client.CreateAndRetrieveAllEntries("DoWhileLoopsAPIData");
            return entries;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        //// POST api/values
        //[HttpPost]
        //public async Task<void> Post([FromBody] string value)
        //{
        //    //TableClient client = new TableClient();
        //    //CloudTable table = client.CreateTableAsync("DoWhileLoopsAPIData");
        //    //ExternalAPIEntry entry = new ExternalAPIEntry("youtube", "https://youtube.com");
        //    //entry.ShortDescription = "myThing";
        //    //client.InsertOrMergeEntityAsync(entry);
        //}

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
