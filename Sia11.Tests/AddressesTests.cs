using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sia11.Tests.PageObjects.AddAddress;
using Sia11.Tests.PageObjects.Login;

namespace Sia11.Tests
{
    [TestClass]
    public class AddressesTests
    {
        private IWebDriver _driver;
        private AddAddressPage _addAddressPage;

        [TestInitialize]
        public void TestSetup()
        {
            //Open browser
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            //navigate to URL
            _driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click on signIn
            _driver.FindElement(by: By.XPath("/html/body/nav/div/div[1]/a[2]")).Click();
            Thread.Sleep(2000);
            var _loginPage = new LoginPage(_driver);
            var _homePage = _loginPage.LoginWith("test@test.test", "test");
            var _addressOverview = _homePage.NavigateToAddressesOverview();
            _addAddressPage = _addressOverview.NavigateToAddAddressPage();
        }

        [TestMethod]
        public void AddAddress()
        {
            _addAddressPage.AddAddress("First name", "Last name", "address1", "California", "Canada", "Iasi", "zipcode");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}