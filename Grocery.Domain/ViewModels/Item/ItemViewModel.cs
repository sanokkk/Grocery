using Grocery.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Domain.ViewModels.Item
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public ItemType ItemType { get; set; }

        public string Image { get; set; }
    }
}
