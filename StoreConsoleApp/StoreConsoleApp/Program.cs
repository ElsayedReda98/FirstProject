﻿using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using StoreConsoleApp.Interfaces;
using System;

namespace StoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //TestBrands();
            //TestCategory();
            //TestStock();
            //TestStore();
            //TestOrder();
        }
        private static void TestOrderItem()
        {

        }
        private static void TestOrder()
        {
            Console.WriteLine("=========================Test Order ===============");
            IOrderDataAccess orderDataAccess = new OrderDataAccess();

            var neworder = new Order()
            {

                CustomerId = 100,
                OrderDate = DateTime.Now,
                OrderStatus = 1,
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                StaffId = 1,
                StoreId = 1
            };
            bool result = orderDataAccess.AddOrder(neworder);
            Console.WriteLine($"Add order Return: {result}");
            Console.WriteLine("");

            Console.WriteLine("****** Get order *****");
            // ERROR
            var order = orderDataAccess.GetOrder(100);
            Console.WriteLine($"Get Order with id:{order.CustomerId}");
            Console.WriteLine("");

            var orderList = orderDataAccess.GetOrdersList();
            Console.WriteLine($"Get Order list with {orderList.Count} Items");
            Console.WriteLine("");

            //bool deleteOrder = orderDataAccess.DeleteOrder(8);
            //Console.WriteLine($"Delete  Order Return: {deleteOrder}");

        }
        private static void TestStore()
        {
            Console.WriteLine("=========================Test Store ===============");
            IStoreDataAccess storeDataAccess = new StoreDataAccess();

            var newStore = new Store()
            {

                StoreName = "ali",
                Phone = "5040",
                Email = "ali.com",
                State = "s",
                Street = "101ali",
                City = "york",
                ZipCode = "050"

            };
            bool result = storeDataAccess.AddStore(newStore);
            Console.WriteLine($"Add Store Return: {result}");
            Console.WriteLine("");

            Console.WriteLine("****** Get Store *****");
            // ERROR
            var store = storeDataAccess.GetStore(5);
            Console.WriteLine($"Get store with id:{store.StoreId}");
            Console.WriteLine("");

            var storeList = storeDataAccess.GetStoresList();
            Console.WriteLine($"Get store list with {storeList.Count} Items");
            Console.WriteLine("");

            //bool deleteStore = storeDataAccess.DeleteStore(8);
            //Console.WriteLine($"Delete  Store Return: {deleteStore}");

        }
        private static void TestStock()
        {
            Console.WriteLine("=========================Test Stock ===============");
            IStockDataAccess stockDataAccess = new StockDataAccess();

            var newStock = new Stock()
            {
                Quantity = 200,
            };
            //bool result = stockDataAccess.AddStock(newStock);
            //Console.WriteLine($"Add Stock Return: {result}");
            Console.WriteLine("");

            Console.WriteLine("****** Get Category *****");
            // ERROR
            //var stock = stockDataAccess.GetStock(5);
            //Console.WriteLine($"Get stock with quantity:{stock.Quantity}");
            //Console.WriteLine("");

            var stockllist = stockDataAccess.GetStocksList();
            Console.WriteLine($"Get stock list with {stockllist.Count} Items");
            Console.WriteLine("");

            //bool deleteStock = stockDataAccess.DeleteStock(8);
            //Console.WriteLine($"Delete  Stock Return: {deleteStock}");

        }
        private static void TestCategory()
        {
            Console.WriteLine("================== Test Category ===========================");
            ICategoryDataAccess categoryDataAccess = new CategoryDataAccess();

            var newCategory = new Category()
            {
                CategoryName = "category to add11"
            };
            Console.WriteLine("****** Test Add Category *****");
            //bool result = categoryDataAccess.AddCategory(newCategory);
            //Console.WriteLine($"Add Category Return: {result}");
            Console.WriteLine("");

            Console.WriteLine("****** Get Category *****");
            //var category = categoryDataAccess.GetCategory(1);
            //Console.WriteLine($"Get Category with name:{category.CategoryName}");
            Console.WriteLine("");

            var categoryList = categoryDataAccess.GetCategoryList();
            //Console.WriteLine($"Get category list with {categoryList.Count} Items");
            //Console.WriteLine("");

            //bool deletecategory = categoryDataAccess.DeleteCategory(12);
            //Console.WriteLine($"Delete Category Return: {deletecategory}");
            var updateCat = new Category()
            {
                CategoryName = "ahmed",
                CategoryId = 11
            };
            Console.WriteLine("****** Test update Category *****");
            bool result2 = categoryDataAccess.UpdateCategory(updateCat);
            Console.WriteLine($"update Category Return: {result2}");
            Console.WriteLine("");


        }
        private static void TestBrands()
        {
            Console.WriteLine("================== Test Brands ===========================");
            IBrandDataAccess brandDataAccess = new BrandDataAccess();

            var newBrand = new Brand()
            {
                BrandName = "brand adding "
            };

            Console.WriteLine("****** Test Add Brand *****");
            bool result = brandDataAccess.AddBrand(newBrand);
            Console.WriteLine($"Add Brand Return: {result}");

            Console.WriteLine("****** Get Brand *****");
            var brand = brandDataAccess.GetBrand(35);
            Console.WriteLine($"Get Brand with name:{brand.BrandName}");

            var brandList = brandDataAccess.GetBrandList();
            Console.WriteLine($"Get Brand list with {brandList.Count} Items");

            //bool delBrand=brandDataAccess.DeleteBrand(5);
            //Console.WriteLine($"Delete Brand Return: {delBrand}");

            var updateBrand = new Brand()
            {
                BrandName = "updated brand",
                BrandId = 1
            };
            bool upBrand = brandDataAccess.UpdateBrand(updateBrand);
            Console.WriteLine($"update Brand Return: {upBrand}");


        }
    }
}
