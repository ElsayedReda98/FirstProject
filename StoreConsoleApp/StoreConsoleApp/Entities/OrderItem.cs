using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderItem
    {
        
       
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }

        /* one to many rshp between orders & orderitem
           orders is one & orderitem is many */
        
        public int OrderId { get; set; }
        public Order Order { get; set; }

        /* one to many rshp between to Products & ordreitems
           product is one
           orderitems is many */
        public int ProductId { get; set; }
        public Product Product { get; set; }

       
        
    }
}
