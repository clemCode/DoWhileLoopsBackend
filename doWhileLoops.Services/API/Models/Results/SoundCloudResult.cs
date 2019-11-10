using System;
using System.Collections.Generic;
using System.Text;

namespace doWhileLoops.Services.API.Models
{
    public class SoundCloudResult : IResult
    {
        public Collection[] collection { get; set; }
        public string next_href { get; set; }
        public object query_urn { get; set; }
    }

    public class Collection
    {
        public int comment_count { get; set; }
        public int full_duration { get; set; }
        public bool downloadable { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public Media media { get; set; }
        public string title { get; set; }
        public Publisher_Metadata publisher_metadata { get; set; }
        public int duration { get; set; }
        public bool has_downloads_left { get; set; }
        public object artwork_url { get; set; }
        public bool _public { get; set; }
        public bool streamable { get; set; }
        public string tag_list { get; set; }
        public object download_url { get; set; }
        public string genre { get; set; }
        public int id { get; set; }
        public int reposts_count { get; set; }
        public string state { get; set; }
        public object label_name { get; set; }
        public DateTime last_modified { get; set; }
        public bool commentable { get; set; }
        public string policy { get; set; }
        public object visuals { get; set; }
        public string kind { get; set; }
        public object purchase_url { get; set; }
        public string sharing { get; set; }
        public string uri { get; set; }
        public object secret_token { get; set; }
        public int download_count { get; set; }
        public int likes_count { get; set; }
        public string urn { get; set; }
        public string license { get; set; }
        public object purchase_title { get; set; }
        public DateTime display_date { get; set; }
        public string embeddable_by { get; set; }
        public object release_date { get; set; }
        public int user_id { get; set; }
        public string monetization_model { get; set; }
        public string waveform_url { get; set; }
        public string permalink { get; set; }
        public string permalink_url { get; set; }
        public User user { get; set; }
        public int playback_count { get; set; }
    }

    public class Media
    {
        public Transcoding[] transcodings { get; set; }
    }

    public class Transcoding
    {
        public string url { get; set; }
        public string preset { get; set; }
        public int duration { get; set; }
        public bool snipped { get; set; }
        public Format format { get; set; }
        public string quality { get; set; }
    }

    public class Format
    {
        public string protocol { get; set; }
        public string mime_type { get; set; }
    }

    public class Publisher_Metadata
    {
        public string urn { get; set; }
        public bool contains_music { get; set; }
        public int id { get; set; }
    }

    public class User
    {
        public string avatar_url { get; set; }
        public string first_name { get; set; }
        public string full_name { get; set; }
        public int id { get; set; }
        public string kind { get; set; }
        public DateTime last_modified { get; set; }
        public string last_name { get; set; }
        public string permalink { get; set; }
        public string permalink_url { get; set; }
        public string uri { get; set; }
        public string urn { get; set; }
        public string username { get; set; }
        public bool verified { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
    }
}
