using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MediaViewer.Interfaces;
using MediaViewer.Models;

namespace MediaViewer.Services
{
    public class FetchMediaService : BaseProvider, IMediaService
    {
        public FetchMediaService()
        {
            _baseImageUrl = "https://pixabay.com/api/";
            _baseVideoUrl = "https://pixabay.com/api/videos/";
        }
   
        public async Task<Image> GetImages(string query)
        {
            return await GetRequestAsync<Image>(_baseImageUrl + $"?key={_apiKey}&q={query}&image_type=photo");
        }

        public async Task<VideoObject> GetVideos(string query)
        {
            return await GetRequestAsync<VideoObject>(_baseVideoUrl + $"?key={_apiKey}&q={query}");
        }
        
        public async Task<VideoObject> GetVideoStats(string query)
        {
            return await GetRequestAsync<VideoObject>(_baseVideoUrl + $"?key={_apiKey}&q={query}");
        }

    }
}
