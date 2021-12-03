using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using Xunit;

namespace ConsoleAppTestProject
{
    public class CustomerIntegrationTest
    {
        [Fact]
        public void Add_Customer_Will_Return_True()
        {
            ICustomerDataAccess customerDataAccess = new CustomerDataAccess();

            var newCustomer = new Customer()
            {
                FirstName = "Elsayed",
                LastName = "Reda",
                Phone = "01008927985",
                Email = "sayed.com",
                State = "s",
                Street = "abo ouf",
                City = "misr",
                ZipCode = "05040"
            };
            //
            bool result = customerDataAccess.AddCustomer(newCustomer);

            //
            Assert.True(result);
        }

        [Fact]
        public void Get_Customer_With_Valid_Id_Will_Return_Customer()
        {
            ICustomerDataAccess customDataAccess = new CustomerDataAccess();
            var customer = new Customer()
            {
                FirstName = "first name to get",
                LastName = "last name to get",
                Phone = "0100",
                Email = "email to get",
                Street = "street",
                City = "egypt",
                State = "s",
                ZipCode = "050"
            };

            var result = customDataAccess.AddCustomer(customer);
            Assert.True(result);
            Assert.NotEqual(0, customer.Id);
            int id = customer.Id;

            //act 
            customer = customDataAccess.GetCustomer(id);

            //assert
            Assert.NotNull(customer);
            Assert.NotEmpty(customer.FirstName);
            Assert.NotEmpty(customer.LastName);
            Assert.NotEmpty(customer.Email);
            Assert.NotEmpty(customer.Street);
            Assert.NotEmpty(customer.City);
            Assert.NotEmpty(customer.State);
            Assert.NotEmpty(customer.ZipCode);
            Assert.Equal(id, customer.Id);
        }
        [Fact]

        public void Get_Customer_With_Invalid_Id_Will_Null()
        {
            // arrange
            ICustomerDataAccess customerDataAccess = new CustomerDataAccess();

            int id = -1;

            //act 
            var customer = customerDataAccess.GetCustomer(id);

            //assert
            Assert.Null(customer);
        }

        [Fact]
        public void Get_BrandList_Will_Return_Collection()
        {
            ICustomerDataAccess customerDataAccess = new CustomerDataAccess();

            //act
            var customer = customerDataAccess.GetCustomerList();

            //assert
            Assert.NotEmpty(customer);

        }
        [Fact]
        public void Update_Customer_Will_Return_True()
        {
            //arrange
            ICustomerDataAccess customerDataAccess = new CustomerDataAccess();

            var customer = customerDataAccess.GetCustomer(1);

            //ACT
            var result = customerDataAccess.UpdateCustomer(customer);

            //assert
            Assert.True(result);
        }
        [Fact]
        public void Delete_Customer_Will_Return_True()
        {
            //arrange
            ICustomerDataAccess customerDataAccess = new CustomerDataAccess();
            var customer = new Customer()
            {
                FirstName = "first name to get",
                LastName = "last name to get",
                Phone = "0100",
                Email = "email to get",
                Street = "street",
                City = "egypt",
                State = "s",
                ZipCode = "050"
            };

            var result = customerDataAccess.AddCustomer(customer);
            Assert.True(result);
            Assert.NotEqual(0, customer.Id);

            //act
            result = customerDataAccess.DeleteCustomer(customer.Id);

            //assert
            Assert.True(result);
        }
    }
}
