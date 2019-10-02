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
    public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        public bool Add(Order order)
        {
            return _orderRepository.Add(order);
        }


        public bool Update(Order order)
        {
            return _orderRepository.Update(order);
        }

        public DataTable Display()
        {
            return _orderRepository.Display();
        }

        public bool Delete(Order order)
        {
            return _orderRepository.Delete(order);
        }
        public DataTable Search(string name)
        {
            return _orderRepository.Search(name);
        }
        public DataTable itemCombo()
        {
            return _orderRepository.itemCombo();
        }
        public DataTable customerCombo()
        {
            return _orderRepository.customerCombo();
        }
    }
}
