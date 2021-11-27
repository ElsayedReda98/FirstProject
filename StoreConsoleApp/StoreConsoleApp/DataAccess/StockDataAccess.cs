using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    public class StockDataAccess : IStockDataAccess
    {
        SqlConnection connection;
        public StockDataAccess()
        {
            connection = new SqlConnection("Data Source = .;" +
                "Initial Catalog=BikeStores;" +
                "Integrated Security=True");
        }
        public bool AddStock(Stock stock)
        {
            string sqlstm = @"INSERT INTO production.stocks
(
store_id,
product_id,
quantity
)
VALUES
(@StoreId,
@ProductId,
@Quantity)";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            command.Parameters.AddWithValue("@StoreId", stock.StoreId);
            command.Parameters.AddWithValue("@ProductId", stock.ProductId);
            command.Parameters.AddWithValue("@Quantity ", stock.Quantity);
            
            connection.Open();
            stock.StoreId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return stock.StoreId > 0;

        }

        public bool DeleteStock(int id)
        {
            throw new NotImplementedException();
        }

        public Stock GetStock(int id)
        {

            string sqlstm = @"SELECT 
store_id,
product_id,
quantity
FRPM production.stocks
WHERE store_id=" + id;

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            Stock stock = null;
            while (reader.Read())
            {
                stock = new Stock()
                {
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    ProductId = Convert.ToInt32(reader["product_id"]),
                    Quantity = Convert.ToInt32(reader["quantity"])
                };
            }
            reader.Close();
            return stock;

        }

        public List<Stock> GetStocksList()
        {
            string sqlstm = @"SELECT 
store_id,
product_id,
quantity
FRPM production.stocks";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader
                (System.Data.CommandBehavior.CloseConnection);

            List<Stock> stocks = new List<Stock>();
            while (reader.Read())
            {
                stocks.Add(  new Stock()
                {
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    ProductId = Convert.ToInt32(reader["product_id"]),
                    Quantity = Convert.ToInt32(reader["quantity"])
                });
            }
            reader.Close();
            return stocks;
        }

        public bool UpdateStock(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
