using OpenQA.Selenium;
using Sia11.Tests.PageObjects.AddressesOverview;
using Sia11.Tests.PageObjects.Shared.MenuController;

namespace Sia11.Tests.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver browserDriver)
        {
            _driver = browserDriver;
        }

        private LoggedInMenuController Menu => new LoggedInMenuController(_driver);

        public AddressesOverviewPage NavigateToAddressesOverviewPage() => Menu.NavigateToAddressesOverview();
    }
}
