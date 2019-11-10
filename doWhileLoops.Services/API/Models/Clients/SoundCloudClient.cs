using doWhileLoops.Services.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace doWhileLoops.Services.API.Models
{
    public class SoundCloudClient : IClient<SoundCloudResult>
    {
        public TableClient tableClient { get; set; }
        public string baseAddress { get; set; }
        public HttpClient httpClient { get; set; }
        public string urlParams { get; set; }

        public SoundCloudClient()
        {
            tableClient = new TableClient();

            httpClient = new HttpClient();
            baseAddress = "https://api-v2.soundcloud.com/users/590946879/tracks?client_id=sxSTSKZlWZJb9ZKPkzhoADyLprTpicol";
            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task GetDataAndWriteResult()
        {
            var results = await GetSourceData();
            var parsedResults = ParseData(results);
            WriteResultToTable(parsedResults);
        }

        //TODO - ERROR HANDLING
        public async Task<SoundCloudResult> GetSourceData()
        {
            HttpResponseMessage response = await httpClient.GetAsync(baseAddress);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var soundCloudResult = JsonConvert.DeserializeObject<SoundCloudResult>(result);
                return soundCloudResult;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            }

            return null;
        }

        public IEnumerable<ExternalAPIEntry> ParseData(SoundCloudResult result)
        {
            List<ExternalAPIEntry> tableEntries = new List<ExternalAPIEntry>();

            foreach (Collection song in result.collection)
            {
                ExternalAPIEntry entry = new ExternalAPIEntry();

                entry.PartitionKey = "SoundCloud";
                entry.RowKey = song.permalink;
                entry.Title = song.title;
                entry.ShortDescription = song.description;
                entry.URL = song.permalink_url;
                entry.UID = song.id.ToString();

                tableEntries.Add(entry);
            }

            return tableEntries;
        }

        public void WriteResultToTable(IEnumerable<ExternalAPIEntry> result)
        {
            foreach(ExternalAPIEntry entry in result)
            {
                tableClient.WriteEntry(entry);
            }
        }
    }
}
