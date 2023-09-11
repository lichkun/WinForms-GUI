using ClassLibrary1;
using ISerialize1;
using MyILog;
using PriceList1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriceList list = new PriceList();
            List<Storage> obj = new List<Storage>()
            {   new Flash(),
                new DVD(),
                new HDD() 
            };
            foreach( Storage s in obj)
            {
                list.AddStorage(s);
            }
            list.PrintList(new ConsoleLog());
            list.Save(new xmlserialize());
            list.Save(new jsonserialize());
            list.Save(new soapserialize());
            //list.Edit(0, 2);
            //list.Find("bob");
            //list.Load(new jsonserialize());
            //list.PrintList(new ConsoleLog());
            
        }
    }
}
