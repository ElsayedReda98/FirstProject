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
                

                Quantity = 500
            };

            bool result=stockDataAccess.AddStock(newStock);

            Assert.True(result);
        }
    }
}
