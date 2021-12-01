using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    public class OrderItemDataAccess : IOrderItemDataAccess
    {
        SqlConnection connection;

        public OrderItemDataAccess()
        {
            connection=new SqlConnection(" Data Source = . ;" +
                "Initial Catalog =BikeStores ; " +
                "Integrated Security=True");
        }

        public bool AddOrderItem(OrderItem orderItem)
        {
            string sqlstm = $@"INSERT INTO 
sales.order_items
                (
                item_id,
                order_id,
                product_id,
                quantity,
                list_price,
                discount
                )

                VALUES
                (
                @itemId,
@orderId,
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
            //orderItem.OrderId = Convert.ToInt32(command.ExecuteScalar());
            //orderItem.ItemId = Convert.ToInt32(command.ExecuteScalar());
            //close connnection
            connection.Close();

            return orderItem.ItemId > 0;


        }

        public bool DeleteOrderItem(int id)
        {
            string sqlstm = @"DELETE 
                             FROM sales.order_items
                             WHERE item_id=" + id;

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
            return id > 0;

        }

        public OrderItem GetOrderItem(int id)
        {
            string sqlstm = @"SELECT 
                
item_id,                
order_id,
                product_id,
                quantity,
                list_price,
                discount
                
                FROM sales.order_items 
                WHERE item_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            OrderItem orderItem = null;
            while (reader.Read())
            {
                orderItem = new OrderItem()
                {
                    ItemId = Convert.ToInt32(reader["item_id"]),
                    OrderId = Convert.ToInt32(reader["order_id"]),
                    
                    ProductId = Convert.ToInt32(reader["product_id"]),
                    Quantity = Convert.ToInt32(reader["quantity"]),
                    ListPrice = Convert.ToInt32(reader["list_price"]),
                    Discount = Convert.ToInt32(reader["discount"])
                };
            }

            connection.Close();
            return orderItem;
        }

        public List<OrderItem> GetOrderItemList()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText= @"SELECT 
                
                order_id,
                item_id,
                product_id,
                quantity,
                list_price,
                discount
                
                FROM sales.order_items 
                ";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            List<OrderItem> orderItems = new List<OrderItem>();

            while (reader.Read())
            {
                orderItems.Add(new OrderItem()
                {
                    OrderId = Convert.ToInt32(reader["order_id"]),
                    ItemId = Convert.ToInt32(reader["item_id"]),
                    ProductId = Convert.ToInt32(reader["product_id"]),
                    Quantity = Convert.ToInt32(reader["quantity"]),
                    ListPrice = Convert.ToInt32(reader["list_price"]),
                    Discount = Convert.ToInt32(reader["discount"])
                });
          
            }
            connection.Close();
            return orderItems;
        }

        public bool UPdateOrderItem(OrderItem orderItem)
        {
            string sqlstm = @"
               update sales.order_items
               set discount=@Discount
             where item_id =@ItemId";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            command.Parameters.AddWithValue("@Discount", orderItem.Discount);
            command.Parameters.AddWithValue("@ItemId", orderItem.ItemId);
            connection.Open();
            int effectedRows = command.ExecuteNonQuery();
            //brand.BrandName = Convert.ToString(command.ExecuteNonQuery());
            connection.Close();
            return effectedRows > 0;
        }
    }
}
