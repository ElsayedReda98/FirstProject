﻿using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleAppTestProject
{
    public class EFStoreIntegrationTest
    {
        [Fact]
        public void Add_Store_will_Return_True()
        {
            IStoreDataAccess storeDataAccess = new EFStoreDataAccess();
            var newStore = new Store()
            {
                StoreName = "market",
                Phone = "012",
                Email = "le.com",
                State = "s",
                Street = "main street",
                City = "egypt",
                ZipCode = "015"

            };
            bool result = storeDataAccess.AddStore(newStore);

            Assert.True(result);
        }
        [Fact]
        public void Get_Store_With_Valid_Id_Will_Return_Strore()
        {
            IStoreDataAccess storeDataAccess = new EFStoreDataAccess();
            var store = new Store()
            {
                StoreName = "market2",
                Phone = "012",
                Email = "le.com",
                State = "s",
                Street = "main street",
                City = "egypt",
                ZipCode = "015"
            };
            var result = storeDataAccess.AddStore(store);
            Assert.True(result);
            Assert.NotEqual(0,store.StoreId);
            int id = store.StoreId;

            store = storeDataAccess.GetStore(id);    

            Assert.NotNull(store);
            Assert.NotEmpty(store.StoreName);
            Assert.NotEmpty(store.Phone);
            Assert.NotEmpty(store.Email);
            Assert.NotEmpty(store.State);
            Assert.NotEmpty(store.Street);
            Assert.NotEmpty(store.City);
            Assert.NotEmpty(store.ZipCode);
            Assert.Equal(id,store.StoreId);

        }
        [Fact]
        public void Get_Store_With_Invalid_Id_Will_Null()
        {
            IStoreDataAccess storeDataAccess = new EFStoreDataAccess();

            int id = -1;

            var store = storeDataAccess.GetStore(id);

            Assert.Null(store);

        }
        [Fact]
        public void Get_StoreList_Will_Return_Collection()
        {
            IStoreDataAccess storeDataAccess = new EFStoreDataAccess();

            var stores=storeDataAccess.GetStoresList();

            Assert.NotEmpty(stores);
        }
        [Fact]
        public void Update_Store_Will_Return_True()
        {
            IStoreDataAccess storedDataAccess = new EFStoreDataAccess();
            var store = storedDataAccess.GetStore(12);

            var result= storedDataAccess.UpdateStore(store);

            Assert.True(result);

        }
        [Fact]
        public void Delete_Store_Will_Return_True()
        {
            IStoreDataAccess storeDataAccess=new EFStoreDataAccess();
            var store = new Store()
            {
                StoreName = "super",
                Phone = "012",
                Email = "le.com",
                State = "s",
                Street = "main street",
                City = "egypt",
                ZipCode = "015"
            };

            var result =storeDataAccess.AddStore(store);
            Assert.True(result);
            Assert.NotEqual(0,store.StoreId);


            result = storeDataAccess.DeleteStore(store.StoreId);


            //assert
            Assert.True(result);
            
        }
    }
}
