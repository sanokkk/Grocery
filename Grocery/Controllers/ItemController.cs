using System.Linq;
using System.Threading.Tasks;
using Grocery.DAL.Interfaces;
using Grocery.Domain.Enum;
using Grocery.Domain.Models;
using Grocery.Domain.ViewModels.Item;
using Grocery.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemservice;
        private readonly IItemRepository _itemrepository;

        public ItemController(IItemService itemService, IItemRepository itemrepository)
        {
            _itemservice = itemService;
            _itemrepository = itemrepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var response = _itemservice.GetItems();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(response.Data);
            return RedirectToAction("Error");
        }




        [HttpGet]
        public async Task<IActionResult> GetItemByID(int id)
        {
            var item = await _itemservice.Get(id);
            if (item.StatusCode == Domain.Enum.StatusCode.OK)
                return View(item.Data);
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetItemByName(string name)
        {
            var item = await _itemservice.GetItemByName(name);
            if (item.StatusCode == Domain.Enum.StatusCode.OK)
                return View(item.Data);
            return RedirectToAction("Error");
        }




        [HttpGet]
        public async Task<IActionResult> AddItem()
        {
            var itemViewModel = new ItemViewModel()
            {

                Name = "Кола",
                Description = "Освежающая кола",
                Price = 69,
                ItemType = ItemType.Drinks,
                Image = "/img/кола.png"
            };
            var itemViewModel2 = new ItemViewModel()
            {

                Name = "Грудка куриная",
                Description = "Сочное мясо",
                Price = 120,
                ItemType = ItemType.Meat,
                Image = "/img/курица.png"
            };

            await _itemservice.AddItem(itemViewModel);
            await _itemservice.AddItem(itemViewModel2);
            return View();
        }


        

        //[Authorize(Roles = "Admin")]
        
        public async Task<IActionResult> DeleteItem(int id)//только для администратора
        {
            var response =  await _itemservice.DeleteItem(id);
            
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return RedirectToAction("GetItems", "Item");
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id) 
        {
            if (id == 0)
                return View();
            var response = await _itemservice.Get(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");

        }


        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Save(ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                if (itemViewModel.Id == 0)
                {
                    await _itemservice.AddItem(itemViewModel);
                }
                else
                {
                    await _itemservice.Edit(itemViewModel.Id, itemViewModel);
                }
            }
            return RedirectToAction("GetItems");
        }
        



    }
}