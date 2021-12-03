using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    public interface ICategoryDataAccess
    {
        List<Category> GetCategoryList();

        Category GetCategory(int id);

        bool AddCategory(Category category);

        bool UpdateCategory(Category category);

        bool DeleteCategory(int id);


    }
}
