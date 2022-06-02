using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sia11.Tests.PageObjects.Login;
using Sia11.Tests.PageObjects.Shared.MenuController;

namespace Sia11.Tests
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [TestInitialize]
        public void StartUp()
        {
            //Open browser
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            //navigate to URL
            _driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click on signIn
            //_driver.FindElement(by: By.XPath("/html/body/nav/div/div[1]/a[2]")).Click();
            var menu = new LoggedOutMenuController(_driver);

            _loginPage = menu.NavigateToLoginPage();
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldLoginSuccessfully()
        {
            _loginPage.LoginWith("test@test.test", "test");
            //Assert
            var menu = new LoggedInMenuController(_driver);
            Assert.AreEqual("test@test.test", menu.CurrentUser);
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldNotLoginSuccessfullyWhenEmailIsInvalid()
        {
            _loginPage.LoginWith("test1@test1.test1", "test");
            
            //Assert
            Assert.AreEqual("Bad email or password.", _loginPage.LblValidation.Text);
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldNotLoginSuccessfullyWhenPasswordIsInvalid()
        {
            _loginPage.LoginWith("test@test.test", "test25178357821361");
            
            //Assert
            Assert.AreEqual("Bad email or password.", _loginPage.LblValidation.Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            //Close browser
            _driver.Quit();
        }

    }
}