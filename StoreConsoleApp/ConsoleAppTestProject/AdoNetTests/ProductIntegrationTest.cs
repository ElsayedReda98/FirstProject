using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleAppTestProject
{
    public class ProductIntegrationTest
    {
        [Fact]
        public void Add_Product_Will_Return_True()
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

            bool result = productDataAccess.AddProduct(newProduct);

            Assert.True(result);
        }
        [Fact]
        public void Get_Product_With_Valid_Id_Will_Return_Product()
        {
            IProductDataAccess productsDataAccess = new ProductDataAccess();
            var product = new Product()
            {
                ProductName = "sayed",
                BrandId = 7,
                CategoryId = 7,
                ModelYear = 2021,
                ListPrice = 1300
            };

            var result = productsDataAccess.AddProduct(product);
            Assert.True(result);
            Assert.NotEqual(0, product.ProductId);
            int id = product.ProductId;


            product = productsDataAccess.GetProduct(id);

            Assert.NotNull(product);
            Assert.NotEmpty(product.ProductName);
            Assert.Equal(id, product.ProductId);
        }
        [Fact]
        //error
        public void Get_Product_With_Invalid_Id_Will_Null()
        {
            IProductDataAccess productsDataAccess = new ProductDataAccess();

            int id = 0;

            var product = productsDataAccess.GetProduct(id);

            Assert.Null(product);
        }
        [Fact]
        public void Get_ProductList_Will_Return_Collection()
        {
            IProductDataAccess productDataAccess = new ProductDataAccess();

            var products=productDataAccess.GetProductList();

            Assert.NotEmpty(products);
        }
        [Fact]
        public void Update_Product_Will_Return_True()
        {
            IProductDataAccess productDataAccess = new ProductDataAccess();    

            var product=productDataAccess.GetProduct(1);
            
            var result= productDataAccess.UpdateProduct(product); 

            Assert.True(result);
        }
        [Fact]
        public void Delete_Product_Will_Return_True()
        {
            IProductDataAccess productDataAccess= new ProductDataAccess();
            var product = new Product()
            {
                ProductName = "sayed",
                BrandId = 7,
                CategoryId = 7,
                ModelYear = 2021,
                ListPrice = 1300
            };

            var result =productDataAccess.AddProduct(product);
            Assert.True(result);
            Assert.NotEqual(0,product.ProductId);

            //act
            result = productDataAccess.DeleteProduct(product.ProductId);

            //assert
            Assert.True(result);
        }
    }
}
