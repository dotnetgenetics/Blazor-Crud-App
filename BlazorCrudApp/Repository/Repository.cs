using BlazorCrudApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorCrudApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private EmployeeDBContext _context;

        public Repository(EmployeeDBContext context)
        {
            this._context = context;
        }

        public void Add(T Entity)
        {
            _context.Set<T>().Add(Entity);
            _context.SaveChanges();
        }

        public void Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetByID(int Id)
        {
            var entity = _context.Set<T>().Find(Id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public void Update(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            _context.Set<T>().Update(Entity);
            _context.SaveChanges();
        }
    }
}
