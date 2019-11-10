using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using doWhileLoops.Services.Storage;

namespace doWhileLoops.Services.API.Models
{
    public class GitHubClient : IClient<GitHubResult>
    {
        public TableClient tableClient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public HttpClient httpClient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string baseAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string urlParams { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task GetDataAndWriteResult()
        {
            throw new NotImplementedException();
        }

        public Task<GitHubResult> GetSourceData()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExternalAPIEntry> ParseData(GitHubResult result)
        {
            throw new NotImplementedException();
        }

        public void WriteResultToTable(IEnumerable<ExternalAPIEntry> result)
        {
            throw new NotImplementedException();
        }
    }
}
