using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Крестики_нолики
{
    internal class Presenter
    {
        Model model;
        IView view;

        public Presenter(Model _model, IView _view)
        {
            model = _model;
            view = _view;
            UpdateModel();
            view.start += new EventHandler<EventArgs>(start);
            view.clickbutton += new EventHandler<EventArgs>(clickb);
        }
        private void start(object sender, EventArgs e) 
        {
            Clear(this, EventArgs.Empty);
            if (view.RB2 == true&& view.RB3==true)
            {
                model.DefaultAIMove();
                UpdateView();
            }
            else if (view.RB2 == true && view.RB4 == true)
            {
                model.DefaultAIMove();
                UpdateView();
            }
        }
        private void Clear(object sender, EventArgs e)
        {
            view.Field1 = "";
            view.Field2 = "";
            view.Field3 = "";
            view.Field4 = "";
            view.Field5 = "";
            view.Field6 = "";
            view.Field7 = "";
            view.Field8 = "";
            view.Field9 = "";
            model.field[0, 0] = view.Field1;
            model.field[0, 1] = view.Field2;
            model.field[0, 2] = view.Field3;
            model.field[1, 0] = view.Field4;
            model.field[1, 1] = view.Field5;
            model.field[1, 2] = view.Field6;
            model.field[2, 0] = view.Field7;
            model.field[2, 1] = view.Field8;
            model.field[2, 2] = view.Field9;
        }
        private void clickb(object sender, EventArgs e)
        {
            UpdateModel();
            CheckGameOver();
            if (view.RB3 == true)
            {
                model.DefaultAIMove();
            }
            if(view.RB4 == true)
            {
                model.CleverAI();               
            }
            UpdateView();
            CheckGameOver();
        }
        private void UpdateView()
        {
            view.Field1 = model.field[0,0];
            view.Field2 = model.field[0, 1];
            view.Field3 = model.field[0, 2];
            view.Field4 = model.field[1, 0];
            view.Field5 = model.field[1, 1];
            view.Field6 = model.field[1, 2];
            view.Field7 = model.field[2, 0];
            view.Field8 = model.field[2, 1];
            view.Field9 = model.field[2, 2];
        }
        private void UpdateModel()
        {
            model.field[0, 0] = view.Field1;
            model.field[0, 1] = view.Field2;
            model.field[0, 2] = view.Field3;
            model.field[1, 0] = view.Field4;
            model.field[1, 1] = view.Field5;
            model.field[1, 2] = view.Field6;
            model.field[2, 0] = view.Field7;
            model.field[2, 1] = view.Field8;
            model.field[2, 2] = view.Field9;
        }
        private void CheckGameOver()
        {
            string winner="";
            if (view.Field1 == view.Field2 && view.Field2 == view.Field3&& view.Field3 != "")
            {                 
                if(view.Field1 == "X")
                {
                    winner = "X";
                }
                else winner = "O";
            }
            if (view.Field4 == view.Field5 && view.Field5 == view.Field6 && view.Field4 != "")
            {
                if (view.Field4 == "X")
                {
                    winner = "X";
                }
                else winner = "O";
            }
            if (view.Field7 == view.Field8 && view.Field8 == view.Field9 && view.Field7 != "")
            {
                if (view.Field8 == "X")
                {
                    winner = "X";
                }
                else winner = "O";
            }
            if (view.Field1 == view.Field4 && view.Field4 == view.Field7 && view.Field1 != "")
            {
                if (view.Field1 == "X")
                {
                    winner = "X";
                }
                else winner = "O";
            }
            if (view.Field2 == view.Field5 && view.Field5 == view.Field8 && view.Field2 != "")
            {
                if (view.Field2 == "X")
                {
                    winner = "X";
                }
                else winner = "O";
            }
            if (view.Field3 == view.Field6 && view.Field6 == view.Field9 && view.Field3 != "")
            {
                if (view.Field3 == "X")
                {
                    winner = "X";
                }
                else winner = "O";
            }
            if (view.Field1 == view.Field5 && view.Field5 == view.Field9 && view.Field1 != "")
            {
                if (view.Field1 == "X")
                {
                    winner = "X";
                }
                else winner = "O";
            }
            if (view.Field3 == view.Field5 && view.Field5 == view.Field7 && view.Field3 != "")
            {
                if (view.Field3 == "X")
                {
                    winner = "X";
                }
                else winner = "O";
            }
            if (winner != "")
            {
                DialogResult result = MessageBox.Show($"{winner} победил!", "Игра окончена", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Retry)
                {
                    Reset();
                    UpdateModel();
                    return;
                }
                else Application.Exit();
            }
            if (view.Field1 != "" && view.Field2 != "" && view.Field3 != "" && view.Field4 != "" &&
                view.Field5 != "" && view.Field6 != "" && view.Field7 != "" && view.Field8 != "" && view.Field9 != "")
            {
                DialogResult result = MessageBox.Show($"Ничья", "Игра окончена", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Retry)
                {
                    Reset();
                    UpdateModel();
                    return;
                }
                else Application.Exit();
            }
            
        }
        private void Reset()
        {
            view.Field1 = "";
            view.Field2 = "";
            view.Field3 = "";
            view.Field4 = "";
            view.Field5 = "";
            view.Field6 = "";
            view.Field7 = "";
            view.Field8 = "";
            view.Field9 = "";
            view.RB1 = false;
            view.RB2 = false;
            view.RB3 = false;
            view.RB4 = false;
            view.enb1 = false;
            view.enb2 = false;
            view.enb3 = false;
            view.enb4 = false;
            view.enb5 = false;
            view.enb6 = false;
            view.enb7 = false;
            view.enb8 = false;
            view.enb9 = false;
            view.ms1 = true;
        }
    }
}
