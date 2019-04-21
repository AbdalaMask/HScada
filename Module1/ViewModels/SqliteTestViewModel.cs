using HScada.SystemElement.MVVM;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.ViewModels
{
    public class SqliteTestViewModel : ViewModelBase
    {
        public SqliteTestViewModel(IContainerExtension ce) : base(ce)
        {
        }
    }
}
