using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace StoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TestBrands();
        }

        private static void TestBrands()
        {
            Console.WriteLine("================== Test Brands ===========================");
            IBrandDataAccess brandDataAccess = new BrandsDataAccess();

            var newBrand = new Brands()
            {
                BrandName = "Brand to add",
            };

            Console.WriteLine("****** Test Add Brand *****");
            bool result = brandDataAccess.AddBrand(newBrand);
            Console.WriteLine($"Add Brand Return: {result}");

            Console.WriteLine("****** Get Brand *****");
            var brand = brandDataAccess.GetBrand(1);
            Console.WriteLine($"Get Brand with name:{brand.BrandName}");

            var brandList = brandDataAccess.GetBrandList();
            Console.WriteLine($"Get Brand list with {brandList.Count} Items");
        }
    }
}
