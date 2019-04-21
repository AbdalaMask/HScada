using HScada.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HScada.DAL.Log
{
    public class ConsoleLog : ILog
    {
        public void Debug(string info)
        {
            Console.WriteLine("=======================================================================================");
            Console.WriteLine($"Debug {DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss:fff")}");
            Console.WriteLine("=======================================================================================");
            Console.WriteLine(info);
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("");
        }

        public void Fault(string info)
        {
            Console.WriteLine("=======================================================================================");
            Console.WriteLine($"Fault {DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss:fff")}");
            Console.WriteLine("=======================================================================================");
            Console.WriteLine(info);
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("");
        }

        public void Info(string info)
        {
            Console.WriteLine("=======================================================================================");
            Console.WriteLine($"Info {DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss:fff")}");
            Console.WriteLine("=======================================================================================");
            Console.WriteLine(info);
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("");
        }

        public void Warning(string info)
        {
            Console.WriteLine("=======================================================================================");
            Console.WriteLine($"Warning {DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss:fff")}");
            Console.WriteLine("=======================================================================================");
            Console.WriteLine(info);
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("");
        }
    }
}
