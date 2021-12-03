using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    public interface IProductDataAccess
    {
        List<Product> GetProductsList();

        Product GetProduct(int id);

        bool AddProduct(Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int id);
    }
}
