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
            commentBox.Clear();
            commentBox.SendKeys(testData.Text);
            var nameLabel_email = Browser.FindByXpath("//label[@for='email']").First();
            nameLabel_email.Click();
            var email = Browser.FindElementByID("email");
            email.Click();
            email.Clear();
            email.SendKeys(testData.Mail);
            var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();
            Browser.WaitForInvisible(By.XPath("//label[@for='author']"));
            var user = Browser.FindElementByID("author");
            user.Click();
            user.Clear();
            user.SendKeys(testData.User);
            var submit = Browser.FindElementByID("comment-submit");
            submit.Click();
            Thread.Sleep(2000);
        }
    }
}