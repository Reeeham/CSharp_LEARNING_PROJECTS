using AutoLotDAL_Core2.EF;
using AutoLotDAL_Core2.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AutoLotDAL_Core2.Model.Repos
{
    //limit the generic class to be classes of EntityBase
    public class BaseRepo<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        //add two private readonly variables to hold the context and the DbSet<T>
        private readonly DbSet<T> _table;
        private readonly AutoLotContext _db;
        protected AutoLotContext Context => _db;//protected field to expose the context to any child classes 
        public BaseRepo() : this(new AutoLotContext())
        {

        }
        public BaseRepo(AutoLotContext context)
        {
            _db = context;
            _table = _db.Set<T>();
        }
        public void Dispose()
        {
            _db?.Dispose();
        }
        // the add method are similar to the ef6 version except in this version i chose to just use
        //Add() with overloads 
        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }
        public int Add(IList<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }
        // the update method have changed as ef core has add update and updaterange methods 
        // instead of having to change EntityState.Modified you just call Update()/UpdateRange()
        //on the DbSet<T>
        public int Update(T entity)
        {
            _table.Update(entity);
            return SaveChanges();
        }
        public int Update(IList<T> entities)
        {
            _table.UpdateRange(entities);
            return SaveChanges();
        }
        // the Delete(), GetOne(), GetAll() methods are the same as the EF 6 versions

        public int Delete(int id, byte[] timeStamp)
        {
            _db.Entry(new T() { Id = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return SaveChanges();
        }
        public int Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
        public T GetOne(int? id) => _table.Find(id);
        public virtual List<T> GetAll() => _table.ToList();
        // the GetAll() and new GetSome() methods use the expressions to refine the queries
        public List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending)
            => (ascending ? _table.OrderBy(orderBy) : _table.OrderByDescending(orderBy)).ToList();
        public List<T> GetSome(Expression<Func<T, bool>> where)
            => _table.Where(where).ToList();

        public List<T> ExecuteQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteQuery(string sql, object[] sqlParamterObjects)
        {
            throw new NotImplementedException();
        }

        /// EF Core introduced a new method used for processing raw sql queries 
        /// the FromSql() method can only populate a DbSet<T> property of the context 
        /// there's a backlog item to permit adhoc class population 
        /// but there isn't a timetable associated with it , this soesn't mean the class needs to be 
        /// mapped to a database table, it just has to be in the context as a DbSet<T> you could add unmapped
        /// property to the context as  follows and use it with FromSql()
        //[NotMapped]
        //public DbSet<MyViewModel> ViewModels { get; set; }
        /// the query columns have to match the mapped columns on the model,
        /// all columns must be returned and you cannot return related data(from the initial query)
        /// one of the great features of FromSql() is that you can add LINQQ queries on top of the call
        /// for example if you want to return all cars records and the related order and customer records
        /// you can write this
        /// return Context.Cars.FromSql("SELECT * FROM Inventory).Include(x=>x.Orders).ThenInclude(x=>x.Customer).ToList()
        /// this also demonstrates the new ThenInclude() to pull in related data after an Include().
        /// 

        ///you should extremly careful running raw sql strings against a data store especially if the s
        ///string accepts input from a user. Doing so makes your application ripe for SQL injection
        ///attacks i want to point out the danger of running raw sql statements
        ///

        //the final method wraps the Context's SaveChanges() method
        //the exception handlers for the SaveChanges() method on the DbContext are simply stubbed out 
        // in aproduction app you would need to handle any exception accordingly
        internal int SaveChanges() {
            try {
                return _db.SaveChanges();
            } catch (DbUpdateConcurrencyException ex)
            {
                // thrown when there is a concurrency error
                //for now , just rethrow the exception 
                throw ex;
            } catch (RetryLimitExceededException ex)
            {
                //thrown when max retries hve been hit
                // examine the inner exceptions for additional details
                //for now just rethrow the exception
                throw ex;
            } catch (DbUpdateException ex)
            {
                //thrown when database update fails 
                //examine the inner exceptions for additional details and affedcted objects
                //for now just rethrow the exception
                throw ex;
            } catch (Exception ex)
            {
                //some other exception happend and should be handled
                throw ex;
            }

        }

        /// creating a new instance of the DbContext can be an expensive process from a performance 
        /// perspective. ASP.NET Core2 and EF Core2 have added support for context pooling 

    }

}