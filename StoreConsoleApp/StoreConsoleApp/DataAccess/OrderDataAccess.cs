using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess 
{
    public class OrderDataAccess : IOrderDataAccess
    {
        SqlConnection connection;
        public OrderDataAccess()
        {
            connection=new SqlConnection("Data Source=.;" +
                "Initial Catalog=BikeStores;" +
                "Integrated Security=True");
        }
        
        public bool AddOrder(Order order)
        {
            string sqlstm = $@"INSERT INTO sales.orders
(
customer_id,
order_status,
order_date,
required_date,
shipped_date,
store_id,
staff_id
)
OUTPUT Inserted.order_id
VALUES
(
@CustomerId,
@OrderStatus,
@OrderDate,
@RequiredDate,
@ShippedDate,
@StoreId,
@StaffId)";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
           // command.Parameters.AddWithValue("@OrderId", order.OredrId);
            command.Parameters.AddWithValue("@customerId", order.CustomerId);
            command.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
            command.Parameters.AddWithValue("@OrdeDate", order.OrderDate);
            command.Parameters.AddWithValue("@RequiredDate", order.RequiredDate);
            command.Parameters.AddWithValue("@ShippedDate", order.ShippedDate);
            command.Parameters.AddWithValue("@StoreId", order.StoreId);
            command.Parameters.AddWithValue("@StaffId", order.StaffId);

            connection.Open();
            order.OredrId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return order.OredrId > 0;
        }

        public bool DeleteOrder(int id)
        {
            string sqlstm = @"DELETE 
                             FROM sales.orders
                             WHERE order_id=" + id;

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
            return id > 0;

        }

        public Order GetOrder(int id)
        {
            string sqlstm = @"SELECT 
order_id,
customer_id,
order_status,
order_date,
required_date,
shipped_date,
store_id,
staff_id
FROM sales.orders 
WHERE  order_id="+id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            Order order = null;
            while (reader.Read())
            {
                order = new Order()
                {
                    CustomerId = Convert.ToInt32(reader["customer_id"]),
                    OrderStatus = Convert.ToInt32(reader["order_status"]),
                    OrderDate=Convert.ToDateTime(reader["ordre_date"]),
                    RequiredDate=Convert.ToDateTime(reader["required_date"]),
                    ShippedDate=Convert.ToDateTime(reader["shipped_date"]),
                    StoreId=Convert.ToInt32(reader["store_id"]),
                    StaffId=Convert.ToInt32(reader["staff_id"])
                    
                };
            }
            connection.Close();
            return order;
        }

        public List<Order> GetOrdersList()
        {
            string sqlstm=  @"SELECT
 order_id,
 customer_id,
 order_status,
 order_date,
 required_date,
 shipped_date,
 store_id,
 staff_id
FROM sales.orders ";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                orders.Add(new Order()
                {
                    CustomerId = Convert.ToInt32(reader["customer_id"]),
                    OrderStatus = Convert.ToInt32(reader["order_status"]),
                    OrderDate = Convert.ToDateTime(reader["ordre_date"]),
                    RequiredDate = Convert.ToDateTime(reader["required_date"]),
                    ShippedDate = Convert.ToDateTime(reader["shipped_date"]),
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    StaffId = Convert.ToInt32(reader["staff_id"])
                });
            }
            connection.Close();
            return orders;
        }

        public bool UpdateOrder(int id)
        {
            string sqlstm = @"
                update sales.orders
               set order_status=0
             where order_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            command.ExecuteNonQuery();
            return id > 0;
        }
    }
}
