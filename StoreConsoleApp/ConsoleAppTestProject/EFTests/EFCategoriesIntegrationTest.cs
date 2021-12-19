using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleAppTestProject
{
    public class EFCategoriesIntegrationTest
    {
        [Fact]
        public void Add_Category_Will_Return_True()
        {
            //Arrange
            ICategoryDataAccess categoryDataAccess = new EFCategoryDataAccess();
            var newCategory = new Category()
            {
                CategoryName = "Category To Add"
            };
            //Act
            bool result = categoryDataAccess.AddCategory(newCategory);

            //Arrange 
            Assert.True(result);
        }
        [Fact]
        public void Get_Category_With_Valid_Id_will_Return_Category()
        {
            // Arrange
            ICategoryDataAccess categoryDataAccess = new EFCategoryDataAccess();

            var category = new Category()
            {
                CategoryName = "Category To Get"
            };
            var result = categoryDataAccess.AddCategory(category);
            Assert.True(result);
            Assert.NotEqual(0, category.CategoryId);
            int id = category.CategoryId;

            //Act
            category = categoryDataAccess.GetCategory(id);

            //Assert
            Assert.NotNull(category);
            Assert.NotEmpty(category.CategoryName);
            Assert.Equal(id, category.CategoryId);
        }
        [Fact]
        public void Get_Category_With_Invalid_Id_Will_Null()
        {
            //Arrange
            ICategoryDataAccess categoryDataAccess=new EFCategoryDataAccess();
            int id = -1;

            //Act
            var category = categoryDataAccess.GetCategory(id);

            //Assert
            Assert.Null(category);
        }

        [Fact]
        public void Get_BrandList_Will_Return_Collection()
        { 
                //Arrange 
                ICategoryDataAccess categoryDataAccess =new CategoryDataAccess();


            //ACt
            var category = categoryDataAccess.GetCategoryList();

            //Assert
            Assert.NotEmpty(category);
        }

        [Fact]
        public void Update_Category_Will_Return_True()
        {
            //Arrange
            ICategoryDataAccess categoryDataAccess = new EFCategoryDataAccess();
            var category = categoryDataAccess.GetCategory(1);

            //Act
            var result = categoryDataAccess.UpdateCategory(category);

            //Assert
            Assert.True(result);

        }
        [Fact]
        public void Delete_Category_Will_Return_True()
        {
            //Arrange 
            ICategoryDataAccess categoryDataAccess= new EFCategoryDataAccess();
            var category = new Category()
            {
                CategoryName = "category to delete "
            };

            var result= categoryDataAccess.AddCategory(category);
            Assert.True(result);
            Assert.NotEqual(0, category.CategoryId);

            //Act
            result = categoryDataAccess.DeleteCategory(category.CategoryId);

            //Assert
            Assert.True(result);

        }
    }
}
