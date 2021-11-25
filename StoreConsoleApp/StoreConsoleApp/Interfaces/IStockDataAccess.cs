using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    interface IStockDataAccess
    {
        List<Stocks> GetStocksList();

        Stocks GetStock(int id);

        bool AddStock(Stocks stock);

        bool UpdateStock(Stocks stock);

        bool DeleteStock(int id);

    }
}
