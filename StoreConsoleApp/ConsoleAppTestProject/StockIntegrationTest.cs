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
        [Fact]
        public void Add_Stock_Will()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();
            var product =  AddProduct();

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
        public void Get_Stock_With()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();
            var product = AddProduct();

            var newStock = new Stock()
            {
                StoreId = 4,
                ProductId = product.ProductId,
                Quantity = 500
            };

            stockDataAccess.AddStock(newStock);

            var stock =stockDataAccess.GetStock(newStock.StoreId, newStock.ProductId);

            Assert.NotNull(stock);            
        }
        
        [Fact]
        public void Get_StockList_Will()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();

           

            var stock = stockDataAccess.GetStocksList();

            Assert.NotNull(stock);
        }
        [Fact]
        public void Update_Stock_Will()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();
            var product = AddProduct();
            var newStock = new Stock()
            {
                StoreId = 4,
                ProductId = product.ProductId,
                Quantity = 500
            };

            stockDataAccess.AddStock(newStock);

            //Act
            newStock.Quantity = 300;
            var result = stockDataAccess.UpdateStock(newStock);

            Assert.True(result);
        }
        [Fact]
        public void Delete_Stock_Will()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();
            var product = AddProduct();

            var stock = new Stock()
            {
                StoreId = 4,
                ProductId = product.ProductId,
                Quantity = 500
            };

            var result = stockDataAccess.AddStock(stock);

            Assert.True(result);
            Assert.NotEqual(0,stock.StoreId);
            Assert.NotEqual(0,stock.ProductId);

            result = stockDataAccess.DeleteStock(stock.StoreId, stock.ProductId);

            Assert.True(result);

        }

        private  Product AddProduct()
        {
            IProductDataAccess productDataAccess = new ProductDataAccess();
            var newProduct = new Product()
            {
                ProductName = "sayed",
                BrandId = 7,
                CategoryId = 7,
                ModelYear = 2021,
                ListPrice = 1300
            };

            productDataAccess.AddProduct(newProduct);
            return newProduct;
        }

    }
}
