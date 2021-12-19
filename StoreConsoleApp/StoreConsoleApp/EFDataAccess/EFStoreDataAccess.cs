
using ConsoleApp1.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreConsoleApp;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.DataAccess
{
    public class EFStoreDataAccess : IStoreDataAccess
    {
        private readonly StoreContext _dbContext;
        public EFStoreDataAccess()
        {
            _dbContext = new StoreContext();
        }
        public bool AddStore(Store store)
        {
            _dbContext.Stores.Add(store);
            var affectedRows = _dbContext.SaveChanges();

            return affectedRows > 0;
        }

        public bool DeleteStore(int id)
        {
            var store = _dbContext.Stores.Find(id);
            if (store == null)
                throw new ArgumentOutOfRangeException("id", $"Thers is no store with '{id}'");

            _dbContext.Stores.Remove(store);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }
        public List<Store> GetStoresList()
        {
            return _dbContext.Stores.ToList();
        }

        public bool UpdateStore(Store store)
        {
            var entry=_dbContext.Entry(store);
            if(entry.State ==EntityState.Detached)
                _dbContext.Stores.Attach(store);
            
            entry.State = EntityState.Modified;
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }


        public Store GetStore(int id)
        {
            return _dbContext.Stores.Find(id);

        }
         
        
    }
}
