using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IOrderItemDataAccess
    {
        List<OrderItem> GetOrderItemList();

        OrderItem GetOrderItem(int ordeId,int itemId);

        bool AddOrderItem(OrderItem orderItem);

        bool UPdateOrderItem(OrderItem orderItem);

        bool DeleteOrderItem(int orderId, int itemId);
    }
}
