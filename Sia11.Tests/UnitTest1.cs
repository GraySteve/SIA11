using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Sia11.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldLoginSuccessfully()
        {
            //Open browser
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //navigate to URL
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click on signIn
            driver.FindElement(by: By.XPath("/html/body/nav/div/div[1]/a[2]")).Click();
            Thread.Sleep(2000);
            //Fill username
            driver.FindElement(By.Name("session[email]")).SendKeys("test@test.test");
            //Fill password
            driver.FindElement(By.CssSelector("input[placeholder='Password']")).SendKeys("test");
            //Click Login
            driver.FindElement(By.XPath("//input[@class='btn btn-primary']")).Click();
            Thread.Sleep(2000);
            //Assert
            Assert.AreEqual("test@test.test", driver.FindElement(By.XPath("//span[@data-test='current-user']")).Text);
            //Close browser
            driver.Quit();
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldNotLoginSuccessfullyWhenEmailIsInvalid()
        {
            //Open browser
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //navigate to URL
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click on signIn
            driver.FindElement(by: By.XPath("/html/body/nav/div/div[1]/a[2]")).Click();
            Thread.Sleep(2000);
            //Fill username
            driver.FindElement(By.Name("session[email]")).SendKeys("test1@test1.test1");
            //Fill password
            driver.FindElement(By.CssSelector("input[placeholder='Password']")).SendKeys("test");
            //Click Login
            driver.FindElement(By.XPath("//input[@class='btn btn-primary']")).Click();
            Thread.Sleep(2000);
            //Assert
            Assert.AreEqual("Bad email or password.", driver.FindElement(By.XPath("//div[@data-test='notice']")).Text);
            //Close browser
            driver.Quit();
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldNotLoginSuccessfullyWhenPasswordIsInvalid()
        {
            //Open browser
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //navigate to URL
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //Click on signIn
            driver.FindElement(by: By.XPath("/html/body/nav/div/div[1]/a[2]")).Click();
            Thread.Sleep(2000);
            //Fill username
            driver.FindElement(By.Name("session[email]")).SendKeys("test@test.test");
            //Fill password
            driver.FindElement(By.CssSelector("input[placeholder='Password']")).SendKeys("test25178357821361");
            //Click Login
            driver.FindElement(By.XPath("//input[@class='btn btn-primary']")).Click();
            Thread.Sleep(2000);
            //Assert
            Assert.AreEqual("Bad email or password.", driver.FindElement(By.XPath("//div[@data-test='notice']")).Text);
            //Close browser
            driver.Quit();
        }
    }
}