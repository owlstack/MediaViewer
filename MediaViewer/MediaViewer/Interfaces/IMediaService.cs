using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaViewer.Models;

namespace MediaViewer.Interfaces
{
    public interface IMediaService
    {
        Task<Image> GetImages(string query);
        Task<VideoObject> GetVideo(string query);

    }
}
