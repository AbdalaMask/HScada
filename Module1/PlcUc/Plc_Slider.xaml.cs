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
    /// Plc_Slider.xaml 的交互逻辑
    /// </summary>
    public partial class Plc_Slider : HScada.PLCModule.PlcUC.VCBase
    {
        public Plc_Slider()
        {
            InitializeComponent();
        }



        public string Max
        {
            get { return (string)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(string), typeof(Plc_Slider), new PropertyMetadata(string.Empty, VarChangedMothed));




        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(Plc_Slider), new PropertyMetadata(string.Empty, VarChangedMothed));

        private void Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            var v = Vars[nameof(this.Value)];
            if (v == null)
                return;
            var sv = this.slider.Value;
            Task.Run(() =>
            {
                v.Write(Math.Round(sv,2));

            });
        }
    }
}
