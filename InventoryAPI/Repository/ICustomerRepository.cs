using InventoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryAPI.Repository
{
    public interface ICustomerRepository
    {
        bool DoesItemExist(int id);
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerByID(int id);
        Task<Customer> ADDEditCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int id);
    }
}
