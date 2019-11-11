using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.API.Models
{
    public class StoryblokResult : IResult
    {
        public Story[] stories { get; set; }
    }

    public class Story
    {
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime published_at { get; set; }
        public object[] alternates { get; set; }
        public int id { get; set; }
        public string uuid { get; set; }
        public Content content { get; set; }
        public string slug { get; set; }
        public string full_slug { get; set; }
        public object sort_by_date { get; set; }
        public int position { get; set; }
        public object[] tag_list { get; set; }
        public bool is_startpage { get; set; }
        public int parent_id { get; set; }
        public object meta_data { get; set; }
        public string group_id { get; set; }
        public DateTime first_published_at { get; set; }
        public object release_id { get; set; }
        public string lang { get; set; }
        public object path { get; set; }
    }

    public class Content
    {
        public string _uid { get; set; }
        public Body[] body { get; set; }
        public string component { get; set; }
        public string shortdescription { get; set; }
    }

    public class Body
    {
        public string _uid { get; set; }
        public string name { get; set; }
        public string component { get; set; }
        public string super_duper_class { get; set; }
        public string big_time_content { get; set; }
        public string general_nonsense { get; set; }
    }

}
