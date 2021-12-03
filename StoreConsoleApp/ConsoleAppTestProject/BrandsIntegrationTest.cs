using ConsoleApp1;
using ConsoleApp1.DataAccess;
using StoreConsoleApp.Interfaces;
using Xunit;

namespace ConsoleAppTestProject
{
    public class BrandsIntegrationTest
    {
        [Fact]
        public void Add_Brand_Will_Return_True()
        {
            //Arrange
            IBrandDataAccess brandDataAccess = new BrandDataAccess();
            var newBrand = new Brand()
            {
                BrandName = "Brand to add",
            };

            //Act
            bool result = brandDataAccess.AddBrand(newBrand);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Get_Brand_With_Valid_Id_Will_Return_Brand()
        {
            //Arrange
            IBrandDataAccess brandDataAccess = new BrandDataAccess();
            var brand = new Brand()
            {
                BrandName = "Brand To Delete",
            };

            var result = brandDataAccess.AddBrand(brand);
            Assert.True(result);
            Assert.NotEqual(0, brand.BrandId);
            int id = brand.BrandId;

            //Act
            brand = brandDataAccess.GetBrand(id);

            //Assert
            Assert.NotNull(brand);
            Assert.NotEmpty(brand.BrandName);
            Assert.Equal(id, brand.BrandId);
        }

        [Fact]
        public void Get_Brand_With_InValid_Id_Will_Null()
        {
            //Arrange
            IBrandDataAccess brandDataAccess = new BrandDataAccess();
            int id = -1;
            //Act
            var brand = brandDataAccess.GetBrand(id);

            //Assert
            Assert.Null(brand);
        }

        [Fact]
        public void Get_BrandsList_Will_Return_Collection()
        {
            //Arrange
            IBrandDataAccess brandDataAccess = new BrandDataAccess();

            //Act
            var brands = brandDataAccess.GetBrandList();

            //Assert
            Assert.NotEmpty(brands);

        }

        [Fact]
        public void Update_Brand_Will_Return_True()
        {
            //Arrange
            IBrandDataAccess brandDataAccess = new BrandDataAccess();
            var brand = brandDataAccess.GetBrand(1);
            //Act
            var result = brandDataAccess.UpdateBrand(brand);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_Brand_Will_Return_True()
        {
            //Arrange
            IBrandDataAccess brandDataAccess = new BrandDataAccess();
            var brand = new Brand()
            {
                BrandName = "Brand To Delete",
            };

            var result = brandDataAccess.AddBrand(brand);
            Assert.True(result);
            Assert.NotEqual(0, brand.BrandId);

            //Act
            result = brandDataAccess.DeleteBrand(brand.BrandId);

            //Assert
            Assert.True(result);
        }
    }
}
