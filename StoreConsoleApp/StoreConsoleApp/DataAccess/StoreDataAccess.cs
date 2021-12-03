
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1.DataAccess
{
    public class StoreDataAccess : IStoreDataAccess
    {
        SqlConnection connection;
        public StoreDataAccess()
        {
            connection = new SqlConnection("Data Source =.; Initial Catalog = BikeStores; Integrated Security = True");
        }
        public bool AddStore(Store store)
        {
            string sqlstmt = @"INSERT INTO sales.stores 
             (  store_name,
                phone,
                email,
                street,
                city,
                state,
                zip_code )
                OUTPUT Inserted.store_id
                VALUES
              ( @StoreName,
                @Phone,
                @Email,
                @Street,
                @City,
                @State,
                @ZipCode )";
            var command = connection.CreateCommand();
            command.CommandText = sqlstmt;

            command.Parameters.AddWithValue("@StoreName", store.StoreName);
            command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(store.Phone) ? DBNull.Value : (object)store.Phone);
            command.Parameters.AddWithValue("@Email", store.Email);
            command.Parameters.AddWithValue("@Street", store.Street);
            command.Parameters.AddWithValue("@City", store.City);
            command.Parameters.AddWithValue("@State", store.State);
            command.Parameters.AddWithValue("@ZipCode", store.ZipCode);
            connection.Open();
            store.StoreId=Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return store.StoreId > 0;
        }
        public Store GetStore(int id)
        {
            string sqlstm = @"SELECT
                        store_id,                
                        store_name,
                        phone,
                        email,
                        street,
                        city,
                        state,
                        zip_code
                   FROM sales.stores
                   WHERE store_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            Store store = null;
            while (reader.Read())
            {
                store = new Store()
                {
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    StoreName = Convert.ToString(reader["store_name"]),
                    Phone = Convert.ToString(reader["phone"]),
                    Email = Convert.ToString(reader["email"]),
                    Street = Convert.ToString(reader["street"]),
                    City = Convert.ToString(reader["city"]),
                    State = Convert.ToString(reader["state"]),
                    ZipCode = Convert.ToString(reader["zip_code"])
                };
            }
            connection.Close();
            return store;
        }
        public List<Store> GetStoresList()
        {
            string sqlstm = @"SELECT 
                    store_id,
                    store_name,
                    phone,
                    email,
                    street,
                    city,
                    state,
                    zip_code 
               FROM sales.stores";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            List<Store> stores = new List<Store>();
            while (reader.Read())
            {
                stores.Add(new Store()
                {
                    City = Convert.ToString(reader["city"]),
                    Email = Convert.ToString(reader["email"]),
                    StoreName = Convert.ToString(reader["store_name"]),
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    Phone = Convert.ToString(reader["phone"]),
                    State = Convert.ToString(reader["state"]),
                    Street = Convert.ToString(reader["street"]),
                    ZipCode = Convert.ToString(reader["zip_code"]),
                });
            }
            connection.Close();
            return stores;
        }
        public bool UpdateStore(Store store)
        {
            string sqlstm = @"
                UPDATE sales.stores
                SET store_name=@StoreName
                WHERE store_id=@StoreId";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            command.Parameters.AddWithValue("@StoreName", store.StoreName);
            command.Parameters.AddWithValue("@StoreId", store.StoreId);
            connection.Open();
            int effectedRows = command.ExecuteNonQuery();
            return effectedRows > 0;
        }
        public bool DeleteStore(int id)
        {
            string sqlstm = @"DELETE 
                    FROM  sales.stores
                    WHERE store_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            int effectedRows=command.ExecuteNonQuery();
            connection.Close();
            return effectedRows > 0;
        }
    }
}
