using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace doWhileLoops.Services.API
{
    public class APIPublicClient
    {
        private APIWorker apiWorker = null;

        public APIPublicClient()
        {
            this.apiWorker = new APIWorker();
        }

        public async Task<bool> CallSourcesAndPopulateStorage()
        {
            bool result = await apiWorker.CallSourcesAndPopulateStorage();
            
            return result;
        }
    }
}
