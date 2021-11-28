using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IOrderDataAccess
    {
        List<Order> GetOrdersList();

        Order GetOrder(int id);
        
        bool AddOrder(Order order);

        bool UpdateOrder(int id);

        bool DeleteOrder(int id);

    }
}
