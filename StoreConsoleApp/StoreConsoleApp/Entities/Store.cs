using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }


        //one to many relationship between orders and stores
        // stores is one & ordres is many 
        public ICollection<Order> Orders { get; set; }

        //one to many relationship between staffs and stores
        //store is one & staff is many
        public ICollection<Staff> Staffs { get; set; }

        //one to many rshp between to stores & stocks
        //
        public ICollection<Stock> Stocks { get; set; }



    }
}
