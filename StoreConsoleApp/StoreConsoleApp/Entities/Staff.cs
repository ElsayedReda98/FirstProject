using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Active { get; set; }
        //public int StoreId { get; set; }
      

        //one to many relationship between  orders and staffs
        // staff is one and ordres is many
        public ICollection<Order> Orders { get; set; }


        //one to many relationship between staffs and stores
        //staff is many and stores is one
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int ManagerId { get; set; }

        //one to many relationship between  orders and staffs
        // staff is one and ordres is many
        


        



    }
}
