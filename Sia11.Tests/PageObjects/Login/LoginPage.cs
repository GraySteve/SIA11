using System.Threading;
using OpenQA.Selenium;
using Sia11.Tests.PageObjects.Home;

namespace Sia11.Tests.PageObjects.Login
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver browser)
        {
            _driver = browser;
        }

        private IWebElement TxtEmail => _driver.FindElement(By.Name("session[email]"));
        private IWebElement TxtPassword => _driver.FindElement(By.CssSelector("input[placeholder='Password']"));
        private IWebElement BtnLogin => _driver.FindElement(By.XPath("//input[@class='btn btn-primary']"));
        public IWebElement LblValidation => _driver.FindElement(By.XPath("//div[@data-test='notice']"));


        public HomePage LoginWith(string email, string pass)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(pass);

            BtnLogin.Click();
            Thread.Sleep(2000);
            return new HomePage(_driver);
        }

    }
}
