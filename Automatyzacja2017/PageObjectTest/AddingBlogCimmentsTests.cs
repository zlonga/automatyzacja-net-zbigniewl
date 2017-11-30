using System;
using System.Collections.Generic;
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


        [Fact]
        public void CanAddCommentToTheBlogNote00000()
        {
            string id = Guid.NewGuid().ToString();
            var comment = new Comment
            {
                Text = "tekst drugiej bardzo ważnej notki" + id,
                Mail = id + "email_drugi@email.pl",
                User = id + "ktos"
            };
            MainPage.Open();
            MainPage.OpenFirstNote();
            NotePage.AddComment(comment);

            string id_2 = Guid.NewGuid().ToString();
            var subcomment = new Comment
            {
                Text = "tekst drugiej bardzo ważnej notki" + id_2,
                Mail = id_2 + "email_drugi@email.pl",
                User = id_2 + "a kto jest"
            };
            NotePage.AddSubNote(comment, subcomment);
          
            //Assert.Contains(comment.Text, Browser.PageSource());
        }
        public void Dispose()
        {
            Browser.Close();
        }
    }
}
