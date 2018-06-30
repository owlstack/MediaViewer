using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using MediaViewer.Interfaces;
using MediaViewer.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using static MediaViewer.Models.Image;
using System.Windows.Input;
using Prism.Commands;
using Xamarin.Forms;

namespace MediaViewer.ViewModels
{
    public class ContentFolderMediaViewModel : ViewModelBase
    {
        private readonly IMediaService _mediaService;
       
        private List<string> videos;
        public List<string> Videos
        {
            get { return videos; }
            set { SetProperty(ref videos, value); }
        }
        
        private List<ImageDescription> images;
        public List<ImageDescription> Images
        {
            get { return images; }
            set { SetProperty(ref images, value); }
        }
        private ICommand itemTappedCommand;
        public ICommand ItemTappedCommand
        {
            get { return itemTappedCommand; }
        }

        public ContentFolderMediaViewModel(INavigationService navigationService, IMediaService mediaService) : base(navigationService)
        {
            _mediaService = mediaService;
            itemTappedCommand = new Command(OnItemTapped);
        }

        public override async void OnNavigatingTo(NavigationParameters navParams)
        {
            if(navParams.ContainsKey("query"))
            {
                var query = (string)navParams["query"];
                await DisplayImages(query);
             
            }
        }

        private async void OnItemTapped(object sender)
        {
            var navParams = new NavigationParameters();
            navParams.Add("id", sender);
            await NavigationService.NavigateAsync("ContentFolderMediaDetail", navParams);
        }
        
        private async Task DisplayImages(string query)
        {
            var imageObj = await _mediaService.GetImages(query);
            Images = imageObj.Hits;
        }
        
    }
}
