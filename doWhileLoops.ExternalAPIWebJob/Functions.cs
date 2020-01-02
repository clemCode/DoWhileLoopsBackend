using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using doWhileLoops.Services.API;
using Microsoft.Azure.WebJobs;

namespace doWhileLoops.ExternalAPIWebJob
{
    public class Functions
    {
        public async static Task ProcessTimerAction([TimerTrigger("0 0 2 * * *", RunOnStartup = true)]TimerInfo timerInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dowhileloopsapi.azurewebsites.net/api/refresh");

                var response = await client.GetAsync("");

            }
        }
    }
}
