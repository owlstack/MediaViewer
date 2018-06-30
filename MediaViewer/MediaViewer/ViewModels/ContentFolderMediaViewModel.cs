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

        public override void OnNavigatingTo(NavigationParameters navParams)
        {
            if(navParams.ContainsKey("query"))
            {
                if((string)navParams["query"] == "Cats")
                {
                    DisplayCatImages();
                }else if((string)navParams["query"] == "Cars")
                {
                    DisplayCarImages();
                }
                else if ((string)navParams["query"] == "Cities")
                {
                    DisplayCityImages();
                }else 
                {
                    DisplayCloudImages();
                }
            }
        }

        private async void OnItemTapped(object sender)
        {
            var navParams = new NavigationParameters();
            navParams.Add("id", sender);
            await NavigationService.NavigateAsync("ContentFolderMediaDetail", navParams);
        }

        
        private async Task DisplayCatImages()
        {
            var imageObj = await _mediaService.GetCatImages();
            Images = imageObj.Hits;
        }

        private async Task DisplayCarImages()
        {
            var imageObj = await _mediaService.GetCarImages();
            Images = imageObj.Hits;
        }
        private async Task DisplayCityImages()
        {
            var imageObj = await _mediaService.GetCityImages();
            Images = imageObj.Hits;
        }
        private async Task DisplayCloudImages()
        {
            var imageObj = await _mediaService.GetCloudImages();
            Images = imageObj.Hits;
        }
    }
}
