using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public string Street { get; internal set; }

        public override string ToString()
        {
            return $"ID :{Id} Name :{FirstName},{LastName}" +
                $" Phone :{Phone} Email :{Email}";
        }
    }
}
