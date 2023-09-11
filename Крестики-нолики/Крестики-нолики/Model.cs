using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Крестики_нолики
{
    internal class Model : IModel
    {
        public string[,] field = new string[3,3];

        public void DefaultAIMove()
        {
            Random rnd = new Random();
            while (true)
            {
                int i = rnd.Next(3);
                int j = rnd.Next(3);
                if (field[i, j] == "")
                {
                    field[i, j] = "O";
                    break;
                }
            }

        }
        public void CleverAI()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (field[row, col] == "")
                    {
                        field[row, col] = "O";
                        if (checkWin())
                        {
                            field[row, col] = "O";
                            return;
                        }
                        field[row, col] = ""; 
                    }
                }
            }
            DefaultAIMove();
        }
        public bool checkWin()
        {
            if (field[0,0]=="O" && field[0,1]=="O" && field[0,2]=="O")
            {
                return true;
            }
            else if (field[1, 0] == "O" && field[1, 1] == "O" && field[1, 2] == "O")
            {
                return true;
            }
            else if(field[2, 0] == "O" && field[2, 1] == "O" && field[2, 2] == "O")
            {
                return true;
            }
            else if(field[0, 0] == "O" && field[1, 0] == "O" && field[2, 0] == "O")
            {
                return true;
            }
            else if(field[0, 1] == "O" && field[1, 1] == "O" && field[2, 1] == "O")
            {
                return true;
            }
            else if(field[0, 2] == "O" && field[1, 2] == "O" && field[2, 2] == "O")
            {
                return true;
            }
            else if (field[0, 0] == "O" && field[1, 1] == "O" && field[2, 2] == "O")
            {
                return true;
            }
            else if (field[0, 2] == "O" && field[1, 1] == "O" && field[2, 0] == "O")
            {
                return true;
            }
            return false;
        }
    }
}
