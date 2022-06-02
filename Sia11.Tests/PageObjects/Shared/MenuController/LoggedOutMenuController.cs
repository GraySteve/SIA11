using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Sia11.Tests.PageObjects.Login;
using Sia11.Tests.Utils;

namespace Sia11.Tests.PageObjects.Shared.MenuController
{
    public class LoggedOutMenuController : MenuControllerCommon
    {
        public LoggedOutMenuController(IWebDriver driver) : base(driver)
        {
        }

        private By SignIn => By.XPath("/html/body/nav/div/div[1]/a[2]");
        private IWebElement BtnSignIn => _driver.FindElement(SignIn);

        public LoginPage NavigateToLoginPage()
        {
            _driver.WaitForElement(SignIn);

            BtnSignIn.Click();
            
            return new LoginPage(_driver);
        }
    }
}
