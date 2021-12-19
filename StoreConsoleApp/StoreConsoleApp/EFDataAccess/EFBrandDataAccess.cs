using StoreConsoleApp;
using StoreConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.DataAccess
{
    public class EFBrandDataAccess : IBrandDataAccess
    {

        private readonly StoreContext _dbContext;

        public EFBrandDataAccess()
        {
            _dbContext = new StoreContext();
        }

        public bool AddBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            int affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }

        public bool DeleteBrand(int id)
        {
            var brand = _dbContext.Brands.Find(id);
            if (brand == null)
                throw new ArgumentOutOfRangeException("id", $"There is no brand with id '{id}'");

            _dbContext.Brands.Remove(brand);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;

        }

        public Brand GetBrand(int id)
        {
            return _dbContext.Brands.Find(id);
        }

        public List<Brand> GetBrandList()
        {
            return _dbContext.Brands.ToList();
        }

        public bool UpdateBrand(Brand brand)
        {
            var entry = _dbContext.Entry(brand);
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                _dbContext.Brands.Attach(brand);

            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }
    }
}
