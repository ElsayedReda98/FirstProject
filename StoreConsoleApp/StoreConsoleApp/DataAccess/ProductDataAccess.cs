using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    public class ProductDataAccess :IProductDataAccess

    {
        SqlConnection connection;
        public ProductDataAccess()
        {
            connection = new SqlConnection(" Data Source = . ;" +
                "Initial Catalog =BikeStores ; " +
                "Integrated Security=True");
        }

        public bool AddProduct(Product product)
        {
            string sqlstm = @"INSERT INTO production.produtcs
                    (

product_name,
brand_id,
category_id,
model_year,
list_price
)
OUTPUT Inserted.product_id
VALUES 
(
@ProductName
@BrandId
@CategoryId,
@ModelYear
@ListPrice
 )";
            var command = connection.CreateCommand();
            command.CommandText = sqlstm;
            
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@BrandId", product.BrandId);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@ModeYear", product.ModelYear);
            command.Parameters.AddWithValue("@ListPrice", product.ListPrice);

            connection.Open();
            product.ProductId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return product.ProductId > 0;

        }
        //public bool AddBrand_Bad(Brands brand)
        //{
        //    // Bad Implementation
        //    string sqlstm = @"INSERT INTO production.brands
        //            (
        //            barnd_id,
        //            brand_name
        //            )
        //            OUTPUT Inserted.barnd_id
        //            VALUES 
        //            ('{brand.BrandId}',
        //             '{brand.BrandName}'
        //             )";
        //    var command = connection.CreateCommand();
        //    command.CommandText = sqlstm;
        //    connection.Open();
        //    brand.BrandId = Convert.ToInt32(command.ExecuteScalar());
        //    connection.Close();

        //    return brand.BrandId > 0;

        //}

        public bool DeleteProduct(int id)
        {
            string sqlstm = @"DELETE 
                             FROM production.products
                             WHERE product_id=" + id;

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
            return id > 0;

        }

        public Product GetProduct(int id)
        {
            string sqlstm = @"SELECT 
product_id,
product_name,
brand_id,
category_id,
model_year,
list_price
                FROM production.products
               ";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            Product product = null;
            while (reader.Read())
            {
                product = new Product()
                {
                    ProductId  = Convert.ToInt32(reader["product_id"]),
                    ProductName = Convert.ToString(reader["product_name"]),
                    BrandId = Convert.ToInt32(reader["product_id"]),
                    CategoryId = Convert.ToInt32(reader["product_id"]),
                    ModelYear = Convert.ToInt32(reader["product_id"]),
                    ListPrice = Convert.ToInt32(reader["product_id"]),

                };
            }

            connection.Close();
            return product;
        }

        public List<Product> GetProductsList()
        {
            string sqlstm = @"SELECT 
product_id,
product_name,
brand_id,
category_id,
model_year,
list_price
                FROM production.products
               ";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductId = Convert.ToInt32(reader["product_id"]),
                    ProductName = Convert.ToString(reader["product_name"]),
                    BrandId = Convert.ToInt32(reader["product_id"]),
                    CategoryId = Convert.ToInt32(reader["product_id"]),
                    ModelYear = Convert.ToInt32(reader["product_id"]),
                    ListPrice = Convert.ToInt32(reader["product_id"]),
                    
                });
            }

            connection.Close();
            return products;
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

