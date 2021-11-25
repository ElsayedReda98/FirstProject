using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    class OrderItemDataAccess : IOrderItemsDataAccess
    {
        SqlConnection connection;

        public OrderItemDataAccess()
        {
            connection=new SqlConnection(" Data Source = . ;" +
                "Initial Catalog =BikeStores ; " +
                "Integrated Security=True");
        }

        public bool AddOrderItems(OrderItems orderItem)
        {
            string sqlstm = @$"INSERT INTO sales.order_items
                (
                order_id,
                item_id,
                product_id,
                quantity,
                list_price,
                discount
                )
                OUTPUT Inserted.order_id,
                       Inserted.item_id
                VALUES
                (@OrderId,
                @ItemId,
                @ProductId,
                @Quantity,
                @ListPrice,
                @Discount
                )";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            command.Parameters.AddWithValue("@OrderId", orderItem.OrderId);
            command.Parameters.AddWithValue("@ItemId", orderItem.ItemId);
            command.Parameters.AddWithValue("@ProductId", orderItem.ProductId);
            command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
            command.Parameters.AddWithValue("@ListPrice", orderItem.ListPrice);
            command.Parameters.AddWithValue("@discount", orderItem.Discount);

            // open a connection
            connection.Open();
            orderItem.OrderId = Convert.ToInt32(command.ExecuteScalar());
            orderItem.ItemId = Convert.ToInt32(command.ExecuteScalar());

            //close connnection
            connection.Close();

            return orderItem.ItemId > 0;


        }

        public bool DeleteOrderItem(int id)
        {
            throw new NotImplementedException();
        }

        public OrderItems GetOrderItems(int id)
        {
            string sqlstm = @$"SELECT 
                (
                order_id,
                item_id,
                product_id,
                quantity,
                list_price,
                discount
                )
                FROM sales.order_items 
                WHERE item_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            OrderItems orderItem = null;
            while (reader.Read())
            {
                orderItem = new OrderItems()
                {
                    OrderId = Convert.ToInt32(reader["order_id"]),
                    ItemId = Convert.ToInt32(reader["item_id"]),
                    ProductId = Convert.ToInt32(reader["porduct_id"]),
                    Quantity = Convert.ToInt32(reader["quantity"]),
                    ListPrice = Convert.ToInt32(reader["list_price"]),
                    Discount = Convert.ToInt32(reader["discount"])
                };
            }

            reader.Close();
            return orderItem;
        }

        public List<OrderItems> GetOrderItemsList()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText= @$"SELECT 
                (
                order_id,
                item_id,
                product_id,
                quantity,
                list_price,
                discount
                )
                FROM sales.order_items 
                ";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            List<OrderItems> orderItems = new List<OrderItems>();

            while (reader.Read())
            {
                orderItems.Add(new OrderItems()
                {
                    OrderId = Convert.ToInt32(reader["order_id"]),
                    ItemId = Convert.ToInt32(reader["item_id"]),
                    ProductId = Convert.ToInt32(reader["porduct_id"]),
                    Quantity = Convert.ToInt32(reader["quantity"]),
                    ListPrice = Convert.ToInt32(reader["list_price"]),
                    Discount = Convert.ToInt32(reader["discount"])
                });
          
            }
            reader.Close();
            return orderItems;
        }

        public bool UPdateOrderItems(OrderItems orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
