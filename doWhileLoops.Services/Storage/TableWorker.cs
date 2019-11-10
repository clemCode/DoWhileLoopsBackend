using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doWhileLoops.Services.Storage
{
    internal class TableWorker
    {
        private CloudTable cloudTable = null;
        private string storageConnectionString = AppSettings.LoadAppSettings().StorageConnectionString;

        public TableWorker()
        {
            InitializeCloudTable();
        }

        #region Initialization

        private void InitializeCloudTable()
        {
            this.cloudTable = CreateTableAsync();
        }
        
        private CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (Exception ex)
            {
                //todo: logging
                return null;
            }

            return storageAccount;
        }

        private CloudTable CreateTableAsync()
        {
            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(this.storageConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());

            CloudTable table = tableClient.GetTableReference("DoWhileLoopsAPIData");

            try
            {
                table.CreateIfNotExists();

                return table;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
        
        #region Worker Methods

        private void InsertOrMergeEntity(ExternalAPIEntry entity)
        {
            try
            {
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);
                TableResult result = cloudTable.Execute(insertOrMergeOperation);
            }
            catch (Exception ex)
            {
                
            }
        }

        private ExternalAPIEntry RetrieveSpecificEntity(string partitionKey, string rowKey)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<ExternalAPIEntry>(partitionKey, rowKey);
                TableResult result = this.cloudTable.Execute(retrieveOperation);
                ExternalAPIEntry apiRow = result.Result as ExternalAPIEntry;

                return apiRow;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<ExternalAPIEntry> RetrieveAllEntities()
        {
            try
            {
                var entities = this.cloudTable.ExecuteQuery(new TableQuery<ExternalAPIEntry>()).ToList();

                return entities;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<ExternalAPIEntry> RetrieveAllEntitiesInPartition(string partitionKey)
        {
            try
            {
                TableQuery<ExternalAPIEntry> query = new TableQuery<ExternalAPIEntry>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
                List<ExternalAPIEntry> entries = this.cloudTable.ExecuteQuery(query).ToList();
                
                return entries;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Method to return all entries in Table Storage.
        /// </summary>
        public List<ExternalAPIEntry> RetrieveAllEntries()
        {
            List<ExternalAPIEntry> entryList = RetrieveAllEntities();
            return entryList;
        }

        /// <summary>
        /// Method to return all rows in a specific Partition in Table Storage.
        /// </summary>
        /// <param name="partitionKey">Partition Key of the entry.</param>
        public List<ExternalAPIEntry> RetrieveSpecificPartition(string partitionKey)
        {
            List<ExternalAPIEntry> entryList = RetrieveAllEntitiesInPartition(partitionKey);
            return entryList;
        }

        /// <summary>
        /// Method to return a specific entry in Table Storage.
        /// </summary>
        /// <param name="partitionKey">Partition Key of the entry.</param>
        /// /// <param name="rowKey">Row Key of the entry.</param>
        public ExternalAPIEntry RetrieveSpecificEntry(string partitionKey, string rowKey)
        {
            ExternalAPIEntry entry = RetrieveSpecificEntity(partitionKey, rowKey);
            return entry;
        }

        public void WriteEntry(ExternalAPIEntry entity)
        {
            InsertOrMergeEntity(entity);
        }

        #endregion

    }
}
