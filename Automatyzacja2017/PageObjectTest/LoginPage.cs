using PageObjectTest;
using System.Linq;

namespace AddingNewPost
{
    internal class LoginPage
    {
        internal static void Login(LoginData data)
        {
            Browser.NavigateTo(data.Url);
            var userBox = Browser.FindElementByID("usernameOrEmail");
            userBox.Click();
            userBox.Clear();
            userBox.SendKeys(data.User);
            var passBox = Browser.FindElementByID("password");
            passBox.Click();
            passBox.Clear();
            passBox.SendKeys(data.Pass);
            var button_submit = Browser.FindByXpath("//button[@type='submit']");
            button_submit.Single().Click();
        }
    }
}