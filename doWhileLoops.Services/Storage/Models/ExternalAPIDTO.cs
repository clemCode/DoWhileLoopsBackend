using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.Storage
{
    public class ExternalAPIDTO
    {
        public ExternalAPIDTO(ExternalAPIEntry entry)
        {
            Source = entry.PartitionKey;
            Slug = entry.RowKey;
            Title = entry.Title;
            ShortDescription = entry.ShortDescription;
            URL = entry.URL;
            UID = entry.UID;
        }

        public string Source { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string URL { get; set; }
        public string UID { get; set; }
    }
}
