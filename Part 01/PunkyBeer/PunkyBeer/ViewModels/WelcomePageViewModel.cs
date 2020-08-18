using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;

namespace PunkyBeer.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {
        private ICommand _continueCommand;

        public ICommand ContinueCommand
        {
            get { return _continueCommand; }
            set { SetProperty(ref _continueCommand, value); }
        }
        public WelcomePageViewModel(INavigationService navigationService)
            : base (navigationService)
        {
            ContinueCommand = new DelegateCommand(ContinueToMainPage);
        }

        private async void ContinueToMainPage()
        {
            await NavigationService.NavigateAsync("../MainPage");
        }
    }
}
