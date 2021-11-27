using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
