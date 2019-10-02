using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Model
{
    public class Order
    {
        public int Id { set; get; }
        public int CustomerId { set; get; }
        public int ItemId { set; get; }
        public int Quantity { set; get; }
        public double TotalPrice { set; get; }
    }
}
