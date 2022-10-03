using Grocery.Domain.Models;
using Grocery.Domain.Response;
using Grocery.Domain.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Service.Interfaces
{
    public interface IItemService
    {
        public IBaseResponse<List<Item>> GetItems();
        public Task<IBaseResponse<Item>> Get(int id);

        public Task<IBaseResponse<Item>> GetItemByName(string name);

        public Task<IBaseResponse<bool>> DeleteItem(int id);

        public Task<IBaseResponse<ItemViewModel>> AddItem(ItemViewModel item);

        public Task<IBaseResponse<Item>> Edit(int id, ItemViewModel model);
    }
}
