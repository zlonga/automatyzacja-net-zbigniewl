using System;

using System.Text;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;

using Xunit;
using System.Linq;
using System.Threading;
using System.Collections.ObjectModel;

namespace SeleniumTests

{

    public class Example : IDisposable

    {
        private const string SearchTextBoxID = "lst-ib";
        private const string PageTitle = "Code Sprinters -";
        private const string SearchQuery = "code sprinters";
        private const string LinkTextToFind = "Poznaj nasze podejście";
        private const string AcceptPoliticsCookies = "Akceptuję";
        private const string TagName = "h2";
        private const string TextToFind = "WIEDZA NA PIERWSZYM MIEJSCU";
        private string googleURL = "https://www.google.pl/";

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        public Example()

        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts()
                .ImplicitWait = TimeSpan.FromMilliseconds(100);
            verificationErrors = new StringBuilder();

        }
        [Fact]

        public void TheExampleTest()

        {
            GoToGoogle();

            Search(SearchQuery);

            ClickOnLinkWithText(PageTitle);

            Assert.Single(GetElementsByLinkText(LinkTextToFind));

            GoToOurApproachPage();
 
            Assert.Single(FindElementsByTagNameAndText(TagName, TextToFind));
        }

        private void GoToOurApproachPage()
        {
            ClickOnLinkWithText(AcceptPoliticsCookies);

            InvisibilityOfElementWithText(AcceptPoliticsCookies, 11);
            
            ClickOnLinkWithText(LinkTextToFind);
        }

        private System.Collections.Generic.IEnumerable<IWebElement> FindElementsByTagNameAndText(string tagName, string text)
        {
            return GetElementsByTagName(tagName).Where(tag => tag.Text == text);
        }

        private ReadOnlyCollection<IWebElement> GetElementsByTagName(string tagName)
        {
            return driver.FindElements(By.TagName(tagName));
        }

        private void InvisibilityOfElementWithText(string acceptPoliticsCookies, int time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText(acceptPoliticsCookies), acceptPoliticsCookies));
        }

        private ReadOnlyCollection<IWebElement> GetElementsByLinkText(string linkTextToFind)
        {
            return driver.FindElements(By.LinkText(linkTextToFind));
        }

        private void Search(string query)
        {
            var searchBox = GetSearchBox();
            searchBox.Clear();
            searchBox.SendKeys(query);
            searchBox.Submit();
        }

        private void ClickOnLinkWithText(string resultName)
        {
            driver.FindElement(By.LinkText(resultName)).Click();
        }

        private void GoToGoogle()
        {
            driver.Navigate().GoToUrl(googleURL);
        }

        private IWebElement GetSearchBox()
        {
            return driver.FindElement(By.Id(SearchTextBoxID));
        }

        protected void waitForElementPresent(By by, int seconds)

        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(ExpectedConditions.ElementToBeClickable(by));

        }



        protected void waitForElementPresent(IWebElement by, int seconds)

        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(ExpectedConditions.ElementToBeClickable(by));

        }   
        public void Dispose()

        {

            try

            {

                driver.Quit();

            }

            catch (Exception)

            {

                // Ignore errors if unable to close the browser

            }

            Assert.Equal("", verificationErrors.ToString());

        }

    }

}