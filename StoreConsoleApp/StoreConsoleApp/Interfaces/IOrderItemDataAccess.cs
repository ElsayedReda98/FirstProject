using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    public interface IOrderItemDataAccess
    {
        List<OrderItem> GetOrderItemList();

        OrderItem GetOrderItem(int id);

        bool AddOrderItem(OrderItem orderItem);

        bool UPdateOrderItem(OrderItem orderItem);

        bool DeleteOrderItem(int id);
    }
}
