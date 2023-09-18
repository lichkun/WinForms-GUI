using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthorAndBooks
{
    public partial class Editor : Form
    {
        public string lb
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public string text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public Editor()
        {
            InitializeComponent();
        }
    }
}
