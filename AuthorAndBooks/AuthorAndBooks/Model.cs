using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AuthorAndBooks
{
    internal class Model : IModel
    {
        public List<Book> books { get; set; }
        public List<Author> authors { get; set; }
        public void LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                var data = JsonConvert.DeserializeObject<dynamic>(jsonData);

                authors = data.Author.ToObject<List<Author>>();
                books = data.Books.ToObject<List<Book>>();

            }
            else
            {
            }
        }

        public void SaveData(List<Author> authors, List<Book> books, string filepath)
        {
            if (!filepath.EndsWith(".json")) filepath += ".json";
            var datasave = new
            {
                Author = authors,
                Books = books,
            };
            string jsonData = JsonConvert.SerializeObject(datasave);
            File.WriteAllText(filepath, jsonData);
        }
        public void AddAuthor(string name)
        {
            int i = rnd();
            Author auth = new Author(name, i);
            authors.Add(auth);
        }
        public void DelAuthor(Author author)
        {
            if (author != null)
            {
                List<Book> booktoremove = new List<Book>();
                foreach (Book book in books)
                {
                    if(book.AuthorId == author.Id)
                    {
                        booktoremove.Add(book);
                    }
                }
                foreach(Book book in booktoremove)
                {
                    books.Remove(book);
                }
                authors.Remove(author);
                
            }
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void DelBook(Book book)
        {
            books.Remove(book);
        }
        public void EditAuthor(Author author, string r)
        {
            authors.Remove(author);
            author.Name = r;
            authors.Add(author);
        }
        private int rnd()
        {
            Random rnd = new Random();
            while (true)
            {
                int index = rnd.Next(100);
                if (!authors.Exists(author => author.Id == index)) return index;
            }

        }
        public void EditBook(Book book, string r)
        {
            books.Remove(book);
            book.Title = r;
            books.Add(book);
        }
    }
}
