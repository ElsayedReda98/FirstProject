using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1.DataAccess
{
    public class BrandsDataAccess : IBrandDataAccess
    {
        SqlConnection connection;
        public BrandsDataAccess()
        {
            connection = new SqlConnection(" Data Source = . ;" +
                "Initial Catalog =BikeStores ; " +
                "Integrated Security=True");
        }

        public bool AddBrand(Brands brand)
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
        public bool AddBrand_Bad(Brands brand)
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
            throw new NotImplementedException();
        }

        public Brands GetBrand(int id)
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

            Brands brand = null;
            while (reader.Read())
            {
                brand = new Brands()
                {
                    BrandId = Convert.ToInt32(reader["brand_id"]),
                    BrandName = Convert.ToString(reader["brand_name"])
                };
            }

            reader.Close();
            return brand;
        }

        public List<Brands> GetBrandList()
        {
            string sqlstm = @"SELECT 
                brand_id,
                brand_name
                FROM production.brands";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            List<Brands> brands = new List<Brands>();
            while (reader.Read())
            {
                brands.Add(new Brands
                {
                    BrandId = Convert.ToInt32(reader["brand_id"]),
                    BrandName = Convert.ToString(reader["brand_name"])
                });
            }

            reader.Close();
            return brands;
        }


        public bool UpdateBrand(Brands brand)
        {
            throw new NotImplementedException();
        }
    }
}
