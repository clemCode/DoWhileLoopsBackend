using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using doWhileLoops.Services.Storage;
using Microsoft.Azure.Cosmos.Table;
using doWhileLoops.Services.API;
using Microsoft.Extensions.Options;

namespace doWhileLoops.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        TableClient client = null;


        public ContentController(IOptions<MyOptions> optionsAccessor)
        {
            var connString = optionsAccessor.Value.ConnString;
            client = new TableClient(connString);
        }
        
        [HttpGet]        
        public ActionResult<List<ExternalAPIDTO>> Get()
        {
            return client.GetAllRows();
            //git repo test comment
        }
        
        [HttpGet("{partitionKey}")]
        public ActionResult<List<ExternalAPIDTO>> GetPartition(string partitionKey)
        {
            return client.GetAllEntriesInPartition(partitionKey);
        }

        [HttpGet("{partitionKey}/{rowkey}")]
        public ActionResult<ExternalAPIDTO> Get(string partitionKey, string rowKey)
        {
            return client.GetSpecificRow(partitionKey, rowKey);
        }
    }
}
