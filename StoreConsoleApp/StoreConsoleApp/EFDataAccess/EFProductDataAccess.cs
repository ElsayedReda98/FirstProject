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
    public class EFProductDataAccess :IProductDataAccess

    {
        private readonly StoreContext _dbContext;

        public EFProductDataAccess()
        {
            _dbContext = new StoreContext();
        }

        public bool AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;

        }
        
        public bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.Find(id);
            if(product == null)
                throw new ArgumentOutOfRangeException("id", $"There is no product with id '{id}'");

            _dbContext.Products.Remove(product);
            var deletedRows = _dbContext.SaveChanges();
            return deletedRows > 0;

        }

        public Product GetProduct(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public   List<Product> GetProductsList()
        {
            return  _dbContext.Products.ToList();
        }

        public bool UpdateProduct(Product product)
        {
            var entry = _dbContext.Entry(product);
            if (entry.State == EntityState.Detached)
                _dbContext.Products.Attach(product);

            entry.State = EntityState.Modified;
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }
    }
}

