using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Order
    {
        //public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        //public int StoreId { get; set; }
        //public int StaffId { get; set; }

        //one to many relationship between customer and orders
        //Orders is many and customer is one
        public int CustomerId { get; set; }
        


        //one to many relationship between satff and orders
        // Orders is many and staff is one
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        public Store Store { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
        //one to many relationship between stores and orders
        // Orders is many & store is one
        public int StoreId { get; set; }
       


        //one to many relationship between Ordre_items and orders
        //orders is one & orderitems is many
        

    }
}
