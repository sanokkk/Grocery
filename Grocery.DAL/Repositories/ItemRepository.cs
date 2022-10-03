using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocery.DAL.Interfaces;
using Grocery.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Grocery.DAL.Repositories
{

    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(Item Item)
        {
            await _db.Item.AddAsync(Item);
            await _db.SaveChangesAsync();
            
        }

        public async Task<Item> Get(int Id)
        {
            return await _db.Item.FirstOrDefaultAsync(x => x.Id == Id);
        }


        public IQueryable<Item> Select() //асинхронность для возможности получения данных и возможности исп-я функций
        {
            return _db.Item;
        }

        public async Task Delete(Item Item)
        {
            _db.Item.Remove(Item);
            await _db.SaveChangesAsync();
            
        }

        public async Task<Item> GetByName(string name)
        {
            return await _db.Item.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Item> Update(Item item)
        {
            _db.Item.Update(item);
            await _db.SaveChangesAsync();
            return item;
        }
    }
}