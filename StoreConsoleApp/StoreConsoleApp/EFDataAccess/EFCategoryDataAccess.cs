
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
    public class EFCategoryDataAccess : ICategoryDataAccess
    {
        private readonly StoreContext _dbContext; 
        public EFCategoryDataAccess()
        {
            _dbContext = new StoreContext();
        }
        public bool AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;

        }

        public bool DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
                throw new ArgumentOutOfRangeException("id", $"There is no category with id '{id}' ");
            
            _dbContext.Categories.Remove(category);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }

        public Category GetCategory(int id)
        {
            
            return _dbContext.Categories.Find(id);
        }

        public List<Category> GetCategoryList()
        { 
            return _dbContext.Categories.ToList();
        }

        public bool UpdateCategory(Category category)
        {
            var entry =_dbContext.Entry(category);
            if (entry.State == EntityState.Detached)
                _dbContext.Categories.Attach(category);

            entry.State= EntityState.Modified;
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }
    }
}
