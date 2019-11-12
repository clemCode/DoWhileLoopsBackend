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
    public class ContentController : ControllerBase
    {
        TableClient client = new TableClient();
       
        [HttpGet]        
        public ActionResult<List<ExternalAPIEntry>> Get()
        {
            return client.GetAllRows();
        }
        
        [HttpGet("{partitionKey}")]
        public ActionResult<List<ExternalAPIEntry>> GetPartition(string partitionKey)
        {
            return client.GetAllEntriesInPartition(partitionKey);
        }

        [HttpGet("{partitionKey}/{rowkey}")]
        public ActionResult<ExternalAPIEntry> Get(string partitionKey, string rowKey)
        {
            return client.GetSpecificRow(partitionKey, rowKey);
        }
    }
}
