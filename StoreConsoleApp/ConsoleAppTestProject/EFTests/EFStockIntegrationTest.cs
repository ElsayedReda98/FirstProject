using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleAppTestProject
{
    public class EFStockIntegrationTest
    {
        [Fact]
        public void Add_Stock_Will_Return_True()
        {
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

            var newStock = new Stock()
            {
                
               StoreId = 4,
               ProductId = 5,
                Quantity = 500
            };

            bool result = stockDataAccess.AddStock(newStock);

            Assert.True(result);
        }
        [Fact]
        public void Get_Stock_With_Valid_Id_Will_Return_True()
        {
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

            var stock = new Stock()
            {

                StoreId = 5,
                ProductId = 5,
                Quantity = 500
            };

            var result = stockDataAccess.AddStock(stock);

            Assert.True(result);
            Assert.NotEqual(0,stock.StoreId);
            int storeId = stock.StoreId, productId = stock.ProductId;

            stock=stockDataAccess.GetStock(storeId,productId);

            Assert.NotNull(stock);
            Assert.Equal(storeId,stock.StoreId);
            Assert.Equal(productId,stock.ProductId);
        }
        [Fact]
        public void Get_Stock_With_Invalid_Id_Will_Null()
        {
            IStockDataAccess stockDataAccess = new EFStockDataAccess();
            int storeId = -1 , productId =  -1 ;
            
            var stock = stockDataAccess.GetStock(storeId,productId);

            Assert.Null(stock);
        }
        [Fact]
        public void Get_StockList_Will_Return_Collection()
        {
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

           

            var stock = stockDataAccess.GetStocksList();

            Assert.NotNull(stock);
        }
        [Fact]
        public void Update_Stock_Will_Return_True()
        {
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

            var stock = stockDataAccess.GetStock(1,2);


            var result = stockDataAccess.UpdateStock(stock);

            Assert.True(result);
        }
        [Fact]
        public void Delete_Stock_Will_Return_True()
        {
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

            var stock = new Stock()
            {
                StoreId = 4,
                ProductId = 6,

                Quantity = 500
            };

            var result = stockDataAccess.AddStock(stock);

            Assert.True(result);
            Assert.NotEqual(0,stock.StoreId);
            Assert.NotEqual(0,stock.ProductId);

            result = stockDataAccess.DeleteStock(stock.StoreId,stock.ProductId);

            Assert.True(result);

        }
    }
}
