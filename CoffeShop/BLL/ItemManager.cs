using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeShop.Repository;
using CoffeShop.Model;

namespace CoffeShop.BLL
{
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();
        public bool Add(Item item)
        {
            return _itemRepository.Add(item);
        }

        public bool IsNameExist(Item item)
        {
            return _itemRepository.IsNameExist(item);
        }

        public bool Update(Item item)
        {
            return _itemRepository.Update(item);
        }

        public DataTable Display()
        {
            return _itemRepository.Display();
        }

        public bool Delete(Item item)
        {
            return _itemRepository.Delete(item);
        }
        public DataTable Search(string name)
        {
            return _itemRepository.Search(name);
        }

    }
}
