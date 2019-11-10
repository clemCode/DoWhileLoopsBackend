using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using doWhileLoops.Services.Storage;
using Newtonsoft.Json;

namespace doWhileLoops.Services.API.Models
{
    public class GitHubClient : IClient<GitHubResult>
    {
        public TableClient tableClient { get; set; }
        public string baseAddress { get; set; }
        public HttpClient httpClient { get; set; }
        public string urlParams { get; set; }

        public GitHubClient()
        {
            tableClient = new TableClient();

            httpClient = new HttpClient();
            baseAddress = "https://api.github.com/users/clemCode/repos";

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "doWhileLoops");
        }

        public async Task GetDataAndWriteResult()
        {
            var results = await GetSourceData();
            var parsedResults = ParseData(results);
            WriteResultToTable(parsedResults);
        }

        //TODO - ERROR HANDLING
        public async Task<GitHubResult> GetSourceData()
        {
            HttpResponseMessage response = await httpClient.GetAsync(baseAddress);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var repoArrayResult = JsonConvert.DeserializeObject<Repo[]>(result);
                GitHubResult githubResult = new GitHubResult(repoArrayResult);
                return githubResult;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return null;
        }

        public IEnumerable<ExternalAPIEntry> ParseData(GitHubResult result)
        {
            List<ExternalAPIEntry> tableEntries = new List<ExternalAPIEntry>();

            foreach (Repo repo in result.Repos)
            {
                ExternalAPIEntry entry = new ExternalAPIEntry();

                entry.PartitionKey = "GitHub";
                entry.RowKey = repo.name;
                entry.Title = repo.name;
                entry.ShortDescription = repo.description;
                entry.URL = repo.html_url;
                entry.UID = repo.id.ToString();

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
