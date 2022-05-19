using OpenQA.Selenium;

namespace Sia11.Tests.PageObjects.AddressDetails
{
    public class AddressDetailsPage
    {
        private IWebDriver _driver;

        public AddressDetailsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement LblNotice =>
            _driver.FindElement(By.CssSelector("div[data-test=notice]"));

        public string NoticeText => LblNotice.Text;
    }
}