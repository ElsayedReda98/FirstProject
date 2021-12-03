using ConsoleApp1;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ConsoleAppTestProject
{
    public class StaffIntegrationTest
    {
        [Fact]
        public void Add_Staff_Will()
        {
            IStaffDataAccess staffDataAccess = new StaffDataAccess();
            var newStaff = new Staff()
            {
                FirstName = "Elsayed",
                LastName = "Reda",
                Phone = "01008927985",
                Email = $"{Guid.NewGuid()}@sayed.com",
                Active = 2,
                ManagerId = 1,
                StoreId = 1
            };

            bool result = staffDataAccess.AddStaff(newStaff);

            Assert.True(result);
        }
        [Fact]
        public void Get_Staff_With()
        {
            IStaffDataAccess staffDataAccess = new StaffDataAccess();
            var staff = new Staff()
            {
                FirstName = "sayed",
                LastName = "Reda",
                Phone = "01008927985",
                // must change
                Email = "hhhhhhhh.com",
                Active = 1,
                ManagerId = 1,
                // must change every cycle
                StoreId = 3

            };

            var result = staffDataAccess.AddStaff(staff);
            Assert.True(result);
            Assert.NotEqual(0,staff.StaffId);
            int id = staff.StaffId;

            staff=staffDataAccess.GetStaff(id);

            Assert.NotNull(staff);
            Assert.NotEmpty(staff.FirstName);
            Assert.NotEmpty(staff.LastName);
            Assert.NotEmpty(staff.Phone);
            Assert.NotEmpty(staff.Email);
            Assert.Equal(id, staff.StaffId);
        }
        [Fact]
        public void Get_Staff_With_Invalid()
        {
            IStaffDataAccess staffDataAccess = new StaffDataAccess();
            int id = -1;
            var staff = staffDataAccess.GetStaff(id);

            Assert.Null(staff);

        }
    }
}
