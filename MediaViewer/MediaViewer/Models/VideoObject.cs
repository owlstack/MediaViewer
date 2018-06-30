using System;
using System.Collections.Generic;
using System.Text;

namespace MediaViewer.Models
{
    public class VideoObject
    {
        public int Total { get; set; }

        public int TotalHits { get; set; }

        public List<Hits> Hits { get; set; }
    }

    public class Hits
    {
        public int Id { get; set; }
        public string PageURL { get; set; }

        public string Type { get; set; }

        public string Tags { get; set; }

        public int duration { get; set; }

        public string  Picture_Id {get;set;}

        public List<Video> Videos { get; set; }

        public int Views { get; set; }

        public int Downloads { get; set; }

        public int Favorites { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }

        public int User_Id { get; set; }

        public string User { get; set; }

        public string userImageUrl { get; set; }
    }

    public class Video
    {
        public VideoSize Size { get; set; }
    }

    public class VideoSize
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Size { get; set; }
    }
}
