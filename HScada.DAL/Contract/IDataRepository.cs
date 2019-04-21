using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HScada.DAL.Contract
{
    public interface IDataRepository
    {
        bool Add<T>(T model) where T:class, new();
        int Add<T>(List<T> modelList) where T : class, new();

        void DeleteAll<T>() where T : class, new();
        bool Delete<T>(System.Linq.Expressions.Expression<Func<T,bool>> exp) where T : class, new();

        List<T> GetAll<T>() where T : class, new();
        List<T> GetByExp<T>(System.Linq.Expressions.Expression<Func<T, bool>> exp) where T : class, new();
        List<T> GetBySql<T>(string sql) where T : class, new();
        T GetByID<T>(object id) where T : class, new();


        bool Update<T>(T model,System.Linq.Expressions.Expression<Func<T,bool>> exp) where T : class, new();

        bool TranInvoke(Action action);
    }
}
