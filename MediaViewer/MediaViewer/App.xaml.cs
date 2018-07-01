using Prism;
using Prism.Ioc;
using MediaViewer.ViewModels;
using MediaViewer.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using MediaViewer.Interfaces;
using MediaViewer.Services;
using DLToolkit.Forms.Controls;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MediaViewer
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            FlowListView.Init();
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ContentFolderMedia, ContentFolderMediaViewModel>();
            containerRegistry.RegisterForNavigation<ContentFolderMediaDetail, ContentFolderMediaDetailViewModel>();
            containerRegistry.RegisterForNavigation<ContentFolderVideo, ContentFolderVideoViewModel>();
            containerRegistry.RegisterForNavigation<ContentFolderVideoDetail, ContentFolderVideoDetailViewModel>();
            containerRegistry.Register<IMediaService, FetchMediaService>();
        }
    }
}
