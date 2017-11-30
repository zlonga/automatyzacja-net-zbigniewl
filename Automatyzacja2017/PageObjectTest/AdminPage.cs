using PageObjectTest;
using System.Linq;
using System.Threading;

namespace AddingNewPost
{
    internal class AdminPage
    {
        internal static void AddNote(NoteData data)
        {
            var Posts = Browser.FindByXpath("//div[@class='wp-menu-name' and text()='Posts']");
            Posts.Single().Click();
            var AddNewPost = Browser.FindByXpath("//a[@class='page-title-action' and text()='Add New']");
            AddNewPost.Single().Click();
            var Label_title = Browser.FindElementByID("title-prompt-text");
            Label_title.Click();
            var Input_title = Browser.FindElementByID("title");
            Input_title.Click();
            Input_title.SendKeys(data.Title);
            var Input_text = Browser.FindElementByID("content");
            Input_text.Click();
            Input_text.SendKeys(data.Text);
            Thread.Sleep(1000);
            var publish = Browser.FindElementByID("publish");
            publish.Click();
            Thread.Sleep(2000);
            publish.Click();
            Thread.Sleep(5000);
            var All_Posts = Browser.FindByXpath("//a[@href='edit.php' and text()='All Posts']");
            All_Posts.Single().Click();
        }
    }
}