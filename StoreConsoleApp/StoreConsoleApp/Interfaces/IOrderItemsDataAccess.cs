using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    interface IOrderItemsDataAccess
    {
        List<OrderItems> GetOrderItemsList();

        OrderItems GetOrderItems(int id);

        bool AddOrderItems(OrderItems oredrItem);

        bool UPdateOrderItems(OrderItems orderItem);

        bool DeleteOrderItem(int id);
    }
}
