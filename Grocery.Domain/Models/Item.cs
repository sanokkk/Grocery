using Grocery.Domain.Enum;

namespace Grocery.Domain.Models
{

    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ItemType ItemType { get; set; }

    }
}