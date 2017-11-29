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
        public void CanAddCommentToTheBlogNote()
        {
            MainPage.Open();
            MainPage.OpenFirstNote();
            NotePage.AddComment(new Comment
            {
            Text = "tekst notki",
            Mail = "email@email.pl",
            User = "kto"
            });

            //dodaj komentarz
            //sprawdź że komentarz się dodał
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
