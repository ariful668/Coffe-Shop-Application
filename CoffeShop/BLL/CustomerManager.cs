using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeShop.Repository;

namespace CoffeShop.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(string name, string address, string contact)
        {
            return _customerRepository.Add(name, address,contact);
        }

        public bool IsNameExist(string name)
        {
            return _customerRepository.IsNameExist(name);
        }

        public bool Update(string name, string address, string contact, int id)
        {
            return _customerRepository.Update(name, address, contact, id);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }
        public DataTable Search(string name)
        {
            return _customerRepository.Search(name);
        }
    }
}
