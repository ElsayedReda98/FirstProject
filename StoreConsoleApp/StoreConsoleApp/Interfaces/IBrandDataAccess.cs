using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IBrandDataAccess
    {
        List<Brands> GetBrandList();

        Brands GetBrand(int id);
        
        bool AddBrand(Brands brand);

        bool UpdateBrand(Brands brand);

        bool DeleteBrand(int id);

    }
}
