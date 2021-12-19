using ConsoleApp1.Interfaces;
using Microsoft.EntityFrameworkCore;
using StoreConsoleApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    public class EFCustomerDataAccess : ICustomerDataAccess
    {
        private readonly StoreContext _dbContext;
        public EFCustomerDataAccess()
        {
            _dbContext = new StoreContext();
        }


        public bool AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }


        public bool DeleteCustomer(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            if (customer == null)
                throw new ArgumentOutOfRangeException("id", $"There is no customer with id '{id}'");
            _dbContext.Customers.Remove(customer);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }

        public Customer GetCustomer(int id)
        {
            return _dbContext.Customers.Find(id);
        }

        public List<Customer> GetCustomerList()
        {

            return _dbContext.Customers.ToList();
        }

        public bool UpdateCustomer(Customer customer)
        {
            var entry = _dbContext.Entry(customer);
            if (entry.State == EntityState.Detached)
                _dbContext.Customers.Attach(customer);

            entry.State = EntityState.Modified;
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }
    }
}
