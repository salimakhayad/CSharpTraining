using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QueryIt
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
    public interface IReadOnlyRepository<out T> : IDisposable
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }
    // coveriant
    public interface IWriteOnlyRepository<in T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T Entity);
        int Commit();
    }
    // contraveriant
    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T> // avoid contraints on interfaces 
    {
      
    }
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        DbContext _ctx;
        DbSet<T> _set;
        public SqlRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }
        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);

            }
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Delete(T Entity)
        {
            _set.Remove(Entity);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public T FindById(int id)
        {
            return _set.Find(id);
        }
    }
}
