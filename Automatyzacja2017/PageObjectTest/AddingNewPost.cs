using System;
using Xunit;
using PageObjectTest;
using System.Threading;

namespace AddingNewPost
{
    public class AddingNewPost : IDisposable
    {
        public AddingNewPost()
        {
            Browser.Initialize();
        }

        [Fact]

        public void CanAddNewPost()
        {
            string id = Guid.NewGuid().ToString();
            var user_pass = new LoginData
            {
                Url = "https://autotestdotnet.wordpress.com/wp-admin/",
                Pass = "P@ssw0rd1",
                User = "autotestdotnet@gmail.com",
            };

            LoginPage.Login(user_pass);
            Thread.Sleep(2000);

            var note_data = new NoteData
            {
                Title = "Tytuł strony"+id,
                Text = "To jest tekst Posta"+id
            };

            AdminPage.AddNote(note_data);

            Assert.Contains(note_data.Title, Browser.PageSource());

            Thread.Sleep(5000);
        }
        public void Dispose()
        {
            Browser.Close();
        }
    }
}
