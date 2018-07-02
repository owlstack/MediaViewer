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

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public ContentFolderMediaViewModel(INavigationService navigationService, IMediaService mediaService) : base(navigationService)
        {
            _mediaService = mediaService;
            itemTappedCommand = new Command(OnItemTapped);
        }

        //Before the view finishes loading, call display images. 
        public override async void OnNavigatingTo(NavigationParameters navParams)
        {
            if(navParams.ContainsKey("query"))
            {
                var query = (string)navParams["query"];
                IsBusy = true;
                await DisplayImages(query);
                IsBusy = false;
               
            }
        }

        //When selecting an image thumbnail, get the sender info and save it in NavigationParameters.
        //Then navigate to next page
        private async void OnItemTapped(object sender)
        {
            var navParams = new NavigationParameters();
            navParams.Add("id", sender);
            await NavigationService.NavigateAsync("ContentFolderMediaDetail", navParams);
        }
        
        //Displays image thumbnails from api endpoint
        private async Task DisplayImages(string query)
        {
            var imageObj = await _mediaService.GetImages(query);
            Images = imageObj.Hits;
        }
    }
}
