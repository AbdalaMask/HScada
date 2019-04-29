using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HScada.SystemElement.MVVM;
using HScada.SystemElement.Helper;

namespace Module1.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private DelegateCommand _LoginCommand;
        public DelegateCommand LoginCommand =>
            _LoginCommand ?? (_LoginCommand = new DelegateCommand(ExecuteLoginCommand));

        void ExecuteLoginCommand()
        {
            HBBFrameWorkHelper.IsLogined = true;
        }
    }
}
