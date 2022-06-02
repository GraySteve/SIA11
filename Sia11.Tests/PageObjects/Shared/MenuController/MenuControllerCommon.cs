using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Sia11.Tests.PageObjects.Home;

namespace Sia11.Tests.PageObjects.Shared.MenuController
{
    public class MenuControllerCommon
    {
        public IWebDriver _driver;

        public MenuControllerCommon(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement BtnHome => _driver.FindElement(By.CssSelector(""));

        public HomePage NavigateToHome()
        {
            BtnHome.Click();

            return new HomePage(_driver);
        }
    }
}
