using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        //one to many relationship between brand and products
        //brand is one and products is many
        public ICollection<Product> Products { get; set; }

    }
}
