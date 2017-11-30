using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PageObjectTest
{
    public class AddingBlogCimmentsTests : IDisposable
    {
        
        [Fact]

        //Pierwszy test

        public void CanAddCommentToTheBlogNote()
        {
            string id = Guid.NewGuid().ToString();
            var comment = new Comment
            {
                Text = "tekst bardzo ważnej notki" + id,
                Mail = id + "email@email.pl",
                User = id + "kto"
            };
            MainPage.Open();
            MainPage.OpenFirstNote();
            NotePage.AddComment(comment);
            Assert.Contains(comment.Text, Browser.PageSource());
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
