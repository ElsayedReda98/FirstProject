using System;
using System.Collections.Generic;
using System.Text;

namespace StoreConsoleApp.Interfaces
{
    public interface IBrandsDataAccess
    {
        List<Brand> GetList();

        Brand Get(int id);

        bool Add(Brand item);

        bool Update(Brand item);

        bool Delete(int id);

    }
}
