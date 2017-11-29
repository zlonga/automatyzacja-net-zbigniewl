using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace PageObjectTest
{
    internal class NotePage
    {
        internal static void AddComment(Comment testData)
        {
            var commentBox = Browser.FindElementByID("comment");
            commentBox.Click();
            commentBox.SendKeys(testData.Text);
            var email = Browser.FindElementByID("email");
            email.Click();
            email.SendKeys(testData.Mail);
            var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();
            Thread.Sleep(2000);
            //Browser.WaitForInvisible(By.XPath("//label[@for='author']"));
            var user = Browser.FindElementByID("author");
            user.Click();
            user.SendKeys(testData.User);
        }
    }
}