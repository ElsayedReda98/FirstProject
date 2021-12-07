﻿using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1.DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        SqlConnection connection;
        public CustomerDataAccess()
        {
            connection = new SqlConnection("Data Source =.; Initial Catalog = BikeStores; Integrated Security = True");
        }
        public bool AddCustomer(Customer customer)
        {
            string sqlstmt = $@"INSERT INTO 
               sales.customers
               (first_name,
                last_name,
                phone,
                email,
                street,
                city,
                state,
                zip_code )
                OUTPUT Inserted.customer_id
                VALUES
                (@FirstName,
                @LastName,
                @Phone,
                @Email,
                @Street,
                @City,
                @State,
                @ZipCode )";

            var command = connection.CreateCommand();
            command.CommandText = sqlstmt;
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(customer.Phone) ? DBNull.Value : (object)customer.Phone);
            command.Parameters.AddWithValue("@Email", customer.Email);
            command.Parameters.AddWithValue("@Street", customer.Street);
            command.Parameters.AddWithValue("@City", customer.City);
            command.Parameters.AddWithValue("@State", customer.State);
            command.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
            connection.Open();
            customer.CustomerId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return customer.CustomerId > 0;
        } 
        public Customer GetCustomer(int customerId)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT
                customer_id,
                first_name,
                last_name,
                phone,
                email,
                street,
                city,
                state,
                zip_code
                FROM sales.customers
                WHERE customer_id=" + customerId;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            Customer customer = null;
            while (reader.Read())
            {
                customer = new Customer()
                {
                    City = Convert.ToString(reader["city"]),
                    Email = Convert.ToString(reader["email"]),
                    FirstName = Convert.ToString(reader["first_name"]),
                    CustomerId = Convert.ToInt32(reader["customer_id"]),
                    LastName = Convert.ToString(reader["last_name"]),
                    Phone = Convert.ToString(reader["phone"]),
                    State = Convert.ToString(reader["state"]),
                    Street = Convert.ToString(reader["street"]),
                    ZipCode = Convert.ToString(reader["zip_code"])
                };
            }
            connection.Close();
            return customer;
        }
        public List<Customer> GetCustomerList()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT 
                    customer_id,
                    first_name,
                    last_name,
                    phone,
                    email,
                    street,
                    city,
                    state,
                    zip_code 
            FROM sales.customers";

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            List<Customer> customers = new List<Customer>();
            while (reader.Read())
            {
                customers.Add(new Customer()
                {
                    City = Convert.ToString(reader["city"]),
                    Email = Convert.ToString(reader["email"]),
                    FirstName = Convert.ToString(reader["first_name"]),
                    CustomerId = Convert.ToInt32(reader["customer_id"]),
                    LastName = Convert.ToString(reader["last_name"]),
                    Phone = Convert.ToString(reader["phone"]),
                    State = Convert.ToString(reader["state"]),
                    Street = Convert.ToString(reader["street"]),
                    ZipCode = Convert.ToString(reader["zip_code"]),
                });
            }
            connection.Close();
            return customers;
        }

        public bool UpdateCustomer(Customer customer)
        {
            string sqlstm = @$"update sales.customers
                            set first_name =@FirstName,
                                last_name = @LastName
                            where customer_id =@CustomerId";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            command.Parameters.AddWithValue("@FirstName", customer.FirstName);
            command.Parameters.AddWithValue("@LastName", customer.LastName);
            command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            connection.Open();
            int effectedRows = command.ExecuteNonQuery();
            connection.Close();
            return effectedRows > 0;
        }
        public bool DeleteCustomer(int customerId)
        {
            string sqlstm = @$"DELETE 
                             FROM sales.customers
                             WHERE customer_id= {customerId}";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            int effectedRows = command.ExecuteNonQuery();
            connection.Close();
            return effectedRows > 0;
        }
    }
}
