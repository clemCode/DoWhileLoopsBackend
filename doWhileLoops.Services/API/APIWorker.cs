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

        public APIWorker()
        {
            //TODO - connString here
            this.tableClient = new TableClient(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
        }

        public async Task<bool> CallSourcesAndPopulateStorage()
        {
            try
            {
                SoundCloudClient soundCloudClient = new SoundCloudClient();
                await soundCloudClient.GetDataAndWriteResult();

                GitHubClient gitHubClient = new GitHubClient();
                await gitHubClient.GetDataAndWriteResult();

                StoryblokClient storyblockClient = new StoryblokClient();
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
