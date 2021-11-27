
using ConsoleApp1.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    class StoreDataAccess : IStoreDataAccess
    {
        SqlConnection connection;
        public StoreDataAccess()
        {
            connection = new SqlConnection("Data Source =.; Initial Catalog = BikeStores; Integrated Security = True");

        }
        public bool AddStore(Stores store)
        {
            string sqlstmt = $@"INSERT INTO 
               sales.stores
                (
                store_id,
                store_name,
                phone,
                email,
                street,
                city,
                state,
                zip_code
                )
                OUTPUT Inserted.store_id
                VALUES
                (@FirstName,
                @LastName,
                @Phone,
                @Email,
                @Street,
                @City,
                @State,
                @ZipCode
                )";


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
            store.storeId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return store.storeId > 0;
        }

        public bool DeleteStore(int id)
        {
            throw new NotImplementedException();
        }

        public List<Stores> GetStoresList()
        {
            string sqlstm= @"SELECT 
                    customer_id,
                    first_name,
                    last_name,
                    phone,
                    email,
                    street,
                    city,
                    state,
                    zip_code FROM sales.stores"; 
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader
                (System.Data.CommandBehavior.CloseConnection);

            List<Stores> stores = new List<Stores>();
            while (reader.Read())
            {
                stores.Add(new Stores()
                {
                    City = Convert.ToString(reader["city"]),
                    Email = Convert.ToString(reader["email"]),
                    StoreName = Convert.ToString(reader["store_name"]),
                    storeId = Convert.ToInt32(reader["store_id"]),
                    Phone = Convert.ToString(reader["phone"]),
                    State = Convert.ToString(reader["state"]),
                    Street = Convert.ToString(reader["street"]),
                    ZipCode = Convert.ToString(reader["zip_code"]),
                });
            }
            reader.Close();
            return stores;
        }

        public bool UpdateStore(Stores store)
        {
            throw new NotImplementedException();
        }


        public Stores GetStore(int id)
        {
            string sqlstm = @"SELECT
                custome_id,
                first_name,
                last_name,
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

            Stores store = null;
            while (reader.Read())
            {
                store = new Stores()
                {
                    City = Convert.ToString(reader["city"]),
                    Email = Convert.ToString(reader["email"]),
                    StoreName = Convert.ToString(reader["store_name"]),
                    storeId = Convert.ToInt32(reader["store_id"]),
                    Phone = Convert.ToString(reader["phone"]),
                    State = Convert.ToString(reader["state"]),
                    Street = Convert.ToString(reader["street"]),
                    ZipCode = Convert.ToString(reader["zip_code"])
                };
            }
            reader.Close();
            return store;

        }
         
        
    }
}
