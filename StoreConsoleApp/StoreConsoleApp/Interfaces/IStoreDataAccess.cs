using System.Collections.Generic;

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
