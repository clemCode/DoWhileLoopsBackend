using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doWhileLoops.Services.Storage
{
    public class TableClient
    {
        private TableWorker tableWorker;

        public TableClient(string connectionString)
        {
            tableWorker = new TableWorker(connectionString);
        }
        
        public List<ExternalAPIEntry> GetAllRows()
        {
            return tableWorker.RetrieveAllEntries();
        }

        public ExternalAPIEntry GetSpecificRow(string partitionKey, string rowKey)
        {
            return tableWorker.RetrieveSpecificEntry(partitionKey, rowKey);
        }

        public List<ExternalAPIEntry> GetAllEntriesInPartition(string partitionKey)
        {
            return tableWorker.RetrieveSpecificPartition(partitionKey);
        }

        public void WriteEntry(ExternalAPIEntry entry)
        {
            tableWorker.WriteEntry(entry);
        }
    }
}
