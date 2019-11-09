using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.API.Models
{
    public class SoundCloudClient : IClient
    {
        public string BaseAddress { get; set; }

        public SoundCloudClient()
        {
            this.BaseAddress = "";
        }


        public SoundCloudResult GetData()
        {
            throw new NotImplementedException();
        }
    }
}
