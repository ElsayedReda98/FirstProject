using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IProductDataAccess
    {
        List<Product> GetProductList();

        Product GetProduct(int id);
        
        bool AddProduct(Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int id);
    }
}
