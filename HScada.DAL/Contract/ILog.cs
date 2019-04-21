using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HScada.DAL.Contract
{
    public interface ILog
    {
        void Info(string info);
        void Debug(string info);
        void Warning(string info);
        void Fault(string info);
    }
}
