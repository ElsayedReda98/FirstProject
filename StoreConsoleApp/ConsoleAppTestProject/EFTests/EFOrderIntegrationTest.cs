﻿using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleAppTestProject
{
    public class EFOrderIntegrationTest
    {
        [Fact]
        public void Add_Order_Will_Return_True()
        {
            //Arrange
            IOrderDataAccess orderDataAccess = new EFOrderDataAccess();
            var newOrder = new Order()
            {
                CustomerId = 100,
                OrderDate = DateTime.Now,
                OrderStatus = 4,
                RequiredDate = DateTime.Today,
                ShippedDate = DateTime.Today,
                StaffId = 1,
                StoreId = 1
            };

            //Act
            bool result = orderDataAccess.AddOrder(newOrder);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Get_Order_With_Valid_Id_Will_Return_Order()
        {
            //Arrange
            IOrderDataAccess orderDataAccess = new EFOrderDataAccess();
            var order = new Order()
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                OrderStatus = 1,
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                StaffId = 1,
                StoreId = 1
            };

            var result = orderDataAccess.AddOrder(order);
            Assert.True(result);
            Assert.NotEqual(0, order.OrderId);
            int id = order.OrderId;

            //Act
            order = orderDataAccess.GetOrder(id);

            //Assert
            Assert.NotNull(order);
            //Assert.NotEmpty(order.OrderStatus);
            //Assert.NotEmpty(order.StoreId);
            //Assert.NotEmpty(order.RequiredDate);
            Assert.Equal(id, order.OrderId);
            
            
        }

        [Fact]
        public void Get_Order_With_InValid_Id_Will_Null()
        {
            //Arrange
            IOrderDataAccess orderDataAccess = new EFOrderDataAccess();
            int id = -1;
            //Act
            var order = orderDataAccess.GetOrder(id);

            //Assert
            Assert.Null(order);
        }

        [Fact]
        public void Get_OrdersList_Will_Return_Collection()
        {
            //Arrange
            IOrderDataAccess orderDataAccess = new EFOrderDataAccess();

            //Act
            var orders = orderDataAccess.GetOrdersList();
           
                

            //Assert
            Assert.NotEmpty(orders);

        }

        [Fact]
        public void Update_Order_Will_Return_True()
        {
            //Arrange
            IOrderDataAccess orderDataAccess = new EFOrderDataAccess();
            var order = orderDataAccess.GetOrder(1);
            //Act
            var result = orderDataAccess.UpdateOrder(order);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_Order_Will_Return_True()
        {
            //Arrange
            IOrderDataAccess orderDataAccess = new EFOrderDataAccess();
            var order = new Order()
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                OrderStatus = 1,
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                StaffId = 1,
                StoreId = 1
            };

            var result = orderDataAccess.AddOrder(order);
            Assert.True(result);
            Assert.NotEqual(0, order.OrderId);

            //Act
            result = orderDataAccess.DeleteOrder(order.OrderId);

            //Assert
            Assert.True(result);
        }
    }
}
