using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Sia11.Tests.PageObjects.AddressesOverview;
using Sia11.Tests.Utils;

namespace Sia11.Tests.PageObjects.Shared.MenuController
{
    public class LoggedInMenuController : MenuControllerCommon
    {
        public LoggedInMenuController(IWebDriver driver) : base(driver)
        {
        }

        private By Addresses => By.CssSelector("a[data-test='addresses']");
        private IWebElement BtnAddresses => _driver.FindElement(Addresses);

        private IWebElement BtnSignOut => _driver.FindElement(By.CssSelector(""));

        private IWebElement LblCurrentUser => _driver.FindElement(By.XPath("//span[@data-test='current-user']"));

        public AddressesOverviewPage NavigateToAddressesOverview()
        {
            _driver.WaitForElement(Addresses);

            BtnAddresses.Click();

            return new AddressesOverviewPage(_driver);
        }

        public string CurrentUser => LblCurrentUser.Text;
    }
}
