using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Крестики_нолики
{
    public partial class View :  Form, IView
    {
        #region Fields
        public bool enb1 { set { button1.Enabled = value; } }
        public bool enb2 { set { button2.Enabled = value; } }
        public bool enb3 { set { button3.Enabled = value; } }
        public bool enb4 { set { button4.Enabled = value; } }
        public bool enb5 { set { button5.Enabled = value; } }
        public bool enb6 { set { button6.Enabled = value; } }
        public bool enb7 { set { button7.Enabled = value; } }
        public bool enb8 { set { button8.Enabled = value; } }
        public bool enb9 { set { button9.Enabled = value; } }
        public string Field1
        {
            get { return button1.Text; }
            set { button1.Text = value; }
        }
        public string Field2
        {
            get { return button2.Text; }
            set { button2.Text = value; }
        }
        public string Field3
        {
            get { return button3.Text; }
            set { button3.Text = value; }
        }
        public string Field4
        {
            get { return button4.Text; }
            set { button4.Text = value; }
        }
        public string Field5
        {
            get { return button5.Text; }
            set { button5.Text = value; }
        }
        public string Field6
        {
            get { return button6.Text; }
            set { button6.Text = value; }
        }
        public string Field7
        {
            get { return button7.Text; }
            set { button7.Text = value; }
        }
        public string Field8
        {
            get { return button8.Text; }
            set { button8.Text = value; }
        }
        public string Field9
        {
            get { return button9.Text; }
            set { button9.Text = value; }
        }
        public bool RB1
        {
            get { return radioButton1.Checked; }
            set { radioButton1.Checked = value; }
        }
        public bool RB2
        {
            get { return radioButton2.Checked; }
            set { radioButton2.Checked = value; }
        }
        public bool RB3
        {
            get { return radioButton3.Checked; }
            set { radioButton3.Checked = value; }
        }
        public bool RB4
        {
            get { return radioButton4.Checked; }
            set { radioButton4.Checked = value; }
        }
        public bool ms1
        {
            set { menuStrip1.Items[0].Enabled = value; }
        }
        #endregion
        public event EventHandler<EventArgs> start;
        public event EventHandler<EventArgs> clickbutton;
        public View()
        {
            InitializeComponent();
        }

        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            ms1 = false;
            start?.Invoke(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Text = "X";
            button.Enabled = false;
            clickbutton?.Invoke(this, EventArgs.Empty);
        }      

        private void button1_TextChanged(object sender, EventArgs e)
        {
            Button button = sender as Button;
            //if(button.Text == "") { button.Enabled = true; }
            button.Enabled = false;
        }
    }
}
