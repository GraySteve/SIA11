using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Sia11.Tests.PageObjects.AddAddress;
using Sia11.Tests.Utils;

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

        private By NewAddress => By.CssSelector("a[data-test=create]");
        private IWebElement BtnNewAddress => 
            _driver.FindElement(NewAddress);

        public AddEditAddressPage NavigateToEditAddressPage(string addressName)
        {
            _driver.WaitForElement(NewAddress);
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
