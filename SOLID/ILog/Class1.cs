using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyILog
{
    public interface ILog
    {
        void Print(string message);

    }
    public class ConsoleLog : ILog
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class FileLog : ILog
    {
        public void Print(string message) 
        {
            try
            {
                using (StreamWriter st = new StreamWriter("Test.txt",true)) 
                { 
                    st.WriteLine(message);
                    Console.WriteLine("Запись в файл успешна");
                }

            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Ошибка - {ex.Message}"); 
            }
        }
    }
}
