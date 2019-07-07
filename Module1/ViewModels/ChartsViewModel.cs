using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.ViewModels
{
    public class ChartsViewModel : HScada.SystemElement.MVVM.ViewModelBase
    {
        public ChartsViewModel()
        {
            #region 趋势图
            var r = new Random();

            for (int i = 0; i < 20; i++)
            {
                Values1.Add(new ObservableValue(r.Next(0, 20)));
            }
            for (int i = 0; i < 20; i++)
            {
                Values2.Add(new ObservableValue(r.Next(0, 20)));
            }
            #endregion

            #region 饼图
            Func<ChartPoint, string> f = cp => { return $"值:{cp.Y},{cp.Participation.ToString("f2")}%"; };
            PieDataList = new SeriesCollection
            {
                new PieSeries
                {
                    Title ="饼1",
                    Values =new ChartValues<ObservableValue>{new ObservableValue(4)},
                    DataLabels = true,
                    LabelPoint =f
                },
                new PieSeries
                {
                    Title ="饼2",
                    Values =new ChartValues<ObservableValue>{new ObservableValue(3)},
                    DataLabels = true,
                    LabelPoint =f,
                    FontSize = 18
                },
                new PieSeries
                {
                    Title ="饼3",
                    Values =new ChartValues<ObservableValue>{new ObservableValue(8)},
                    DataLabels = true,
                    LabelPoint =f
                },



        };
            #endregion

            #region 柱状图
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    FontSize =33,
                    Values = new ChartValues<double> { 10.1245, 50.1245, 39.1245, 50,78,99 },
                }
            };

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11.1245, 56, 42.1245 },
            });

            SeriesCollection[1].Values.Add(48d);
            SeriesCollection[0].Values.Add(49d);
            Labels = new[] { "柱1", "柱2", "柱3", "柱4", "柱5", "柱6","柱7","柱8", };
            //y轴值转为整数
            Formatter = value => value.ToString("f0");

            #endregion

        }
        #region 趋势图
        private ChartValues<ObservableValue> _Values1 = new ChartValues<ObservableValue>();

        public ChartValues<ObservableValue> Values1
        {
            get { return _Values1; }
            set
            {
                _Values1 = value;
                RaisePropertyChanged();
            }
        }

        private ChartValues<ObservableValue> _Values2 = new ChartValues<ObservableValue>();

        public ChartValues<ObservableValue> Values2
        {
            get { return _Values2; }
            set
            {
                _Values2 = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region 饼图  
        private SeriesCollection _PieDataList;

        public SeriesCollection PieDataList
        {
            get { return _PieDataList; }
            set
            {
                _PieDataList = value;
                RaisePropertyChanged();
            }
        }


        #endregion

        #region 柱状图
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        #endregion

    }
}
