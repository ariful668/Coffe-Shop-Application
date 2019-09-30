using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeShop.Repository;

namespace CoffeShop.BLL
{
    public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        public bool Add(string name, int qty)
        {
            return _orderRepository.Add(name, qty);
        }

        public bool IsNameExist(string name)
        {
            return _orderRepository.IsNameExist(name);
        }

        public bool Update(string name, int qty, int id)
        {
            return _orderRepository.Update(name, qty, id);
        }

        public DataTable Display()
        {
            return _orderRepository.Display();
        }

        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }
        public DataTable Search(string name)
        {
            return _orderRepository.Search(name);
        }
    }
}
