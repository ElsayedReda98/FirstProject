using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleAppTestProject
{
    public class OrderItemIntegrationTest
    {
        [Fact]
        public void Add_OrderItem_Will_Return_True()
        {
            //Arrange
            IOrderItemDataAccess orderItemDataAccess = new OrderItemDataAccess();
            var newOrderItem = new OrderItem()
            {   
                ItemId = 21,
                OrderId = 10,
                ProductId = 1,
                Quantity = 1,
                ListPrice = 600,
                Discount = 3
            };

            //Act
            bool result = orderItemDataAccess.AddOrderItem(newOrderItem);

            //assert
            Assert.True(result);
        }
        [Fact]
        public void Get_OrderItem_With_Valid_Id_Will_Return_OrderItem()
        {
            //Arrange
            IOrderItemDataAccess orderItemDataAccess = new OrderItemDataAccess();
            var orderItem = new OrderItem()
            {
                ItemId= 5,
                OrderId=10,
                ProductId = 1,
                Quantity = 1,
                ListPrice = 600,
                Discount = 3
            };

            var result = orderItemDataAccess.AddOrderItem(orderItem);
            Assert.True(result);
            Assert.NotEqual(0, orderItem.ItemId);
            int itemId = orderItem.ItemId;
            int orderId = orderItem.OrderId;

            //act
            orderItem = orderItemDataAccess.GetOrderItem(orderId,itemId);

            //assert
            Assert.NotNull(orderItem);
            //Assert.NotEmpty(orderItem.OrderId);
            Assert.Equal(itemId, orderItem.ItemId);
            Assert.Equal(orderId, orderItem.OrderId);
        }
        [Fact]
        public void Get_OrdereItem_With_InValid_Id_Will_Null()
        {
            //Arrange
            IOrderItemDataAccess orderItemDataAccess = new OrderItemDataAccess();
            int orderId = -1;
            int itemId = -1;
            //Act
            var orderItem =orderItemDataAccess.GetOrderItem(orderId,itemId);

            //Assert
            Assert.Null(orderItem);
        }
        [Fact]
        public void Get_OrderItemsList_Will_Return_Collection()
        {
            //Arrange
            IOrderItemDataAccess orderItemDataAccess = new OrderItemDataAccess();

            //Act
            var orderItems = orderItemDataAccess.GetOrderItemList();
            // if(orders != null)


            //Assert
            Assert.NotEmpty(orderItems);

        }
        [Fact]
        public void Update_OrderItem_Will_Return_True()
        {
            //Arrange
            IOrderItemDataAccess orderItemDataAccess = new OrderItemDataAccess();
            var orderItem = orderItemDataAccess.GetOrderItem(1,2);
            //Act
            var result = orderItemDataAccess.UPdateOrderItem(orderItem);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_OrderItem_Will_Return_True()
        {
            //Arrange
            IOrderItemDataAccess orderItemDataAccess = new OrderItemDataAccess();
            var orderItem = new OrderItem()
            {
                ItemId = 1,
                OrderId = 50,
                ProductId = 1,
                Quantity = 1,
                ListPrice = 600,
                Discount = 0.1m
            };

            var result = orderItemDataAccess.AddOrderItem(orderItem);
            Assert.True(result);
            Assert.NotEqual(0, orderItem.ItemId);

            //Act
            result = orderItemDataAccess.DeleteOrderItem(orderItem.OrderId,orderItem.ItemId);

            //Assert
            Assert.True(result);
        }
    }
}
