using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    public interface IOrderDataAccess
    {
        List<Order> GetOrdersList();

        Order GetOrder(int id);

        bool AddOrder(Order order);

        bool UpdateOrder(Order order);

        bool DeleteOrder(int id);

    }
}
