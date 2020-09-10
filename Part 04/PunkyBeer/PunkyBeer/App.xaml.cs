using Prism;
using Prism.Ioc;
using PunkyBeer.ViewModels;
using PunkyBeer.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Prism.DryIoc;
using PunkyBeer.Services;

namespace PunkyBeer
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
            
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            await NavigationService.NavigateAsync("NavigationPage/WelcomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<ISecureStorage, SecureStorageImplementation>();
            containerRegistry.RegisterSingleton<IUserService, UserService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomePageViewModel>();
        }
    }
}
