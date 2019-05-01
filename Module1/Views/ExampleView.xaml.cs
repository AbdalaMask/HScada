using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HScada.PLCModule.Model;

namespace Module1.Views
{
    /// <summary>
    /// ExampleView.xaml 的交互逻辑
    /// </summary>
    public partial class ExampleView : UserControl
    {
        HScada.Services.Contract.ILog _log;
        private SiemensS7PlcVar mybit;

        public ExampleView(HScada.Services.Contract.ILog log)
        {
            InitializeComponent();
            _log = log;
            //var plc = HScada.PLCModule.PlcModule.SiemensPlc.First(t => t.Name == "plc");
            //var group = plc.VarGroupList.First(t => t.Name == "group");
            //mybit = group.VarList.First(t => t.VarName == "mybit");

            //group.OnVarGroupRead -= OngroupRead;
            //mybit.OnValueChanged -= OnPlcVarValueChanged;
            //group.OnVarGroupRead += OngroupRead;
            //mybit.OnValueChanged += OnPlcVarValueChanged;

            //System.Threading.Thread mythread = new System.Threading.Thread(myThreadExecuteMethod) { IsBackground = true };
            //mythread.Start();
        }

        private void myThreadExecuteMethod()
        {
            while (true)
            {
                _log.Debug($"{DateTime.Now}  mybit value: {mybit.Value}");
                System.Threading.Thread.Sleep(5000);
            }
        }

        private void OnPlcVarValueChanged(object arg1, object arg2)
        {
            _log.Info($"{DateTime.Now} mybit  old value:{arg1}   new value:{arg2}");
        }

        private void OngroupRead(SiemensS7VarGroup obj)
        {
            //foreach (var item in obj.VarList)
            //{
            //    _log.Debug($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}  name:{item.FullName}  value:{item?.Value ?? ""}");

            //}
        }
    }
}
