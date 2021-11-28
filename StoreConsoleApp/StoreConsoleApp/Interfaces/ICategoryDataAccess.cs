using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface ICategoryDataAccess
    {
        List<Category> GetCategoryList();

        Category GetCategory(int id);

        bool AddCategory(Category category);

        bool UpdateCategory(int id);

        bool DeleteCategory(int id);

        
    }
}
