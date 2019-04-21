using HScada.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HScada.Services.Instance
{
    public class ConsolaLog : ILog
    {
        public void Debug(string mesg)
        {
            Console.WriteLine("Debug: "+mesg);
        }

        public void Fualt(string mesg)
        {
            Console.WriteLine("Fualt: " + mesg);
        }

        public void Info(string mesg)
        {
            Console.WriteLine("Message: " + mesg);
        }

        public void Waring(string mesg)
        {
            Console.WriteLine("Waring: " + mesg);
        }
    }
}
