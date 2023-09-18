using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBooks
{
    internal class Presenter
    {
        IModel model;
        IView view;
        public Presenter(IModel _model, IView _view)
        {
            this.model = _model;
            this.view = _view;
            view.LoadData += new EventHandler<EventArgs>(LoadFromFile);
            view.SaveData += new EventHandler<EventArgs>(SaveOnFile);
            view.AddAuthor += new EventHandler<EventArgs>(addauthor);
            view.DeleteAuthor += new EventHandler<EventArgs>(deleteauthor);
            view.AddBook += new EventHandler<EventArgs>(addbook);
            view.EditAuthor += new EventHandler<EventArgs>(editauthor);
            view.DeleteBook += new EventHandler<EventArgs>(deletebook);
            view.EditBook += new EventHandler<EventArgs>(editbook);
        }
        private void addbook(object sender, EventArgs e)
        {
            int i = view.currentauthor.Id;
            Book book = new Book(view.newbook, i);
            model.AddBook(book);
            UpdateView();
        }
        private void editbook(object sender, EventArgs e)
        {
            model.EditBook(view.currentbook, view.renamebook);
            UpdateView();

        }
        private void deletebook(object sender, EventArgs e)
        {
            if (view.cbox.SelectedItem != null)
            {
                if (view.currentbook != null)
                {
                    model.DelBook(view.currentbook);
                    UpdateView();
                }

            }

        }
        private void deleteauthor(object sender, EventArgs e)
        {
            if (view.cbox.SelectedItem != null)
            {
                model.DelAuthor(view.currentauthor);
                view.cbox.SelectedItem = null;
                UpdateView();
            }

        }
        private void editauthor(object sender, EventArgs e)
        {
            model.EditAuthor(view.currentauthor, view.renameauthor);
            view.cbox.SelectedItem = null;
            UpdateView();
        }
        private void addauthor(object sender, EventArgs e)
        {
            model.AddAuthor(view.newauthor);
            UpdateView();

        }
        private void LoadFromFile(object sender, EventArgs e)
        {
            model.LoadData(view.filepath);
            UpdateView();
        }
        private void UpdateView()
        {
            view.books = model.books;
            view.authors = model.authors;
        }
        private void SaveOnFile(object sender, EventArgs e)
        {

            model.SaveData(view.authors, view.books, view.filesave);
        }

    }
}
