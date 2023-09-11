using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Крестики_нолики
{
    internal interface IView
    {
        #region плохойкод
        bool enb1 { set; }
        bool enb2 { set; }
        bool enb3 { set; }
        bool enb4 { set; }
        bool enb5 { set; }
        bool enb6 { set; }
        bool enb7 { set; }
        bool enb8 { set; }
        bool enb9{ set; }
        #endregion
        string Field1 { get; set; }
        string Field2 { get; set; }
        string Field3 { get; set; }
        string Field4 { get; set; }
        string Field5 { get; set; }
        string Field6 { get; set; }
        string Field7 { get; set; }
        string Field8 { get; set; }
        string Field9 { get; set; }
        bool ms1 { set; }
        bool RB1 { get; set; }
        bool RB2 { get; set; }
        bool RB3 { get; set; }
        bool RB4 { get; set; }

        event EventHandler<EventArgs> start;
        event EventHandler<EventArgs> clickbutton;
    }
}
