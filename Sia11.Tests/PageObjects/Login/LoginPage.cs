using System.Threading;
using OpenQA.Selenium;
using Sia11.Tests.PageObjects.Home;
using Sia11.Tests.Utils;

namespace Sia11.Tests.PageObjects.Login
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver browser)
        {
            _driver = browser;
        }

        private By Email => By.Name("session[email]");
        private IWebElement TxtEmail => _driver.FindElement(Email);
        private IWebElement TxtPassword => _driver.FindElement(By.CssSelector("input[placeholder='Password']"));
        private IWebElement BtnLogin => _driver.FindElement(By.XPath("//input[@class='btn btn-primary']"));
        public IWebElement LblValidation => _driver.FindElement(By.XPath("//div[@data-test='notice']"));


        public HomePage LoginWith(string email, string pass)
        {
            _driver.WaitForElement(Email);
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(pass);

            BtnLogin.Click();
 
            return new HomePage(_driver);
        }

    }
}
