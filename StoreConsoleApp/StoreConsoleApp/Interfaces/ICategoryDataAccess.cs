using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    interface ICategoryDataAccess
    {
        List<Categories> GetCategoryList();

        Categories GetCategory(int id);

        bool AddCategory(Categories category);

        bool UpdateCategory(Categories category);

        bool DeleteCategory(int id);

        
    }
}
