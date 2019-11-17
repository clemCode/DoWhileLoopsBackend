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
        
        public List<ExternalAPIDTO> GetAllRows()
        {
            List<ExternalAPIEntry> entries = tableWorker.RetrieveAllEntries();
            if (entries.Count > 0)
                return ConvertEntriesToDTO(entries);
            else
                return null;
        }

        public ExternalAPIDTO GetSpecificRow(string partitionKey, string rowKey)
        {
            ExternalAPIEntry entry = tableWorker.RetrieveSpecificEntry(partitionKey, rowKey);
            if (entry != null)
                return ConvertEntryToDTO(entry);
            else
                return null;
        }

        public List<ExternalAPIDTO> GetAllEntriesInPartition(string partitionKey)
        {
            List<ExternalAPIEntry> entries = tableWorker.RetrieveSpecificPartition(partitionKey);
            if (entries.Count > 0)
                return ConvertEntriesToDTO(entries);
            else
                return null;
        }

        public void WriteEntry(ExternalAPIEntry entry)
        {
            tableWorker.WriteEntry(entry);
        }

        private ExternalAPIDTO ConvertEntryToDTO(ExternalAPIEntry entry)
        {
            return new ExternalAPIDTO(entry);
        }

        private List<ExternalAPIDTO> ConvertEntriesToDTO(List<ExternalAPIEntry> entries)
        {
            List<ExternalAPIDTO> dtos = new List<ExternalAPIDTO>();

            foreach(ExternalAPIEntry entry in entries)
            {
                ExternalAPIDTO dto = new ExternalAPIDTO(entry);
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
