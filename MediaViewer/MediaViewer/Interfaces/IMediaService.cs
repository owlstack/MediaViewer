using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaViewer.Models;

namespace MediaViewer.Interfaces
{
    public interface IMediaService
    {
        Task<Image> GetImage(string id);
        Task<VideoObject> GetVideo(string id);
        Task<Image> GetCloudImages();
        Task<Image> GetCarImages();
        Task<Image> GetCityImages();
        Task<Image> GetCatImages();
        Task<List<VideoObject>> GetCloudVideos();
        Task<List<VideoObject>> GetCarVideos();
        Task<List<VideoObject>> GetCityVideos();
        Task<List<VideoObject>> GetCatVideos();

    }
}
