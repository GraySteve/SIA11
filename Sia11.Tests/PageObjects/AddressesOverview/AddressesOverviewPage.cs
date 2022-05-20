using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        private IList<IWebElement> LstAddresses =>
            _driver.FindElements(By.CssSelector("tbody tr"));

        private IWebElement BtnEdit(string addressName) =>
            LstAddresses.FirstOrDefault(element => element.Text.Contains(addressName))
                .FindElement(By.CssSelector("a[data-test*=edit]"));

        private IWebElement BtnDelete(string addressName) =>
            LstAddresses.FirstOrDefault(element => element.Text.Contains(addressName))
                .FindElement(By.CssSelector("a[data-test*=destroy]"));

        private IWebElement BtnNewAddress => 
            _driver.FindElement(By.CssSelector("a[data-test=create]"));

        public AddEditAddressPage NavigateToEditAddressPage(string addressName)
        {
            Thread.Sleep(2000);
            BtnEdit(addressName).Click();
            return new AddEditAddressPage(_driver);
        }

        public AddEditAddressPage NavigateToAddAddressPage()
        {
            BtnNewAddress.Click();
            return new AddEditAddressPage(_driver);
        }
    }
}
