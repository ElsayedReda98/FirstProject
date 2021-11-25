using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    interface IOrderDataAccess
    {
        List<Orders> GetOrdersList();

        Orders GetOrder(int id);
        
        bool AddOrder(Orders order);

        bool UpdateOrder(Orders order);

        bool DeleteOrder(Orders order);

    }
}
