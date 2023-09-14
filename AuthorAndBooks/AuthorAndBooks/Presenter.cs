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
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        SaveFileDialog SaveFileDialog = new SaveFileDialog();
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
            Editor editor = new Editor();
            editor.lb = "Добавить книгу";
            if (view.cbox.SelectedItem != null)
            {
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    string name = editor.text;
                    int i = view.currentauthor.Id;
                    Book book = new Book(name, i);
                    model.AddBook(book);

                }
            }
            UpdateView();
        }
        private void editbook(object sender, EventArgs e)
        {
            Editor editor = new Editor();
            editor.lb = "Редактирование книги";
            if (view.currentbook != null)
            {
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    string rename = editor.text;
                    model.EditBook(view.currentbook, rename);
                }
            }
            UpdateView();
        }
        private void deletebook(object sender, EventArgs e)
        {
            if (view.cbox.SelectedItem != null)
            {
                if (view.currentbook != null)
                {
                    model.DelBook(view.currentbook);
                }
            }
            UpdateView();
        }
        private void deleteauthor(object sender, EventArgs e)
        {
            if (view.cbox.SelectedItem != null)
            {
                model.DelAuthor(view.currentauthor);
                view.cbox.SelectedItem = null;
            }
            UpdateView();
        }
        private void editauthor(object sender, EventArgs e)
        {
            Editor editor = new Editor();
            editor.lb = "Редактирование автора";
            if (view.cbox.SelectedItem != null)
            {
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    string rename = editor.text;
                    model.EditAuthor(view.currentauthor, rename);
                    view.cbox.SelectedItem = null;
                }
            }
            UpdateView();

        }
        private void addauthor(object sender, EventArgs e)
        {
            Editor editor = new Editor();
            editor.lb = "Добавить автора";
            if (editor.ShowDialog() == DialogResult.OK)
            {
                string name = editor.text;
                model.AddAuthor(name);
            }
            UpdateView();
        }
        private void LoadFromFile(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filepath = openFileDialog1.FileName;
                    model.LoadData(filepath);
                    UpdateView();
                }
            }
            catch (Exception ex) { }

        }
        private void UpdateView()
        {
            view.books = model.books;
            view.authors = model.authors;
        }
        private void SaveOnFile(object sender, EventArgs e)
        {
            try
            {
                if(SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filepath = SaveFileDialog.FileName;
                    model.SaveData(view.authors, view.books, filepath);
                }
            }catch (Exception ex) { }
        }

    }
}
