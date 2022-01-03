using ConsoleApp1.Interfaces;
using StoreConsoleApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    public class EFStockDataAccess : IStockDataAccess
    {
        private readonly StoreContext _dbContext;
        public EFStockDataAccess()
        {
            _dbContext = new StoreContext();
        }
       
        public bool AddStock(Stock stock)
        {
            _dbContext.Stocks.Add(stock);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;

        }

        public bool DeleteStock(int storeId,int productId)
        {
            var stock = _dbContext.Stocks.Find(storeId,productId);
            if(stock == null)
                throw new ArgumentOutOfRangeException("id", $"There is no product with id ,{productId}");
            
            _dbContext.Stocks.Remove(stock);
            var deletedRows = _dbContext.SaveChanges();
            return deletedRows > 0;
        }

        public Stock GetStock(int storeId,int productId)
        {
            return _dbContext.Stocks.Find(storeId,productId);

        }

        public List<Stock> GetStocksList()
        {   
            return _dbContext.Stocks.ToList();
        }
        public bool UpdateStock(Stock stock)
        {
            var entry = _dbContext.Entry(stock);
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                _dbContext.Stocks.Attach(stock);

            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }
    }
}
