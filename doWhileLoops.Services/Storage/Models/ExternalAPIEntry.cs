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

        public ExternalAPIEntry(string source, string url)
        {
            PartitionKey = source;
            RowKey = url;
        }

        public string Slug { get; set; }
        public string ShortDescription { get; set; }
        public string Title { get; set; }
        public string UID { get; set; }
    }
}
