using System.Reflection;
using System.Windows.Forms;

namespace AuthorAndBooks
{
    public partial class Form1 : Form, IView
    {
        private List<Book> _books = new List<Book>();
        public List<Book> books
        {
            get { return _books; }
            set
            {
                _books = value;
                listBox1.Items.Clear();
                if (_books != null)
                {
                    foreach (Book book in _books)
                    {
                        listBox1.Items.Add(book.Title);
                    }
                }
            }
        }
        private List<Author> _authors = new List<Author>();
        public List<Author> authors 
        {
            get { return _authors; }
            set
            {
                string lastobject = comboBox1.SelectedItem as string;
                _authors = value;
                comboBox1.Items.Clear();
                if (_authors != null)
                {
                    foreach (Author author in _authors)
                    {
                        comboBox1.Items.Add(author.Name);
                    }
                }
                if (!string.IsNullOrEmpty(lastobject)&& comboBox1.Items.Contains(lastobject))
                { comboBox1.SelectedItem = lastobject; }
            }
        }
        public ComboBox cbox
        {
            get { return comboBox1 as ComboBox; }
            set { comboBox1 = value; }
        }
        public Author currentauthor
        {
            get
            {
                if (comboBox1.SelectedItem != null)
                {
                    Author a = authors.FirstOrDefault(author => author.Name == comboBox1.SelectedItem.ToString());
                    return a;
                }
                else return null;

            }

            set { comboBox1.SelectedItem = value; }
        }
        public Book currentbook
        {
            get
            {
                Book a = null;
                if (listBox1.SelectedItem != null)
                { a = books.FirstOrDefault(book => book.Title == listBox1.SelectedItem.ToString()); }
                return a;
            }
        }
        public string filepath { get; set; }
        public string filesave { get; set; }
        public string newauthor { get; set; }
        public string renameauthor { get; set; }
        public string newbook { get; set; }
        public string renamebook { get; set; }
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        SaveFileDialog saveFileDialog  = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> AddAuthor;
        public event EventHandler<EventArgs> EditAuthor;
        public event EventHandler<EventArgs> DeleteAuthor;
        public event EventHandler<EventArgs> AddBook;
        public event EventHandler<EventArgs> EditBook;
        public event EventHandler<EventArgs> DeleteBook;
        public event EventHandler<EventArgs> LoadData;
        public event EventHandler<EventArgs> SaveData;
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    LoadData.Invoke(this, EventArgs.Empty);
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filesave = saveFileDialog.FileName;
                    SaveData.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void добавитьјвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor editor = new Editor();
            editor.lb = "ƒобавить автора";
            if (editor.ShowDialog() == DialogResult.OK)
            {
                newauthor = editor.text;
                AddAuthor.Invoke(this, EventArgs.Empty);              
            }
            
        }

        private void удалитьјвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("¬ы точно желаете удалить этого автора?", "”даление", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    DeleteAuthor.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void добавить нигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor editor = new Editor();
            editor.lb = "ƒобавить книгу";
            if (cbox.SelectedItem != null)
            {
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    newbook = editor.text;
                    AddBook.Invoke(this, EventArgs.Empty);
                }

            }
            
        }

        private void редактироватьјвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor editor = new Editor();
            editor.lb = "–едактирование автора";
            if (cbox.SelectedItem != null)
            {
                editor.text = currentauthor.Name;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    renameauthor = editor.text;
                    EditAuthor.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void удалить нигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("¬ы точно желаете удалить эту книгу?", "”даление", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    DeleteBook.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void редактировать нигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editor editor = new Editor();
            editor.lb = "–едактирование книги";

            if (currentbook != null)
            {
                editor.text = currentbook.Title;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    renamebook = editor.text;
                    EditBook.Invoke(this, EventArgs.Empty);
                }

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                listBox1.Items.Clear();
                if (currentauthor != null)
                {
                    foreach (Book book in books)
                    {
                        if (book.AuthorId == currentauthor.Id)
                        {
                            listBox1.Items.Add(book.Title);
                        }
                    }
                }
            }
            else
            {
                listBox1.Items.Clear();
                if (_books != null)
                {
                    foreach (Book book in _books)
                    {
                        listBox1.Items.Add(book.Title);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1_CheckedChanged(this, EventArgs.Empty);
        }
    }
}