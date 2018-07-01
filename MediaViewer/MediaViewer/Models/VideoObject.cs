using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaViewer.Models
{
    public class VideoObject
    {
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        [JsonProperty(PropertyName = "totalHits")]
        public int TotalHits { get; set; }
        [JsonProperty(PropertyName = "hits")]
        public List<Hit> Hits { get; set; }
    }

    public class Hit
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "pageURL")]
        public string PageURL { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; set; }
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }
        [JsonProperty(PropertyName = "picture_id")]
        public string Picture_id { get; set; }
        [JsonProperty(PropertyName = "videos")]
        public Videos Videos { get; set; }
        [JsonProperty(PropertyName = "views")]
        public int Views { get; set; }
        [JsonProperty(PropertyName = "downloads")]
        public int Downloads { get; set; }
        [JsonProperty(PropertyName = "favorites")]
        public int Favorites { get; set; }
        [JsonProperty(PropertyName = "likes")]
        public int Likes { get; set; }
        [JsonProperty(PropertyName = "comments")]
        public int Comments { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public int User_id { get; set; }
        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }
        [JsonProperty(PropertyName = "userImageURL")]
        public string UserImageURL { get; set; }
    }

    public class Videos
    {
        [JsonProperty(PropertyName = "large")]
        public Large Large { get; set; }
        [JsonProperty(PropertyName = "medium")]
        public Medium Medium { get; set; }
        [JsonProperty(PropertyName = "small")]
        public Small Small { get; set; }
        [JsonProperty(PropertyName = "tiny")]
        public Tiny Tiny { get; set; }
    }
    public class Large
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
    }

    public class Medium
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
    }

    public class Small
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
    }

    public class Tiny
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
    }
    
}
