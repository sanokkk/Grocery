using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocery.Domain.Models;

namespace Grocery.DAL.Interfaces
{

    public interface IBaseRepository<T>
    {
        
        public Task Add(T Item);


        IQueryable<T> Select();

        Task Delete(T Item);

        Task<T> Update(T item);
    }
}
    
    