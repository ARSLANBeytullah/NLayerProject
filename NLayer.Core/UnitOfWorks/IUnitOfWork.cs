using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //Bunlar farklı bir sınıftan implemente ettiğimiz de DbContex'in SaveChanges ve SaveChangesAsync methodları çağrılmış olacak
        //Commit : SaveChanges methodunu çağırır. CommitAsync : DbContext.SaveChangesAsync methodunu çağırır.
        Task CommitAsync();
        void Commit();
         
    }
}
