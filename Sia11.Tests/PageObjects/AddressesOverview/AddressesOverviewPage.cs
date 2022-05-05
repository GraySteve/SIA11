using OpenQA.Selenium;

namespace Sia11.Tests.PageObjects.AddressesOverview
{
    public class AddressesOverviewPage
    {
        private IWebDriver _driver;

        public AddressesOverviewPage(IWebDriver browser)
        {
            _driver = browser;
        }
    }
}
