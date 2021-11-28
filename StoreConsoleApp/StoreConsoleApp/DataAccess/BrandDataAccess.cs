using ConsoleApp1.Interfaces;
using StoreConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1.DataAccess
{
    public class BrandDataAccess : IBrandDataAccess
    {
        SqlConnection connection;
        public BrandDataAccess()
        {
            connection = new SqlConnection(" Data Source = . ;" +
                "Initial Catalog =BikeStores ; " +
                "Integrated Security=True");
        }

        public bool AddBrand(Brand brand)
        {
            string sqlstm = @"INSERT INTO production.brands
                    (
                    brand_name
                    )
                    OUTPUT Inserted.brand_id
                    VALUES 
                    (@BrandName
                    )";
            var command = connection.CreateCommand();
            command.CommandText = sqlstm;
            command.Parameters.AddWithValue("@BrandName", brand.BrandName);

            connection.Open();
            brand.BrandId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return brand.BrandId > 0;

        }
        public bool AddBrand_Bad(Brand brand)
        {
            // Bad Implementation
            string sqlstm = @"INSERT INTO production.brands
                    (
                    barnd_id,
                    brand_name
                    )
                    OUTPUT Inserted.barnd_id
                    VALUES 
                    ('{brand.BrandId}',
                     '{brand.BrandName}'
                     )";
            var command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            brand.BrandId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return brand.BrandId > 0;

        }

        public bool DeleteBrand(int id)
        {
            string sqlstm = @"DELETE 
                             FROM production.brands
                             WHERE brand_id="+id;

            SqlCommand command= connection.CreateCommand();
            command.CommandText= sqlstm;
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
            return id > 0; 

        }

        public Brand GetBrand(int id)
        {
            string sqlstm = @"SELECT 
                brand_id,
                brand_name
                FROM production.brands
                WHERE brand_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            Brand brand = null;
            while (reader.Read())
            {
                brand = new Brand()
                {
                    BrandId = Convert.ToInt32(reader["brand_id"]),
                    BrandName = Convert.ToString(reader["brand_name"])
                };
            }

            connection.Close();
            return brand;
        }

        public List<Brand> GetBrandList()
        {
            string sqlstm = @"SELECT 
                brand_id,
                brand_name
                FROM production.brands";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            List<Brand> brands = new List<Brand>();
            while (reader.Read())
            {
                brands.Add(new Brand
                {
                    BrandId = Convert.ToInt32(reader["brand_id"]),
                    BrandName = Convert.ToString(reader["brand_name"])
                });
            }

            connection.Close();
            return brands;
        }


        //public bool UpdateBrand(Brand brand)
        //{
        //    string sqlstm = @"
        //        update production.brands
        //        set brand_name=''
        //        where brand_name=" + brand;
        //    SqlCommand command=connection.CreateCommand();
        //    command.CommandText=sqlstm;
        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    return brand.BrandId > 0;
        //}
        //public bool UpdateBrand(Brand brand)
        //{
        //    string sqlstm = @"
        //        update production.brands
        //       set brand_name='@{BrandName}'
        //     where brand_id=" + @brand.BrandId;
        //    SqlCommand command = connection.CreateCommand();
        //    command.CommandText = sqlstm;
        //    connection.Open();
        //    command.ExecuteNonQuery();
        //    return brand.BrandId > 0;
        //}
        public bool UpdateBrand(int id)
        {
            string sqlstm = @"
                update production.brands
               set brand_name='updated brand'
             where brand_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            command.ExecuteNonQuery();
            return id > 0;
        }
    }
}
