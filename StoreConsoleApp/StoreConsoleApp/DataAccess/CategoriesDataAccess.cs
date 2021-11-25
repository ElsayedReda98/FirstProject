
using ConsoleApp1.Interfaces; 
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    class CategoriesDataAccess : ICategoryDataAccess
    {
        SqlConnection connection;
        public CategoriesDataAccess()
        {
            connection = new SqlConnection("Data Source= . ;" +
                "Initial Catalog=BikeStores;" +
                "Integrated Security=True");
        }
        public bool AddCategory(Categories category)
        {
            string sqlstm = $@"INSERT INTO production.categories
                (
                category_id,
                category_name
                )
                OUTPUT Inserted.category_id
                VALUES 
                (@CategoryId,
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
            throw new NotImplementedException();
        }

        public Categories GetCategory(int id)
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

            Categories category = null;
            while (reader.Read())
            {
                category = new Categories()
                {
                    CategoryId = Convert.ToInt32(reader["category_id"]),
                    CategoryName = Convert.ToString(reader["category_name"])
                };
            }
            reader.Close();
            return category;
        }

        public List<Categories> GetCategoryList()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT 
                category_id,
                category_name
                FROM production.categories";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            List<Categories> categories = new List<Categories>();
            while (reader.Read())
            {
                categories.Add(new Categories()
                {
                    CategoryId=Convert.ToInt32(reader["category_id"]),
                    CategoryName=Convert.ToString(reader["category_name"])
                });
            }
            reader.Close();
            return categories;
        }

        public bool UpdateCategory(Categories category)
        {
            throw new NotImplementedException();
        }
    }
}
