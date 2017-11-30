using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace PageObjectTest
{
    internal class Browser
    {
        private static IWebDriver _driver;

        internal static void Initialize()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        internal static ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return _driver.FindElements(By.XPath(xpath));
        }

        internal static void WaitForInvisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        internal static string PageSource()
        {
            return _driver.PageSource;
        }

        internal static void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        internal static void Close()
        {
            _driver.Quit();
        }

        internal static IWebElement FindElementByID(string id)
        {
            return _driver.FindElement(By.Id(id));
        }
    }
}