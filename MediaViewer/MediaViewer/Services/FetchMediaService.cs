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
        public async Task<Image> GetCatImages()
        {
            string query = "cats";
            return await GetRequestAsync<Image>(_baseImageUrl + $"?key={_apiKey}&q={query}&image_type=photo");
        }

        public async Task<Image> GetCityImages()
        {
            string query = "cities";
            return await GetRequestAsync<Image>(_baseImageUrl + $"?key={_apiKey}&q={query}&image_type=photo");
        }

        public async Task<Image> GetCloudImages()
        {
            string query = "clouds";
            return await GetRequestAsync<Image> (_baseImageUrl + $"?key={_apiKey}&q={query}&image_type=photo");
        }
        public async Task<Image> GetCarImages()
        {
            string query = "cars";
            return await GetRequestAsync<Image>(_baseImageUrl + $"?key={_apiKey}&q={query}&image_type=photo");
        }

        public async Task<List<VideoObject>> GetCatVideos()
        {
            string query = "cats";
            return await GetRequestAsync<List<VideoObject>>(_baseVideoUrl + $"?key={_apiKey}&q={query}");
        }

        public async Task<List<VideoObject>> GetCityVideos()
        {
            string query = "cities";
            return await GetRequestAsync<List<VideoObject>>(_baseVideoUrl + $"?key={_apiKey}&q={query}");
        }

        public async Task<List<VideoObject>> GetCloudVideos()
        {
            string query = "clouds";
            return await GetRequestAsync<List<VideoObject>>(_baseVideoUrl + $"?key={_apiKey}&q={query}");
        }
        public async Task<List<VideoObject>> GetCarVideos()
        {
            string query = "cars";
            return await GetRequestAsync<List<VideoObject>>(_baseVideoUrl + $"?key={_apiKey}&q={query}");
        }


        public async Task<Image> GetImage(string id)
        {
            string query = "";
            return await GetRequestAsync<Image>(_baseImageUrl + $"?key={_apiKey}&q={query}&image_type=photo");
        }

        public async Task<VideoObject> GetVideo(string id)
        {
            string query = "";
            return await GetRequestAsync<VideoObject>(_baseVideoUrl + $"?key={_apiKey}&q={query}");
        }
    }
}
