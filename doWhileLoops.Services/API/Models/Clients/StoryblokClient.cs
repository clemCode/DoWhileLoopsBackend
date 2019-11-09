using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.API.Models
{
    public class StoryblokClient : IClient<StoryblokResult>
    {
        public string BaseAddress { get; set; }

        public StoryblokClient()
        {
            this.BaseAddress = "";
        }

        public StoryblokResult GetData()
        {
            throw new NotImplementedException();
        }
    }
}
