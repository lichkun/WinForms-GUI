using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBooks
{
    internal interface IModel
    {
        List<Book> books { get; }
        List<Author> authors {  get; }
        void LoadData(string filepath);
        void SaveData(List<Author> authors,List<Book> books, string filepath);
        void AddAuthor(string author);
        void DelAuthor(Author author);
        void EditAuthor(Author author, string rename);
        void AddBook(Book book);
        void DelBook(Book book);
        void EditBook(Book book, string r);
    }
}
