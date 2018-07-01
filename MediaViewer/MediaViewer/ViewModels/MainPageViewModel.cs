using MediaViewer.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MediaViewer.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Input;

namespace MediaViewer.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IMediaService _mediaService;
        private ICommand imageTapCommand;
        public ICommand ImageTapCommand
        {
            get { return imageTapCommand; }
        }

        private int carsTotal;
        public int CarsTotal
        {
            get { return carsTotal; }
            set { SetProperty(ref carsTotal, value); }
        }

        private int catsTotal;
        public int CatsTotal
        {
            get { return catsTotal; }
            set { SetProperty(ref catsTotal, value); }
        }

        private int citiesTotal;
        public int CitiesTotal
        {
            get { return citiesTotal; }
            set { SetProperty(ref citiesTotal, value); }
        }

        private int cloudsTotal;
        public int CloudsTotal
        {
            get { return cloudsTotal; }
            set { SetProperty(ref cloudsTotal, value); }
        }

        public MainPageViewModel(INavigationService navigationService, IMediaService mediaService) : base (navigationService)
        {
            Title = "Content Folders";
            imageTapCommand = new Command(Navigate);
            _mediaService = mediaService;
        }

        private async void Navigate(object sender)
        {
            var navParams = new NavigationParameters();
            navParams.Add("query", sender);

            if ((string)sender != "Clouds")
            {
                await NavigationService.NavigateAsync("ContentFolderMedia", navParams);
            }else
            {
                await NavigationService.NavigateAsync("ContentFolderVideo", navParams);
            }
        }

        public override async void OnNavigatingTo(NavigationParameters navParams)
        {
            var catsObj = await _mediaService.GetImages("Cats");
            CatsTotal = catsObj.Total;
            var carsObj = await _mediaService.GetImages("Cars");
            CarsTotal = carsObj.Total;
            var citiesObj = await _mediaService.GetImages("Cities");
            CitiesTotal = citiesObj.Total;
            //   var cloudsObj = await _mediaService.GetImages("Clouds");
            var cloudsObj = await _mediaService.GetVideoStats("Clouds");
            CloudsTotal = cloudsObj.Total;
        }
        
    }
}
