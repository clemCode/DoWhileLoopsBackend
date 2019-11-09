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

            //need tableClient to populate storage

            return true;
        }
    }
}
