using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleAppTestProject
{
    public class StockIntegrationTest
    {
        
        private Product Add_Product()
        {
            IProductDataAccess productDataAccess = new EFProductDataAccess();
            
            var newProduct = new Product()
            {
                ProductName = "sayed",
                BrandId = 7,
                CategoryId = 7,
                ModelYear = 2022,
                ListPrice = 1300
            };

            productDataAccess.AddProduct(newProduct);
            return newProduct;
        }

        [Fact]
        public void Add_Stock_Will_Return_True()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();
            
            var product = Add_Product();
            var newStock = new Stock()
            {

                StoreId = 4,
                ProductId = product.ProductId,
                Quantity = 500
            };

            bool result = stockDataAccess.AddStock(newStock);

            Assert.True(result);
        }
        [Fact]
        public void Get_Stock_With_Valid_Id_Will_Return_True()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();

            var product = Add_Product();

            var newStock = new Stock()
            {
                
                StoreId = 3 ,
                ProductId = product.ProductId,
                Quantity = 450
            };

            var result = stockDataAccess.AddStock(newStock);

            Assert.True(result);

            Assert.NotEqual(0, newStock.StoreId);
            Assert.NotEqual(0, product.ProductId);

            int storeId = newStock.StoreId;
            int productId =product.ProductId;

            //Act
            // Ordering is very important why??
            newStock = stockDataAccess.GetStock(storeId,productId);

            Assert.NotNull(newStock);
            Assert.Equal(storeId, newStock.StoreId);
            Assert.Equal(productId, product.ProductId);
        }
        [Fact]
        public void Get_Stock_With_Invalid_Id_Will_Null()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();
            int storeId = -1,productId = -1;

            var stock = stockDataAccess.GetStock(storeId,productId);

            Assert.Null(stock);
        }
        [Fact]
        public void Get_StockList_Will_Return_Collection()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();



            var stock = stockDataAccess.GetStocksList();

            Assert.NotEmpty(stock);
        }
        [Fact]
        public void Update_Stock_Will_Return_True()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();

            var stock = stockDataAccess.GetStock(2,4);


            var result = stockDataAccess.UpdateStock(stock);

            Assert.True(result);
        }
        [Fact]
        public void Delete_Stock_Will_Return_True()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();

            var product = Add_Product();

            var newStock = new Stock()
            {
                StoreId = 5,
                ProductId = product.ProductId,
                Quantity = 500
            };

            var result = stockDataAccess.AddStock(newStock);

            Assert.True(result);
            Assert.NotEqual(0, newStock.StoreId);
            Assert.NotEqual(0, product.ProductId);

            // Ordering is important why ??
            result = stockDataAccess.DeleteStock(newStock.StoreId,product.ProductId);

            Assert.True(result);

        }
    }
}
