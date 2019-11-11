using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.API
{
    public class APIPublicClient
    {
        private APIWorker apiWorker = null;

        public APIPublicClient()
        {
            this.apiWorker = new APIWorker();
        }

        public bool CallSourcesAndPopulateStorage()
        {
            bool result = apiWorker.CallSourcesAndPopulateStorage();
            
            return result;
        }
    }
}
