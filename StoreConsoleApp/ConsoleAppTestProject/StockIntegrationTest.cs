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

            var newStock = new Stock()
            {
                
                StoreId = 1,
                ProductId = 1,
                Quantity = 500
            };

            bool result = stockDataAccess.AddStock(newStock);

            Assert.True(result);
        }
        [Fact]
        public void Get_Stock_With()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();

            var stock = new Stock()
            {

                StoreId = 1,
                ProductId = 1,
                Quantity = 500
            };

            var result = stockDataAccess.AddStock(stock);

            Assert.True(result);
            Assert.NotEqual(0,stock.StoreId);
            int id = stock.StoreId;

            stock=stockDataAccess.GetStock(id);

            Assert.NotNull(stock);
            Assert.Equal(id,stock.StoreId);
        }
        [Fact]
        public void Get_Stock_With_Invalid()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();
            int id = -1;
            
            var stock = stockDataAccess.GetStock(id);

            Assert.Null(stock);
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

            var stock = stockDataAccess.GetStock(1);


            var result = stockDataAccess.UpdateStock(stock);

            Assert.True(result);
        }
        [Fact]
        public void Delete_Stock_Will()
        {
            IStockDataAccess stockDataAccess = new StockDataAccess();

            var stock = new Stock()
            {
                //StoreId = 1,
                //ProductId = 1,

                Quantity = 500
            };

            var result = stockDataAccess.AddStock(stock);

            Assert.True(result);
            Assert.NotEqual(0,stock.StoreId);
            Assert.NotEqual(0,stock.ProductId);

            result = stockDataAccess.DeleteStock(stock.StoreId);

            Assert.True(result);

        }
    }
}
