using doWhileLoops.Services.API.Models;
using doWhileLoops.Services.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace doWhileLoops.Services.API
{
    internal class APIWorker
    {
        private TableClient tableClient;
        string connectionString;

        public APIWorker(string connectionString)
        {
            this.tableClient = new TableClient(connectionString);
            this.connectionString = connectionString;
        }

        public async Task<bool> CallSourcesAndPopulateStorage()
        {
            try
            {
                SoundCloudClient soundCloudClient = new SoundCloudClient(connectionString);
                await soundCloudClient.GetDataAndWriteResult();

                GitHubClient gitHubClient = new GitHubClient(connectionString);
                await gitHubClient.GetDataAndWriteResult();

                StoryblokClient storyblockClient = new StoryblokClient(connectionString);
                await storyblockClient.GetDataAndWriteResult();
                
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
