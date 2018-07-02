using MediaViewer.Interfaces;
using MediaViewer.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MediaViewer.ViewModels
{
	public class ContentFolderVideoDetailViewModel : ViewModelBase
	{
        private readonly IMediaService _mediaService;

        private string selectedVideo;
        public string SelectedVideo
        {
            get { return selectedVideo; }
            set { SetProperty(ref selectedVideo, value); }
        }
        public ContentFolderVideoDetailViewModel (INavigationService navigationService, IMediaService mediaService) : base(navigationService)
		{
            _mediaService = mediaService;
        }

        //Get video object that was saved from previous view and set page SelectedVideo to video (medium size) url. 
        public override void OnNavigatingTo(NavigationParameters navParams)
        {
            if (navParams.ContainsKey("id"))
            {
                var videoObj = navParams.GetValue<Hit>("id");
                //   SelectedVideo = videoObj.Videos.Medium.Url;
                SelectedVideo = "https://storage.googleapis.com/coverr-main/mp4/Coconut-Grove.mp4";
                
            }
        }
    }
}