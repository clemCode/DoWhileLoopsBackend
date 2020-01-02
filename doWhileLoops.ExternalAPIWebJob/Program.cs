using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace doWhileLoops.ExternalAPIWebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var builder = new HostBuilder()
            .ConfigureWebJobs(webJobConfiguration =>
            {
                webJobConfiguration.AddTimers();
                webJobConfiguration.AddAzureStorageCoreServices();
            })
            .ConfigureServices(serviceCollection => serviceCollection.AddTransient<Functions>())
            .Build();

            builder.Run();


            //***********************
            //original setup
            //var config = new JobHostConfiguration();

            //if (config.IsDevelopment)
            //{
            //    config.UseDevelopmentSettings();
            //}

            //var host = new JobHost(config);
            //// The following code ensures that the WebJob will be running continuously
            //host.RunAndBlock();
        }
    }
}
