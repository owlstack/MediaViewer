using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaViewer.Models
{
    public class Image
    {
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        [JsonProperty(PropertyName = "totalHits")]
        public int TotalHits { get; set; }
        [JsonProperty(PropertyName = "hits")]
        public List<ImageDescription> Hits { get; set; }

        public class ImageDescription
        {
            [JsonProperty(PropertyName = "id")]
            public int Id { get; set; }
            [JsonProperty(PropertyName = "pageURL")]
            public string PageURL { get; set; }
            [JsonProperty(PropertyName = "type")]
            public string Type { get; set; }
            [JsonProperty(PropertyName = "tags")]
            public string Tags { get; set; }
            [JsonProperty(PropertyName = "previewURL")]
            public string PreviewUrl { get; set; }
            [JsonProperty(PropertyName = "previewWidth")]
            public int PreviewWidth { get; set; }
            [JsonProperty(PropertyName = "previewHeight")]
            public int PreviewHeight { get; set; }
            [JsonProperty(PropertyName = "webformatURL")]
            public string WebformatUrl { get; set; }
            [JsonProperty(PropertyName = "webformatWidth")]
            public int WebformatWidth { get; set; }
            [JsonProperty(PropertyName = "webformatHeight")]
            public int WebformatHeight { get; set; }
            [JsonProperty(PropertyName = "largeImageURL")]
            public string LargeImageUrl { get; set; }
            [JsonProperty(PropertyName = "fullHDURL")]
            public string FullHDUrl {get;set;}
            [JsonProperty(PropertyName = "imageURL")]
            public string ImageURL { get; set; }
            [JsonProperty(PropertyName = "imageWidth")]
            public int ImageWidth { get; set; }
            [JsonProperty(PropertyName = "imageHeight")]
            public int ImageHeight { get; set; }
            [JsonProperty(PropertyName = "imageSize")]
            public int ImageSize { get; set; }
            [JsonProperty(PropertyName = "views")]
            public int Views { get; set; }
        
        }
    }
}
