using doWhileLoops.Services.Storage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace doWhileLoops.Services.API.Models
{
    public interface IClient<TResult> where TResult : IResult
    {
        TableClient tableClient { get; set; }
        HttpClient httpClient { get; set; }

        string baseAddress { get; set; }

        string urlParams { get; set; }
        
        Task<TResult> GetSourceData();
        IEnumerable<ExternalAPIEntry> ParseData(TResult result);
        void WriteResultToTable(IEnumerable<ExternalAPIEntry> result);
        Task GetDataAndWriteResult();        
    }
}
