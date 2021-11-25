﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    interface ICustomerDataAccess
    {
        List<Customer> GetCustomerList();

        Customer GetCustomer(int id);

        bool AddCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(int id);
    }
}