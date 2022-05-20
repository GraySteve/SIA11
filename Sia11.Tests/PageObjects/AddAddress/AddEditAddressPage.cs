using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sia11.Tests.PageObjects.AddAddress.InputData;
using Sia11.Tests.PageObjects.AddressDetails;

namespace Sia11.Tests.PageObjects.AddAddress
{
    public class AddEditAddressPage
    {
        private IWebDriver _driver;

        public AddEditAddressPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement TxtFirstName =>
            _driver.FindElement(By.Id("address_first_name"));

        private IWebElement TxtLastName =>
            _driver.FindElement(By.Id("address_last_name"));

        private IWebElement TxtAddress1 =>
            _driver.FindElement(By.Id("address_street_address"));

        private IWebElement DdlState =>
            _driver.FindElement(By.Id("address_state"));

        private IList<IWebElement> LstCountry =>
            _driver.FindElements(By.CssSelector("label[for^=address_country]"));

        private IWebElement TxtCity =>
            _driver.FindElement(By.Id("address_city"));

        private IWebElement TxtZipCode =>
            _driver.FindElement(By.Id("address_zip_code"));

        private IWebElement BtnSubmit =>
            _driver.FindElement
                (By.CssSelector("input[type=submit]"));

        public AddressDetailsPage AddEditAddress(AddEditAddressBo inputData)
        {
            TxtFirstName.SendKeys(inputData.FirstName);
            TxtLastName.SendKeys(inputData.LastName);
            TxtAddress1.SendKeys(inputData.Address1);

            var stateName = new SelectElement(DdlState);
            stateName.SelectByText(inputData.State);

            LstCountry.FirstOrDefault(el => el.Text.Contains(inputData.Country)).Click();

            TxtCity.SendKeys(inputData.City);
            TxtZipCode.SendKeys(inputData.ZipCode);
            BtnSubmit.Click();
            Thread.Sleep(2000);
            return new AddressDetailsPage(_driver);
        }
    }
}