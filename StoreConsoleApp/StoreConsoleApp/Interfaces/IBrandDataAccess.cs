using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreConsoleApp.Interfaces
{
    public interface IBrandDataAccess
    {
        List<Brand> GetBrandList();

        Brand GetBrand(int id);

        bool AddBrand(Brand item);

        bool UpdateBrand(Brand item);

        bool DeleteBrand(int id);

    }
}
