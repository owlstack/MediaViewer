using MediaViewer.Interfaces;
using MediaViewer.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MediaViewer.ViewModels
{
	public class ContentFolderVideoViewModel : ViewModelBase
	{
        private readonly IMediaService _mediaService;

        private List<Hit> videos;
        public List<Hit> Videos
        {
            get { return videos; }
            set { SetProperty(ref videos, value); }
        }

        private string pictureId;
        public string PictureId
        {
            get { return pictureId; }
            set { SetProperty(ref pictureId, value); }
        }

        private ICommand itemTappedCommand;
        public ICommand ItemTappedCommand
        {
            get { return itemTappedCommand; }
        }

        public ContentFolderVideoViewModel(INavigationService navigationService, IMediaService mediaService) : base(navigationService)
		{
            _mediaService = mediaService;
            itemTappedCommand = new Command(OnItemTapped);
        }

        //before the view loads, start to display video image thumbnails 
        public override async void OnNavigatingTo(NavigationParameters navParams)
        {
            if (navParams.ContainsKey("query"))
            {
                var query = (string)navParams["query"];
                await DisplayVideos(query);

            }
        }

        //On clicking on a video thumbnail image, save the object in NavigationParamters and navigate to detail page
        private async void OnItemTapped(object sender)
        {
            var navParams = new NavigationParameters();
            navParams.Add("id", sender);
            await NavigationService.NavigateAsync("ContentFolderVideoDetail", navParams);
        }

        //display video image thumbnails from api endpoint 
        private async Task DisplayVideos(string query)
        {
            var videoObj = await _mediaService.GetVideos(query);
            Videos = videoObj.Hits;
            var size = "640x360";
            var picIdList = videoObj.Hits.Select(x=>x.Picture_id).ToList();
            
            foreach (var pic in picIdList)
            {
                PictureId = $"https://i.vimeocdn.com/video/{pic}_{size}.jpg";
            }
        }

    }
}