using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //readonly olarak tanımladığımız bir değişken ya tanımlandığı esnada o satırda bir değer ataması yapılabilir veya bir constructor method içerisin de bir değer ataması yapılabilmektedir. Yanlışlıkla farklı yerler de farkında olmadan set işlemi yapmamak için bu şekilde readonly tanımlayabiliriz.
        protected readonly AppDbContext _context; //veritabanı tanımlaması yapıldı. Protected yapıldı çünkü miras alınan sınıflardada kullanılabilmesini istiyorum.
        private readonly DbSet<T> _dbSet; //_dbSet bizim entity'mize yani veritabanında ki tablolarımıza karşılık gelir.
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);               
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable(); //AsNoTracking kullanıldı çünkü ef core çekmiş olduğu data'ları memory'e almasın. Track etmesin ki daha performanslı çalışsın.
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); //Find() method'u id'yi bulmamıza yaramaktadır.
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity); 
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
