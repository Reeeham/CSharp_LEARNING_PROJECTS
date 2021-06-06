using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AutoLotDAL_Core2.Model.Repos
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int Add(IList<T> entities);
        int Update(T entity);
        int Update(IList<T> entities);
        int Delete(int id, byte[] timeStamp);
        int Delete(T entity);
        T GetOne(int? id);
        List<T> GetSome(Expression<Func<T, bool>> where); // return GetSome(x=>x.Color == "Pink")
        List<T> GetAll();
        List<T> GetAll<TSortField>(Expression<Func<T,TSortField>> oreberBy, bool ascending);
        // return GetAll(x=> x.PetName,true);
        List<T> ExecuteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParamterObjects);

    }
}
