using HScada.DAL.DBContext;
using HScada.DAL.Model;
using HScada.PLCModule.Model;
using HScada.Services.Contract;
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

namespace Module1.Views
{
    /// <summary>
    /// SqliteTestView.xaml 的交互逻辑
    /// </summary>
    public partial class SqliteTestView : UserControl
    {
        
        ILog _log;

        public SqliteTestView(ILog log)
        {
            _log = log;
            InitializeComponent();
        }


        //建表
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //创建数据仓储
            var dr = new HScada.DAL.Repository.SQLiteDataRepository();
            //创建表
            dr.db.InitTable(typeof(Person));
            _log.Info("建表成功,可以用tools目录下的sqlitespy查看");

        }
        //增
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //创建数据仓储
            var dr = new HScada.DAL.Repository.SQLiteDataRepository();
            if (dr.Add(new Person { Id = Guid.NewGuid().ToString(), Name = "小红", Year = 18, }))
            {
                _log.Info("成功插入小红");
            }
            if (dr.Add(new Person { Id = Guid.NewGuid().ToString(), Name = "小明", Year = 99, }))
            {
                _log.Info("成功插入小明");

            }

        }
        //查
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //创建数据仓储
            var dr = new HScada.DAL.Repository.SQLiteDataRepository();
            //查所有
            var list = dr.GetAll<Person>();
            _log.Info($"查到{list?.Count() ?? 0}条数据");

            //此外还有这些写法
            var r1 = dr.GetByID<Person>("主键是多少");
            //var r2 = dr.GetBySql<Person>("sql语句");
            //var r3 = dr.GetByExp<Person>(model=>model.Id == "按条件查");
        }

        //删
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //创建数据仓储
            var dr = new HScada.DAL.Repository.SQLiteDataRepository();

            //按条件删除
            var list = dr.GetAll<Person>();
            if (dr.Delete<Person>(t=>list.First().Id == t.Id))
            {
                _log.Info("删除单条数据");
            }

            //删除所有
            dr.DeleteAll<Person>();
            _log.Info("删除所有数据");

        }
        //改
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //创建数据仓储
            var dr = new HScada.DAL.Repository.SQLiteDataRepository();
            //得到第一行数据
            var row1 = dr.GetAll<Person>().First();
            //修改数据
            row1.Name = "HScada";
            //修改更新到数据库
            if (dr.Update(row1, model => model.Id == row1.Id)) 
            {
                _log.Info("第一行数据的名字修改为HScada");
            }
        }
    }
}
