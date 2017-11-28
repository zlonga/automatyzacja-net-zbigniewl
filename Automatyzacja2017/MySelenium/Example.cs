using System;

using System.Text;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;

using Xunit;
using System.Linq;
using System.Threading;

namespace SeleniumTests

{

    public class Example : IDisposable

    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        public Example()

        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://www.google.pl/";
            verificationErrors = new StringBuilder();

        }
        [Fact]

        public void TheExampleTest()

        {

            driver.Navigate().GoToUrl(baseURL);                                                                     //otwiera stronę startową
            driver.FindElement(By.Id("lst-ib")).Clear();                                                            //czyści pole o Id
            driver.FindElement(By.Id("lst-ib")).SendKeys("code sprinters");                                         //wprowadza tekst
            driver.FindElement(By.Id("lst-ib")).Submit();                                                           //zatwierdza
            driver.FindElement(By.LinkText("Code Sprinters -")).Click();                                            //wyszukuje link i w niego klika

            var element = driver.FindElement(By.LinkText("Poznaj nasze podejście"));                                //test czy na stronie widoczny jest link z tekstem
            Assert.NotNull(element);
            var elements = driver.FindElements(By.LinkText("Poznaj nasze podejście"));                              //czy na stronie widoczny jest jeden link
            Assert.Single(elements);
            // Assert.Equal("Code Sprinters -", driver.Title);
            driver.FindElement(By.LinkText("Akceptuję")).Click();                                                   //wyszukuje link i klika w niego
            //waitForElementPresent(By.LinkText("Poznaj nasze podejście"), 2);                                      //czeka max 2s
            //Thread.Sleep(2000);                                                                                   //czeka na sztywno 2s
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));                                //czeka max 5s 
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText("Akceptuję"), "Akceptuję"));    //lub do chwili aż zniknie link Akceptuję
            driver.FindElement(By.LinkText("Poznaj nasze podejście")).Click();                                      //wyszukuje link z tekste i kilka w niego
            var elements_2 = driver.FindElements(By.TagName("h2"));                                                 //wyszukuje wszystkie teksty z tagiem h2
            Assert.Single(elements_2.Where(tag => tag.Text == "WIEDZA NA PIERWSZYM MIEJSCU"));                      //sprawdza czy 1 element w powyższej liscie ma tekst ""

            Assert.Contains("WIEDZA NA PIERWSZYM MIEJSCU", driver.PageSource);                                      //sprawdza czy na stronie jest text
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