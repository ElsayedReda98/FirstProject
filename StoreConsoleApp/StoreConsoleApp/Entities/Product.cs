using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        
        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        // one to many relationship between Products and Brands
        //Products is many & Brands is one
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        // one to many relationship between Products and categories
        //Products is many & Categories is one
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        ////one to many rshp between to Product & ordreitems
        //Product is one
        //Orderitems is many
        public ICollection<OrderItem> orderItems { get; set; }

        //one to many rshp between to stocks & Products
        //stock is many
        //Products is one
        public ICollection<Stock> Stocks { get; set; }





    }
}
