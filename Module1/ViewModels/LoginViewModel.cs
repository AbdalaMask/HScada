using Prism.Commands;
using Prism.Ioc;
using HScada.PLCModule.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HScada.SystemElement.MVVM;

namespace Module1.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(IContainerExtension ce) : base(ce)
        {
        }

        private DelegateCommand _LoginCommand;
        public DelegateCommand LoginCommand =>
            _LoginCommand ?? (_LoginCommand = new DelegateCommand(ExecuteLoginCommand));

        void ExecuteLoginCommand()
        {
            HBBFrameWorkHelper.IsLogined = true;
        }
    }
}
