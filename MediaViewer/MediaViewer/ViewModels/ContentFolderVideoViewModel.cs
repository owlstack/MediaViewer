using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MediaViewer.Interfaces;
using MediaViewer.Models;
using Prism.Navigation;
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

        private ICommand _itemTappedCommand;
        public ICommand ItemTappedCommand => _itemTappedCommand ?? (_itemTappedCommand = new Command(OnItemTapped));

        public ContentFolderVideoViewModel(INavigationService navigationService, IMediaService mediaService) : base(navigationService)
		{
            _mediaService = mediaService;
        }

        //before the view loads, start to display video image thumbnails 
        public override async void OnNavigatingTo(NavigationParameters navParams)
        {
            if (navParams.ContainsKey("query"))
            {
                var query = (string)navParams["query"];
                IsBusy = true;
                await DisplayVideos(query);
                IsBusy = false;

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
        }

    }
}