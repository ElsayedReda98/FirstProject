using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using Xunit;

namespace ConsoleAppTestProject
{
    public class BrandsIntegrationTest
    {
        [Fact]
        public void Add_Brand_Will_Return_True()
        {
            //Arrange
            IBrandDataAccess brandDataAccess = new BrandsDataAccess();
            var newBrand = new Brands()
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
            IBrandDataAccess brandDataAccess = new BrandsDataAccess();
            int id = 1;
            //Act
            var brand = brandDataAccess.GetBrand(id);

            //Assert
            Assert.NotNull(brand);
            Assert.NotEmpty(brand.BrandName);
            Assert.Equal(id, brand.BrandId);
        }

        [Fact]
        public void Get_Brand_With_InValid_Id_Will_Null()
        {
            //Arrange
            IBrandDataAccess brandDataAccess = new BrandsDataAccess();
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
            IBrandDataAccess brandDataAccess = new BrandsDataAccess();
            
            //Act
            var brands = brandDataAccess.GetBrandList();

            //Assert
            Assert.NotEmpty(brands);
        }
    }
}
