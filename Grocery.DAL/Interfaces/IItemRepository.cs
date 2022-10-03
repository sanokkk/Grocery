using System.Threading.Tasks;
using Grocery.Domain.Models;

namespace Grocery.DAL.Interfaces
{

    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<Item> GetByName(string name);
        Task<Item> Get(int Id);
    }
}