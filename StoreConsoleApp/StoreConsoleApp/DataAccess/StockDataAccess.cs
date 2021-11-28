﻿using ConsoleApp1.Interfaces;
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
        // error
        public bool AddStock(Stock stock)
        {
            string sqlstm = @"INSERT INTO production.stocks
(

quantity
)
OUTPUT inserted.store_id
       
VALUES
(

@Quantity)";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
           
            command.Parameters.AddWithValue("@Quantity ", stock.Quantity);
            
            connection.Open();
            //stock.ProductId = Convert.ToInt32(command.ExecuteScalar());
            stock.StoreId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return stock.ProductId > 0;

        }

        public bool DeleteStock(int id)
        {
            string sqlstm = @"DELETE 
FROM production.stocks
WHERE product_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return id > 0;
        }

        public Stock GetStock(int id)
        {

            string sqlstm = @"SELECT 
store_id,
product_id,
quantity
FROM production.stocks
WHERE product_id=" + id;

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
            connection.Close();
            return stock;

        }

        public List<Stock> GetStocksList()
        {
            string sqlstm = @"SELECT 
store_id,
product_id,
quantity
FROM production.stocks";

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
            connection.Close();
            return stocks;
        }

        public bool UpdateStock(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}