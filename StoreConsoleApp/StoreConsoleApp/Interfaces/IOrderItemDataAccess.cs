using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IOrderItemDataAccess
    {
        List<OrderItem> GetOrderItemsList();

        OrderItem GetOrderItems(int id);

        bool AddOrderItems(OrderItem oredrItem);

        bool UPdateOrderItems(OrderItem orderItem);

        bool DeleteOrderItem(int id);
    }
}
