using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HScada.DAL.Model
{
    public class Person
    {
        //不能为空, 主键, 长度32 
        [SugarColumn(IsNullable = false, IsPrimaryKey = true,Length =32)]
        public string Id { set; get; }

        //长度10, 可空
        [SugarColumn(Length = 10,IsNullable =true)]
        public string Name { set; get; }

        //长度32 ,可空
        [SugarColumn(Length = 32,IsNullable =true)]
        public int Year { get; set; }

        //忽略此字段
        [SugarColumn(IsIgnore =true)]
        public List<Person> Children { get; set; }

    }
}
