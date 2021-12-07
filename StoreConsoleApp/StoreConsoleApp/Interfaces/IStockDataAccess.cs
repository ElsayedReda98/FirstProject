using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    public interface IStockDataAccess
    {
        List<Stock> GetStockList();

        Stock GetStock(int storeId, int productId);

        bool AddStock(Stock stock);

        bool UpdateStock(Stock stock);

        bool DeleteStock(int id, int productId);
    }
}
