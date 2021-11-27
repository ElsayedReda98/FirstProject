using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IStoreDataAccess
    {
        List<Store> GetStoresList();

        Store GetStore(int id);

        bool AddStore(Store store);

        bool UpdateStore(Store store);

        bool DeleteStore(int id);
    }
}
