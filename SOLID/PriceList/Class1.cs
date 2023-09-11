using ClassLibrary1;
using ISerialize1;
using MyILog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PriceList1
{
    public class PriceList
    {
        List<Storage> list = new List<Storage> ();
        public void AddStorage(Storage storage)
        {
            list.Add (storage);
        }
        public void RemoveStorage(Storage storage)
        {
            list.Remove (storage);  
        }
        public void PrintList(ILog log)
        {
            if (list != null)
            {
                foreach (Storage storage in this.list)
                {
                    storage.Print(log);
                }
            }
            else { Console.WriteLine("Список пуст"); }
        }
        public void Edit(int index, int attr) 
        {
            try
            {
                Console.WriteLine("Изменить атрибут на ");
                string str = Console.ReadLine ();
                switch(attr)
                {
                    case 0:
                        list[index].Campany = str;
                        break;
                    case 1:
                        list[index].Model = str;
                        break;
                    case 2:
                        list[index].Name = str;
                        break;
                    case 3:
                        list[index].Capacity = Convert.ToInt32(str);
                        break;
                    case 4:
                        list[index].Count = str;
                        break;

                }
                Console.WriteLine("Изменение успешно");
                
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
             
        }
        public void Find(string s)
        {
            Storage stor =list.Find(st => st.Name == s);
            stor?.Print(new ConsoleLog());
        }
        public void Save(ISerialize sel)
        {
            sel.Save(this.list);

        }
        public void Load(ISerialize sel)
        {
            this.list = sel.Load();

        }
    }
}
