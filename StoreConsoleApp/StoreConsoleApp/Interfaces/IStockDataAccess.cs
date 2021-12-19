using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IStockDataAccess
    {
        List<Stock> GetStocksList();

        Stock GetStock(int storeId, int productId);

        bool AddStock(Stock stock);

        bool UpdateStock(Stock stock);

        bool DeleteStock(int storeId,int productId);

    }
}
