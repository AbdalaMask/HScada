using HScada.DAL.Contract;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HScada.DAL.DBContext
{
    /// <summary>
    /// SqlSugar
    /// </summary>
    public class SqliteDBContext
    {
        public readonly SqlSugarClient db;
        public readonly ILog SqlLog = new Log.ConsoleLog();

        public SqliteDBContext()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = @"DataSource=../SqliteDB/SqliteDB.db3",//app工作目录下的sqliteDB.db3
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,//不用using语法释放连接
                InitKeyType = InitKeyType.Attribute,//Code first请用这个枚举
                ConfigureExternalServices = new ConfigureExternalServices
                {
                    EntityService = (property, column) =>
                    {
                        if (column.DbTableName == "Person" && property.Name == "Children")
                        {
                            column.IsIgnore = true;
                        }
                    },
                }
            });



            db.Aop.OnLogExecuted = (sql, pars) => //SQL executed event 执行后
            {
                SqlLog.Info($"sql已执行:\n参数:\n{string.Join(",", pars.Select(s => $"{s.ParameterName}:{s.Value}"))}\n\nsql语句:\n{sql}");
            };
            db.Aop.OnLogExecuting = (sql, pars) => //SQL executing event (pre-execution) 执行前
            {
                SqlLog.Info($"sql执行前:\n参数:\n{string.Join(",", pars.Select(s => $"{s.ParameterName}:{s.Value}"))}\n\nsql语句:\n{sql}");
            };
            db.Aop.OnError = (exp) =>//SQL execution error event 执行错误
            {
                SqlLog.Fault($"异常:\n{exp.Message}");
            };
        }
    }

    public static class EX
    {
        /// <summary>
        /// 备份表,初始化表结构
        /// </summary>
        /// <param name="db"></param>
        /// <param name="Model"></param>
        public static void InitTable(this SqlSugarClient db,  Type Model)
        {
            db.CodeFirst.BackupTable().InitTables(Model);
        }
    }

}
