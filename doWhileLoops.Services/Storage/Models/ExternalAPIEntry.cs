using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.Storage
{
    public class ExternalAPIEntry : TableEntity
    {
        public ExternalAPIEntry()
        {
        }

        public ExternalAPIEntry(string source, string slug)
        {
            PartitionKey = source;
            RowKey = slug;
        }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string URL { get; set; }
        public string UID { get; set; }
    }
}
