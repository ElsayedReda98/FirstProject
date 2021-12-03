using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    public interface ICustomerDataAccess
    {
        List<Customer> GetCustomerList();

        Customer GetCustomer(int id);

        bool AddCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(int id);
    }
}
