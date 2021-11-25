using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    class StocksDataAccess : IStockDataAccess
    {
        SqlConnection connection;
        public StocksDataAccess()
        {
            connection = new SqlConnection("Data Source = .;" +
                "Initial Catalog=BikeStores;" +
                "Integrated Security=True");
        }
        public bool AddStock(Stocks stock)
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

        public Stocks GetStock(int id)
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

            Stocks stock = null;
            while (reader.Read())
            {
                stock = new Stocks()
                {
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    ProductId = Convert.ToInt32(reader["product_id"]),
                    Quantity = Convert.ToInt32(reader["quantity"])
                };
            }
            reader.Close();
            return stock;

        }

        public List<Stocks> GetStocksList()
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

            List<Stocks> stocks = new List<Stocks>();
            while (reader.Read())
            {
                stocks.Add(  new Stocks()
                {
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    ProductId = Convert.ToInt32(reader["product_id"]),
                    Quantity = Convert.ToInt32(reader["quantity"])
                });
            }
            reader.Close();
            return stocks;
        }

        public bool UpdateStock(Stocks stock)
        {
            throw new NotImplementedException();
        }
    }
}
