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
        private ICommand imageTapCommand;
        public ICommand ImageTapCommand
        {
            get { return imageTapCommand; }
        }
        //    public DelegateCommand NavigateCommand => new DelegateCommand(Navigate);
        public MainPageViewModel(INavigationService navigationService) : base (navigationService)
        {
            Title = "Content Folders";
            imageTapCommand = new Command(Navigate);
            
        }

        private async void Navigate(object sender)
        {
            var navParams = new NavigationParameters();
            navParams.Add("query", sender);
            await NavigationService.NavigateAsync("ContentFolderMedia", navParams);
        }
        
    }
}
