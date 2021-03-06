using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sia11.Tests.PageObjects.AddAddress;
using Sia11.Tests.PageObjects.AddAddress.InputData;
using Sia11.Tests.PageObjects.AddressesOverview;
using Sia11.Tests.PageObjects.Login;
using Sia11.Tests.PageObjects.Shared.MenuController;

namespace Sia11.Tests
{
    [TestClass]
    public class AddressesTests
    {
        private IWebDriver _driver;
        private AddEditAddressPage _addAddressPage;
        private AddressesOverviewPage _addressOverviewPage;

        [TestInitialize]
        public void TestSetup()
        {
            //Open browser
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            //navigate to URL
            _driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click on signIn
            //_driver.FindElement(by: By.XPath("/html/body/nav/div/div[1]/a[2]")).Click();
            var loggedOutMenu = new LoggedOutMenuController(_driver);
           
            var _loginPage = loggedOutMenu.NavigateToLoginPage();

            var _homePage = _loginPage.LoginWith("test@test.test", "test");
            _addressOverviewPage = _homePage.NavigateToAddressesOverviewPage();
        }

        [TestMethod]
        public void AddAddress()
        {
            var inputData = new AddEditAddressBo()
            {
                FirstName = "SIA 11 first name",
                LastName = "SIA 11 last name",
                Address1 = "SIA 11 address1",
                City = "California",
                Country = "Canada",
                State = "Iasi",
                ZipCode = "1231"
            };
            _addAddressPage = _addressOverviewPage.NavigateToAddAddressPage();
            var _addressDetails = _addAddressPage.AddEditAddress(inputData);
            Assert.AreEqual("Address was successfully created.", _addressDetails.NoticeText);
        }

        [TestMethod]
        public void EditAddress()
        {
            var inputData = new AddEditAddressBo()
            {
                FirstName = "Pretty please don't edit/delete",
                LastName = "SIA 11 last name",
                Address1 = "SIA 11 address1",
                City = "Iasi",
                Country = "Canada",
                State = "Florida",
                ZipCode = "1231"
            };
            _addAddressPage = 
                _addressOverviewPage.
                    NavigateToEditAddressPage(inputData.FirstName);
            var _addressDetails = _addAddressPage.AddEditAddress(inputData);
            Assert.AreEqual("Address was successfully updated.", _addressDetails.NoticeText);

        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}