using Grocery.DAL.Interfaces;
using Grocery.Domain.Enum;
using Grocery.Domain.Models;
using Grocery.Domain.Response;
using Grocery.Domain.ViewModels.Item;
using Grocery.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Service.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemrepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemrepository = itemRepository;
        }

        public async Task<IBaseResponse<Item>> Get(int id)
        {
            var response = new BaseResponse<Item>();
            try
            {
                var item = await _itemrepository.Get(id);
                if (item == null)
                {
                    response.Description = "Нет такого товара!";
                    response.StatusCode = StatusCode.ItemNotFound;
                    return response;
                }
                response.Data = item;
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Item>() 
                {
                    Description = $"[Get] - {ex.Message}"
                }; 
            }
        }

        public async Task<IBaseResponse<Item>> GetItemByName(string name)
        {
            var response = new BaseResponse<Item>();
            try
            {
                var item = await _itemrepository.GetByName(name);
                if (item == null)
                {
                    response.Description = "Нет такого товара!";
                    response.StatusCode = StatusCode.ItemNotFound;
                    return response;
                }
                response.StatusCode = StatusCode.OK;
                response.Data = item;
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Item>()
                {
                    Description = $"[GetItemByName] - {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<ItemViewModel>> AddItem(ItemViewModel itemViewModel)
        {
            var response = new BaseResponse<ItemViewModel>();
            try
            {
                Item item = new Item()
                {
                    Id = itemViewModel.Id,
                    Name = itemViewModel.Name,
                    Description = itemViewModel.Description,
                    Price = itemViewModel.Price,
                    ItemType = itemViewModel.ItemType,
                    Image = itemViewModel.Image

                };
                await _itemrepository.Add(item);
                return response;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ItemViewModel>()
                {
                    Description = $"[Delete] - {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteItem(int id)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var item = await _itemrepository.Get(id);
                if (item == null)
                {
                    response.Description = "Не удалось удалить элемент";
                    response.StatusCode = StatusCode.ItemNotFound;
                    response.Data = false;
                    return response;
                }
                await _itemrepository.Delete(item);
                response.Data = true;
                response.StatusCode = StatusCode.OK;
                return response;

            }
            catch (Exception ex)
            {

                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteItem] - {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            //try
            //{
            //    var item = await _itemrepository.Get(id);
            //    if (item == null)
            //    {
            //        return new BaseResponse<bool>()
            //        {
            //            Description = "User not found",
            //            StatusCode = StatusCode.ItemNotFound,
            //            Data = false
            //        };
            //    }

            //    await _itemrepository.Delete(item);

            //    return new BaseResponse<bool>()
            //    {
            //        Data = true,
            //        StatusCode = StatusCode.OK
            //    };
            //}
            //catch (Exception ex)
            //{
            //    return new BaseResponse<bool>()
            //    {
            //        Description = $"[DeleteItem] : {ex.Message}",
            //        StatusCode = StatusCode.InternalServerError
            //    };
            //}
        }

        public  IBaseResponse<List<Item>> GetItems()
        {
            var response = new BaseResponse<IQueryable<Item>>();
            try
            {
                var items =  _itemrepository.Select().ToList();
                if (!items.Any())
                {
                    return new BaseResponse<List<Item>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<List<Item>>()
                {
                    Data = items,
                    StatusCode = StatusCode.OK
                };
               
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Item>>()
                {
                    Description = $"[GetItems - {ex.Message}]",
                    StatusCode = StatusCode.InternalServerError

                };
            }
        }

        public async Task<IBaseResponse<Item>> Edit(int id, ItemViewModel model)
        {
            var baseResponse = new BaseResponse<Item>();
            try
            {
                var item = await _itemrepository.Get(id);
                if (item == null)
                {
                    baseResponse.StatusCode = StatusCode.ItemNotFound;
                    baseResponse.Description = "Item not found";
                    return baseResponse;
                }

                item.Description = model.Description;
                item.Price = model.Price;
                item.Name = model.Name;
                item.Id = model.Id;
                await _itemrepository.Update(item);
                baseResponse.Data = item;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Item>()
                {
                    Description = $"[Edit] - {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
