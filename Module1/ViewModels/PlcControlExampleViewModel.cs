using HScada.SystemElement.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.ViewModels
{
    public class PlcControlExampleViewModel : ViewModelBase
    {
        private string _TestVarNameBinding;
        /// <summary>
        /// 测试绑定变量名称
        /// </summary>
        public string TestVarNameBinding
        {
            get { return _TestVarNameBinding; }
            set
            {
                _TestVarNameBinding = value;
                RaisePropertyChanged();
            }
        }

    }
}
