using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.API.Models
{
    public class GitHubClient : IClient<GitHubResult>
    {
        public string BaseAddress { get; set; }

        public GitHubClient()
        {
            this.BaseAddress = "";
        }
        
        public GitHubResult GetData()
        {
            throw new NotImplementedException();
        }
    }
}
