using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using MediaViewer.Interfaces;
using MediaViewer.Models;
using static MediaViewer.Models.Image;

namespace MediaViewer.ViewModels
{
    public class ContentFolderMediaDetailViewModel : ViewModelBase
    {
        private IMediaService _mediaService;

        private string selectedImage;
        public string SelectedImage
        {
            get { return selectedImage; }
            set { SetProperty(ref selectedImage, value); }
        }

        private VideoObject selectedVideo;
        public VideoObject SelectedVideo
        {
            get { return selectedVideo; }
            set { SetProperty(ref selectedVideo, value); }
        }

        public ContentFolderMediaDetailViewModel(INavigationService navigationService, IMediaService mediaService) : base(navigationService)
        {
            _mediaService = mediaService;
        }

        public override void OnNavigatedTo(NavigationParameters navParams)
        {
            if (navParams.ContainsKey("id"))
            {
                var imageObj = navParams.GetValue<ImageDescription>("id");
                SelectedImage = imageObj.LargeImageUrl;

            }
        }
    }
}
