using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //one to many rshp between Categories & Products
        //category is one & products is many

        public ICollection<Product> Products { get; set; }


    }
}
