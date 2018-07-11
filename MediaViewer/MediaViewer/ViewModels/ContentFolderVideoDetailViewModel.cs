using MediaViewer.Interfaces;
using MediaViewer.Models;
using Prism.Navigation;

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
            //NOTE: Since Pixabay API videos are Vimeo videos, I need an PRO subscription. 
            //Instead of hitting the correct video urls, I hardcoded the video url below to show that the app can play videos.
            if (navParams.ContainsKey("id"))
            {
                var videoObj = navParams.GetValue<Hit>("id"); //To show I can access the videoObj from Pixabay. Won't use right now due to issue highlighted above 
               // SelectedVideo = videoObj.Videos.Medium.Url; //Normally I would set it like this but won't use. 
                SelectedVideo = "https://storage.googleapis.com/coverr-main/mp4/Sky-High.mp4";
                
            }
        }
    }
}