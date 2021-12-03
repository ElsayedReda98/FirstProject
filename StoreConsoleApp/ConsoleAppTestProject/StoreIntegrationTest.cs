using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using Xunit;

namespace ConsoleAppTestProject
{
    public class StoreIntegrationTest
    {
        [Fact]
        public void Add_Store_will()
        {
            IStoreDataAccess storeDataAccess = new StoreDataAccess();
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
        public void Get_Store_With_Valid()
        {
            IStoreDataAccess storeDataAccess = new StoreDataAccess();
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
            Assert.NotEqual(0, store.StoreId);
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
            Assert.Equal(id, store.StoreId);

        }
        [Fact]
        public void Get_Store_With_Invalid()
        {
            IStoreDataAccess storeDataAccess = new StoreDataAccess();

            int id = -1;

            var store = storeDataAccess.GetStore(id);

            Assert.Null(store);

        }
        [Fact]
        public void Get_StoreList()
        {
            IStoreDataAccess storeDataAccess = new StoreDataAccess();

            var stores = storeDataAccess.GetStoresList();

            Assert.NotEmpty(stores);
        }
        [Fact]
        public void Update_Store_Will()
        {
            IStoreDataAccess storedDataAccess = new StoreDataAccess();
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

            storedDataAccess.AddStore(store);

            var result = storedDataAccess.UpdateStore(store);

            Assert.True(result);

        }
        [Fact]
        public void Delete_Store_Will()
        {
            IStoreDataAccess storeDataAccess = new StoreDataAccess();
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

            storeDataAccess.AddStore(store);

            var result = storeDataAccess.DeleteStore(store.StoreId);

            //assert
            Assert.True(result);

        }
    }
}
