using Moq;
using Prism.Navigation;
using PunkyBeer.Services;
using PunkyBeer.ViewModels;
using Xunit;

namespace PunkyBeer.Tests.ViewModels
{
    public class WelcomePageViewModelTests
    {
        WelcomePageViewModel _welcomeViewModel;

        Mock<INavigationService> _navigationService;
        Mock<IUserService> _userService;

        public WelcomePageViewModelTests()
        {
            _navigationService = new Mock<INavigationService>();
            _userService = new Mock<IUserService>();

            _welcomeViewModel = new WelcomePageViewModel(_navigationService.Object, _userService.Object);
        }

        [Fact]
        public void ContinueButtonNavigatesToMainPage()
        {
            // Arrange
            _welcomeViewModel.UserName = "Jane";
            
            // Act
            _welcomeViewModel.ContinueCommand.Execute(null);

            // Assert
            _navigationService.Verify(x => x.NavigateAsync("../MainPage"), Times.Once);
        }

        [Fact]
        public void ContinueButtonSavesUserName()
        {
            // Arrange
            _welcomeViewModel.UserName = "Jane";

            // Act
            _welcomeViewModel.ContinueCommand.Execute(null);

            // Assert
            _userService.Verify(x => x.SetUserName("Jane"), Times.Once);
        }

        [Fact]
        public void ContinueButtonDoesNothingIfUserNameIsEmpty()
        {
            // Arrange

            // Act
            _welcomeViewModel.ContinueCommand.Execute(null);

            // Assert
            _navigationService.Verify(x => x.NavigateAsync(It.IsAny<string>()), Times.Never);
            _userService.Verify(x => x.SetUserName(It.IsAny<string>()), Times.Never);
        }
    }
}
