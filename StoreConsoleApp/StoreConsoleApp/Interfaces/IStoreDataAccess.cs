using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    interface IStoreDataAccess
    {
        List<Stores> GetStoresList();

        Stores GetStore(int id);

        bool AddStore(Stores store);

        bool UpdateStore(Stores store);

        bool DeleteStore(int id);
    }
}
