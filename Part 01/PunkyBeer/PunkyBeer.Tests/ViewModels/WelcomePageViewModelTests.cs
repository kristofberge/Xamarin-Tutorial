using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Prism.Navigation;
using PunkyBeer.ViewModels;
using Xunit;

namespace PunkyBeer.Tests.ViewModels
{
    public class WelcomePageViewModelTests
    {
        WelcomePageViewModel _welcomeViewModel;

        Mock<INavigationService> _navigationService;

        public WelcomePageViewModelTests()
        {
            _navigationService = new Mock<INavigationService>();

            _welcomeViewModel = new WelcomePageViewModel(_navigationService.Object);
        }

        [Fact]
        public void ContinueButtonNavigatesToMainPage()
        {
            // Arrange
            
            // Act
            _welcomeViewModel.ContinueCommand.Execute(null);

            // Assert
            _navigationService.Verify(x => x.NavigateAsync("../MainPage"), Times.Once);
        }
    }
}
