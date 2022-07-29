using System.Linq.Expressions;

namespace NLayer.Core.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();      
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);  //ef core'da dbcontext için update ve remove için async methodları yoktur. Ama service katmanın da vardır.
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
