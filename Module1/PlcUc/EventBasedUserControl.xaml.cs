using HScada.PLCModule.PlcUC;
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

namespace Module1.PlcUc
{
    /// <summary>
    /// EventBasedUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class EventBasedUserControl : VCBase
    {
        public EventBasedUserControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 用plc变量控制textbox的文本
        /// </summary>
        public string ValueVar
        {
            get { return (string)GetValue(ValueVarProperty); }
            set { SetValue(ValueVarProperty, value); }
        }
        public static readonly DependencyProperty ValueVarProperty =
            DependencyProperty.Register("ValueVar", typeof(string), typeof(EventBasedUserControl), new PropertyMetadata(string.Empty, VCBase.VarChangedMothed));



        /// <summary>
        /// 用plc变量控制textblock的是否使能 true:使用 false:不使能
        /// </summary>
        public string IsEnableVar
        {
            get { return (string)GetValue(IsEnableVarProperty); }
            set { SetValue(IsEnableVarProperty, value); }
        }
        public static readonly DependencyProperty IsEnableVarProperty =
            DependencyProperty.Register("IsEnableVar", typeof(string), typeof(EventBasedUserControl), new PropertyMetadata(string.Empty, VCBase.VarChangedMothed));

        /// <summary>
        /// 重写init   当事件没有订阅时, 主动用此方法获取控件应该有的状态
        /// </summary>
        protected override void Init()
        {
            base.Init();

            var isenablePlcVar = Vars[nameof(this.IsEnableVar)];
            var ValueVar = Vars[nameof(this.ValueVar)];
            //注意这里是异步线程
            this.Dispatcher.Invoke(() =>
            {
                tb.Text = ValueVar?.Value?.ToString() ?? "";
                if (bool.TryParse(isenablePlcVar?.Value?.ToString() ?? "False", out bool plcBool))
                {
                    tb.IsEnabled = plcBool;
                }
            });

        }

        /// <summary>
        /// 当plc变量改变时做这些事件
        /// </summary>
        /// <param name="varfullname"></param>
        /// <param name="oldState"></param>
        /// <param name="newState"></param>
        protected override void OnVarValueChanged(string varfullname, object oldState, object newState)
        {
            base.OnVarValueChanged(varfullname, oldState, newState);
            this.Dispatcher.Invoke(() =>
            {
                var isenablePlcVar = Vars[nameof(this.IsEnableVar)];
                var ValueVar = Vars[nameof(this.ValueVar)];

                //注意这里是异步线程
                if (varfullname == isenablePlcVar?.FullName)
                {
                    if (bool.TryParse(newState?.ToString() ?? "False", out bool plcBool))
                    {
                        tb.IsEnabled = plcBool;
                    }
                }
                else if (varfullname == ValueVar?.FullName)
                {
                    tb.Text = newState.ToString() ?? "";
                }
            });
        }

    }
}
