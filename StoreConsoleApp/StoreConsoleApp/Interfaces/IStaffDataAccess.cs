using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    public interface IStaffDataAccess
    {
        List<Staff> GetStaffsList();

        Staff GetStaff(int id);

        bool AddStaff(Staff staff);

        bool UpdateStaff(Staff staff);

        bool DeleteStaff(int id);


    }
}
