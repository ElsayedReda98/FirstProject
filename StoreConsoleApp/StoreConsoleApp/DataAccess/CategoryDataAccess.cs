﻿
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1.DataAccess
{
    public class CategoryDataAccess : ICategoryDataAccess
    {
        SqlConnection connection;
        public CategoryDataAccess()
        {
            connection = new SqlConnection("Data Source= . ;" +
                "Initial Catalog=BikeStores;" +
                "Integrated Security=True");
        }
        public bool AddCategory(Category category)
        {
            string sqlstm = $@"INSERT INTO production.categories
                (
                
                category_name
                )
                OUTPUT Inserted.category_id
                VALUES 
                (
                @CategoryName)";

            var command = connection.CreateCommand();
            command.CommandText = sqlstm;
            command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);

            connection.Open();
            category.CategoryId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return category.CategoryId > 0;

        }

        public bool DeleteCategory(int id)
        {
            string sqlstm = @"DELETE 
FROM production.categories
WHERE category_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return id > 0;
        }

        public Category GetCategory(int id)
        {
            string sqlstm = @"SELECT 
                category_id,
                category_name
                FROM production.categories
                WHERE category_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            Category category = null;
            while (reader.Read())
            {
                category = new Category()
                {
                    CategoryId = Convert.ToInt32(reader["category_id"]),
                    CategoryName = Convert.ToString(reader["category_name"])
                };
            }
            connection.Close();
            return category;
        }

        public List<Category> GetCategoryList()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT 
                category_id,
                category_name
                FROM production.categories";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                categories.Add(new Category()
                {
                    CategoryId = Convert.ToInt32(reader["category_id"]),
                    CategoryName = Convert.ToString(reader["category_name"])
                });
            }
            connection.Close();
            return categories;
        }

        public bool UpdateCategory(Category category)
        {
            string sqlstm = @"
                update production.categories
               set category_name=@CategoryName
             where category_id=@CategoryId";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
            connection.Open();
            int effectedRows = command.ExecuteNonQuery();

            connection.Close();
            return effectedRows > 0;
        }
    }
}
