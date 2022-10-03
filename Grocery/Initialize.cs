using Grocery.DAL.Interfaces;
using Grocery.DAL.Repositories;
using Grocery.Domain.Models;
using Grocery.Service.Implementations;
using Grocery.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery
{
    public static class Initialize
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
