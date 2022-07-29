using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class //IGenericRepository'de ki method imzalarını buraya da yazıyoruz ama dönüş tiplerin de farklılıklar yapıyoruz.
    { 
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity); //Veritabanına bu değişiklikleri yansıtacağımız için  burada update ve remove'un async methodları vardır. IGenericRepository'i yazarken bunların asenkron olarak yazamayız.
        Task RemoveAsync(T entity); 
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
