using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using doWhileLoops.Services.Storage;
using Newtonsoft.Json;

namespace doWhileLoops.Services.API.Models
{
    public class StoryblokClient : IClient<StoryblokResult>
    {
        public TableClient tableClient { get; set; }
        public string baseAddress { get; set; }
        public HttpClient httpClient { get; set; }
        public string urlParams { get; set; }

        public StoryblokClient(string connectionString)
        {
            tableClient = new TableClient(connectionString);

            httpClient = new HttpClient();
            baseAddress = "https://api.storyblok.com/v1/cdn/stories?token=VF26nXY079vJIug3cgsrwwtt";

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task GetDataAndWriteResult()
        {
            var results = await GetSourceData();
            var parsedResults = ParseData(results);
            WriteResultToTable(parsedResults);
        }

        public async Task<StoryblokResult> GetSourceData()
        {
            HttpResponseMessage response = await httpClient.GetAsync(baseAddress);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                StoryblokResult storyblokResult = JsonConvert.DeserializeObject<StoryblokResult>(result);
                return storyblokResult;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return null;
        }

        public IEnumerable<ExternalAPIEntry> ParseData(StoryblokResult result)
        {
            List<ExternalAPIEntry> tableEntries = new List<ExternalAPIEntry>();

            foreach (Story story in result.stories)
            {
                ExternalAPIEntry entry = new ExternalAPIEntry();

                entry.PartitionKey = "Storyblok";
                entry.RowKey = story.slug;
                entry.Title = story.name;
                entry.ShortDescription = story.content.shortdescription;
                entry.URL = "blog/" + story.slug;
                entry.UID = story.id.ToString();

                tableEntries.Add(entry);
            }

            return tableEntries;
        }

        public void WriteResultToTable(IEnumerable<ExternalAPIEntry> result)
        {
            foreach (ExternalAPIEntry entry in result)
            {
                tableClient.WriteEntry(entry);
            }
        }
    }
}
