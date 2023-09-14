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
                _authors = value;
                comboBox1.Items.Clear();
                if (_authors != null)
                {
                    foreach (Author author in _authors)
                    {
                        comboBox1.Items.Add(author.Name);
                    }
                }
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
        private void îòêğûòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData.Invoke(this, EventArgs.Empty);
        }

        private void ñîõğàíèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData.Invoke(this, EventArgs.Empty);
        }

        private void äîáàâèòüÀâòîğàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAuthor.Invoke(this, EventArgs.Empty);
        }

        private void óäàëèòüÀâòîğàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAuthor.Invoke(this, EventArgs.Empty);
        }

        private void äîáàâèòüÊíèãóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook.Invoke(this, EventArgs.Empty);
        }

        private void ğåäàêòèğîâàòüÀâòîğàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAuthor.Invoke(this, EventArgs.Empty);
        }

        private void óäàëèòüÊíèãóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBook.Invoke(this, EventArgs.Empty);
        }

        private void ğåäàêòèğîâàòüÊíèãóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBook.Invoke(this, EventArgs.Empty);
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