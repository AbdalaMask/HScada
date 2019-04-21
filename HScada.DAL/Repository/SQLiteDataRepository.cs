using HScada.DAL.Contract;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HScada.DAL.Repository
{
    public class SQLiteDataRepository : DBContext.SqliteDBContext, IDataRepository
    {
        public bool Add<T>(T model) where T : class, new()
        {
            var count = db.Insertable(model).ExecuteCommand();
            return count > 0;
        }
        public int Add<T>(List<T> modelList) where T : class, new()
        {
            var ddd = new SimpleClient<T>(db);
            var count = ddd.InsertRange(modelList);
            return count ? 1 : 0;
        }

        public bool Delete<T>(Expression<Func<T,bool>> exp) where T : class, new()
        {
            var count = db.Deleteable<T>().Where(exp).ExecuteCommand();
            return count > 0;
        }
        public void DeleteAll<T>() where T : class, new()
        {
            db.Deleteable<T>().Where(it => 1 == 1).ExecuteCommand();
        }

        public List<T> GetAll<T>() where T : class, new()
        {
            return db.Queryable<T>().ToList() ?? new List<T>();
        }
        public List<T> GetByExp<T>(Expression<Func<T, bool>> exp) where T : class, new()
        {
            return db.Queryable<T>().WhereIF(true, exp).ToList();
        }
        public List<T> GetBySql<T>(string sql) where T : class, new()
        {
            return db.SqlQueryable<T>(sql).ToList();
        }
        public T GetByID<T>(object id) where T : class, new()
        {
            return db.Queryable<T>().InSingle(id);
        }

        public bool Update<T>(T model,Expression<Func<T,bool>> exp) where T : class, new()
        {
            var count = db.Updateable(model).Where(exp).ExecuteCommand();
            return count > 0;
        }

        public bool TranInvoke(Action action)
        {
            var result = db.Ado.UseTran(() =>
            {
                action.Invoke();
            });
            if (result.IsSuccess)
            {
                return true;
            }
            else
            {
                SqlLog.Fault($"{DateTime.Now}事务异常 \n{result.ErrorMessage}\n\n");
                return false;
            }
        }


    }
}
