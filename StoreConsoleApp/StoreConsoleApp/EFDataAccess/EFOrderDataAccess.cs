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
    public class EFOrderDataAccess : IOrderDataAccess
    {
        private readonly StoreContext _dbContext;
        public EFOrderDataAccess()
        {
            _dbContext = new StoreContext();
        }
        
        public bool AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }

        public bool DeleteOrder(int id)
        {
            var order = _dbContext.Orders.Find(id);
            if(order == null)
                throw new ArgumentOutOfRangeException("id", $"There is no order with id '{id}'");

            _dbContext.Orders.Remove(order);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }

        public Order GetOrder(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public List<Order> GetOrdersList()
        {
            return _dbContext.Orders.ToList();
        }

        public bool UpdateOrder(Order order)
        {
            var entry=_dbContext.Entry(order);
            if (entry.State == EntityState.Detached)
                _dbContext.Orders.Attach(order);
            
            entry.State = EntityState.Modified;
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }
    }
}
