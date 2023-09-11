using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Крестики_нолики
{
    internal interface IModel
    {

        void DefaultAIMove();

        void CleverAI();

        bool checkWin();
    }
}
