using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    interface IStaffDataAccess
    {
        List<Staffs> GetStaffsList();

        Staffs GetStaff(int id);

        bool AddStaff(Staffs staff);

        bool UpdateStaff(Staffs staff);

        bool DeleteStaff(int id);
        

    }
}
