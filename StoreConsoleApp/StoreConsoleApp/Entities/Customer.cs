﻿namespace ConsoleApp1
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

        public string Street { get; set; }

        public override string ToString()
        {
            return $"ID :{Id} Name :{FirstName},{LastName}" +
                $" Phone :{Phone} Email :{Email}";
        }
    }
}
