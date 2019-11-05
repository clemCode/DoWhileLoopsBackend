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
        public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
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

        public async Task<CloudTable> CreateTableAsync(string tableName)
        {
            string storageConnectionString = AppSettings.LoadAppSettings().StorageConnectionString;

            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(storageConnectionString);
            
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            
            CloudTable table = tableClient.GetTableReference(tableName);

            try
            {
                await table.CreateIfNotExistsAsync();
                
                return table;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<ExternalAPIEntry> InsertOrMergeEntityAsync(CloudTable table, ExternalAPIEntry entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            try
            {
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                ExternalAPIEntry apiRow = result.Result as ExternalAPIEntry;
                
                return apiRow;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<ExternalAPIEntry> RetrieveEntityUsingPointQueryAsync(CloudTable table, string partitionKey, string rowKey)
        {
            try
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<ExternalAPIEntry>(partitionKey, rowKey);
                TableResult result = await table.ExecuteAsync(retrieveOperation);
                ExternalAPIEntry apiRow = result.Result as ExternalAPIEntry;
                
                return apiRow;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<ExternalAPIEntry> RetrieveAllEntitiesAsync(CloudTable table)
        {
            try
            {
                var entities = table.ExecuteQuery(new TableQuery<ExternalAPIEntry>()).ToList();
                
                return entities;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ExternalAPIEntry>> CreateAndRetrieveAllEntries(string tableName)
        {
            var table = await CreateTableAsync(tableName);
            return RetrieveAllEntitiesAsync(table);
        }
    }
}
