using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    public interface IStockDataAccess
    {
        List<Stock> GetStocksList();

        Stock GetStock(int storeId, int productId);

        List<Stock> GetStock(int storeId);

        bool AddStock(Stock stock);

        bool UpdateStock(Stock stock);

        bool DeleteStock(int id, int productId);
    }
}
