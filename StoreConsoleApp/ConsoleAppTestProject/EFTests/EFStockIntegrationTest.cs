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
         private Product Add_Product()
        {
            IProductDataAccess productDataAccess = new EFProductDataAccess();

            var newProduct = new Product
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
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

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
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

            var product = Add_Product();

            var newStock = new Stock()
            {

                StoreId = 5,
                ProductId = product.ProductId,
                Quantity = 500
            };

            var result = stockDataAccess.AddStock(newStock);

            Assert.True(result);

            //Assert.NotEqual(0,newStock.StoreId);
            //Assert.NotEqual(0, product.ProductId);
            int storeId = newStock.StoreId; 
            int productId = product.ProductId;

            //act
            //why order is important??
            newStock = stockDataAccess.GetStock(productId,storeId);

            Assert.NotNull(newStock);
            Assert.Equal(storeId,newStock.StoreId);
            Assert.Equal(productId,product.ProductId);
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
            //Arrange
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

           
            //Act
            var stocks = stockDataAccess.GetStocksList();


            //Assert
            Assert.NotEmpty(stocks);


        }
        [Fact]
        public void Update_Stock_Will_Return_True()
        {
            //Arrange
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

            var stock = stockDataAccess.GetStock(1,2);

            //Act
            var result = stockDataAccess.UpdateStock(stock);

            //Assert
            Assert.True(result);

        }
        [Fact]
        public void Delete_Stock_Will_Return_True()
        {
            //Arrange
            IStockDataAccess stockDataAccess = new EFStockDataAccess();

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

            // Ordering is
            // important why??
            result = stockDataAccess.DeleteStock(product.ProductId,newStock.StoreId);

            Assert.True(result);

        }
    }
}
