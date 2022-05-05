using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Sia11.Tests.PageObjects.AddAddress
{
    public class AddAddressPage
    {
        private IWebDriver _driver;

        public AddAddressPage(IWebDriver driver)
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

        public void AddAddress(string firstName, string lastName, string address1, string state, string country, string city, string zipcode)
        {
            TxtFirstName.SendKeys(firstName);
            TxtLastName.SendKeys(lastName);
            TxtAddress1.SendKeys(address1);

            var stateName = new SelectElement(DdlState);
            stateName.SelectByText(state);

            LstCountry.FirstOrDefault(el => el.Text.Contains(country)).Click();

            TxtCity.SendKeys(city);
            TxtZipCode.SendKeys(zipcode);
        }
    }
}