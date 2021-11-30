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

        OrderItem GetOrderItem(int id);

        bool AddOrderItem(OrderItem orderItem);

        bool UPdateOrderItem(OrderItem orderItem);

        bool DeleteOrderItem(int id);
    }
}
