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
    public class EFOrderItemDataAccess : IOrderItemDataAccess
    {
        private readonly StoreContext _dbContext;

        public EFOrderItemDataAccess()
        {
            _dbContext = new StoreContext();
        }

        public bool AddOrderItem(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;

        }

        public bool DeleteOrderItem(int id)
        {
            var orderItem = _dbContext.OrderItems.Find(id);
            if (orderItem == null)
                throw new ArgumentOutOfRangeException("id", $"There is no orderItem with id '{id}'");

            _dbContext.OrderItems.Remove(orderItem);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;

        }

        public OrderItem GetOrderItem(int id)
        {
            return _dbContext.OrderItems.Find(id);
        }

        public List<OrderItem> GetOrderItemList()
        {
            return _dbContext.OrderItems.ToList();
        }

        public bool UPdateOrderItem(OrderItem orderItem)
        {
            var entry = _dbContext.Entry(orderItem);
            if(entry.State == EntityState.Detached)
                _dbContext.OrderItems.Attach(orderItem);

            entry.State = EntityState.Modified;
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }
    }
}
