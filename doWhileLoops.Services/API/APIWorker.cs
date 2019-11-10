using doWhileLoops.Services.API.Models;
using doWhileLoops.Services.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.API
{
    internal class APIWorker
    {
        private TableClient tableClient;

        public APIWorker()
        {
            this.tableClient = new TableClient();
        }

        public bool CallSourcesAndPopulateStorage()
        {
            //call external methods here
            
            //testing code - for now
            SoundCloudClient soundCloudClient = new SoundCloudClient();
            soundCloudClient.GetDataAndWriteResult();

            GitHubClient gitHubClient = new GitHubClient();
            gitHubClient.GetDataAndWriteResult();
            
            
            return true;
        }
    }
}
