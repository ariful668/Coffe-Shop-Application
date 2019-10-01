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
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public bool IsNameExist(Customer customer)
        {
            return _customerRepository.IsNameExist(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public bool Delete(Customer customer)
        {
            return _customerRepository.Delete(customer);
        }
        public DataTable Search(string name)
        {
            return _customerRepository.Search(name);
        }
    }
}
