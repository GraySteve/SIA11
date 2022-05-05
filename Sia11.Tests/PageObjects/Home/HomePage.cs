using OpenQA.Selenium;
using Sia11.Tests.PageObjects.AddressesOverview;

namespace Sia11.Tests.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver browserDriver)
        {
            _driver = browserDriver;
        }

        private IWebElement BtnAddresses => _driver.FindElement(By.CssSelector("a[data-test='addresses']"));

        public AddressesOverviewPage NavigateToAddressesOverview()
        {
            BtnAddresses.Click();

            return new AddressesOverviewPage(_driver);
        }
    }
}
