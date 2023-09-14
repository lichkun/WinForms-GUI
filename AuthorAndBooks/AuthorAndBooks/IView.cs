using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBooks
{
    internal interface IView
    {
        List<Book> books { get; set; }
        List<Author> authors { get; set; }
        Author currentauthor { get; set; }
        Book currentbook { get; }
        ComboBox cbox { get; set; }
        event EventHandler<EventArgs> AddAuthor;
        event EventHandler<EventArgs> EditAuthor;
        event EventHandler<EventArgs> DeleteAuthor;
        event EventHandler<EventArgs> AddBook;
        event EventHandler<EventArgs> EditBook;
        event EventHandler<EventArgs> DeleteBook;
        event EventHandler<EventArgs> LoadData;
        event EventHandler<EventArgs> SaveData;
    }
}
