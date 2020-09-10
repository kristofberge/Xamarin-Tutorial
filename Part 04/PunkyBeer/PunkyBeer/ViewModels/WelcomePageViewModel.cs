using System;
using System.Diagnostics;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using PunkyBeer.Services;

namespace PunkyBeer.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {

        private string _userName = string.Empty;

#nullable disable
        private ICommand _continueCommand;
        private readonly IUserService _userService;
#nullable restore

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public ICommand ContinueCommand
        {
            get { return _continueCommand; }
            set { SetProperty(ref _continueCommand, value); }
        }

        public WelcomePageViewModel(INavigationService navigationService, IUserService userService)
            : base (navigationService)
        {
            _userService = userService;

            ContinueCommand = new DelegateCommand(ContinueToMainPage);
        }

        private async void ContinueToMainPage()
        {
            try
            {
                if (!(UserName is { Length: 0 }))
                {
                    await _userService.SetUserName(UserName);
                    await NavigationService.NavigateAsync("../MainPage"); 
                }
            }
            catch (Exception ex)
            {
                // TODO add better error logging
                Debug.Fail(ex.Message);
            }
        }
    }
}
