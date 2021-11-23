using StoreConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StoreConsoleApp.DataAccess
{
    public class BrandsDataAccess : IBrandsDataAccess
    {
        SqlConnection connection;
        public BrandsDataAccess()
        {
            connection = new SqlConnection("Data Source=.;Initial Catalog=BikeStores;Integrated Security=True");
        }
        public bool Add(Brand item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Brand Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetList()
        {
            throw new NotImplementedException();
        }

        public bool Update(Brand item)
        {
            throw new NotImplementedException();
        }
    }
}
