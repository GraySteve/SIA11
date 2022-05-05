using OpenQA.Selenium;
using Sia11.Tests.PageObjects.AddAddress;

namespace Sia11.Tests.PageObjects.AddressesOverview
{
    public class AddressesOverviewPage
    {
        private IWebDriver _driver;

        public AddressesOverviewPage(IWebDriver browser)
        {
            _driver = browser;
        }

        private IWebElement BtnNewAddress => 
            _driver.FindElement(By.CssSelector("a[data-test=create]"));


        public AddAddressPage NavigateToAddAddressPage()
        {
            BtnNewAddress.Click();
            return new AddAddressPage(_driver);
        }
    }
}
