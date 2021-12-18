using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Stock
    {
        //public int StoreId { get; set; }
        //public int ProductId { get; set; }
        public int Quantity { get; set; }

        ////one to many rshp between to stores & stocks
        //
        public int StoreId { get; set; }
        public Store Store { get; set; }

        //one to many rshp between to stocks & Products
        //stock is many
        //Products is one
        public int ProductId { get; set; }
        public Product Product { get; set; }




    }
}
