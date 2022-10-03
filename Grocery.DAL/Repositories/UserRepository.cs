using Grocery.DAL.Interfaces;
using Grocery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.DAL.Repositories
{
    public class UserRepository: IBaseRepository<User>
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(User User)
        {
            await _db.Users.AddAsync(User);
            await _db.SaveChangesAsync();
            
        }

        public async Task Delete(User User)
        {
            _db.Users.Remove(User);
            await _db.SaveChangesAsync();
            
        }

        public Task<Item> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User>  Select()
        {
            return _db.Users;
        }

        public async Task<User> Update(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
