using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    interface IProductDataAccess
    {
        List<Products> GetProductsList();

        Products GetProduct(int id);
        
        bool AddProduct(Products product);

        bool UpdateProduct(Products product);

        bool DeleteProduct(int id);
    }
}
