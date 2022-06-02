using OpenQA.Selenium;
using Sia11.Tests.Utils;

namespace Sia11.Tests.PageObjects.AddressDetails
{
    public class AddressDetailsPage
    {
        private IWebDriver _driver;

        public AddressDetailsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private By Notice => By.CssSelector("div[data-test=notice]");

        private IWebElement LblNotice =>
            _driver.FindElement(Notice);

        public string NoticeText
        {
            get
            {
                _driver.WaitForElement(Notice,30);
                return LblNotice.Text;
            }
        }
    }
}