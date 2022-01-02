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
        public void Add_Staff_Will_Return_True()
        {
            IStaffDataAccess staffDataAccess = new StaffDataAccess();
            var newStaff = new Staff()
            {
                FirstName = "Elsayed",
                LastName = "Reda",
                Phone = "0100897985",
                // must change
                Email =$"{Guid.NewGuid()}@sayed.com",
                Active = 1,
                ManagerId = 1,
                StoreId = 2
            };

            bool result = staffDataAccess.AddStaff(newStaff);

            Assert.True(result);
        }
        [Fact]
        public void Get_Staff_With_Valid_Id_Will_Return_Staff()
        {
            //arrange
            IStaffDataAccess staffDataAccess = new StaffDataAccess();
            var staff = new Staff()
            {
                FirstName = "sayed",
                LastName = "Reda",
                Phone = "01008927985",
                // must change
                Email = $"{Guid.NewGuid()}@sayed.com",
                Active = 1,
                ManagerId = 1,
                // must change every cycle
                StoreId = 3

            };

            var result = staffDataAccess.AddStaff(staff);
            Assert.True(result);
            Assert.NotEqual(0, staff.StaffId);
            int id = staff.StaffId;

            //act
            staff = staffDataAccess.GetStaff(id);

            //assert
            Assert.NotNull(staff);
            Assert.NotEmpty(staff.FirstName);
            Assert.NotEmpty(staff.LastName);
            Assert.NotEmpty(staff.Phone);
            Assert.NotEmpty(staff.Email);
            Assert.Equal(id, staff.StaffId);
        }
        [Fact]
        public void Get_Staff_With_Invalid_Id_Will_Null()
        {
            IStaffDataAccess staffDataAccess = new StaffDataAccess();
            int id = -1;
            var staff = staffDataAccess.GetStaff(id);

            Assert.Null(staff);

        }
        [Fact]
        public void Get_StaffList_Will_Retuen_Collection()
        {
            //arrange
            IStaffDataAccess staffDataAccess = new StaffDataAccess();
            int id = 1;
            //act
            var staffs = staffDataAccess.GetStaffsList(id);

            //assert
            Assert.NotEmpty(staffs);

        }
        [Fact]
        public void Update_Staff_Will_Return_True()
        {
            //arrange
            IStaffDataAccess staffDataAccess = new StaffDataAccess();
            var staff = staffDataAccess.GetStaff(3);

            //act
            var result = staffDataAccess.UpdateStaff(staff);

            //assert
            Assert.True(result);
        }
        [Fact]
        public void Delete_Staff_Will_Return_True()
        {
            //arrange
            IStaffDataAccess staffDataAccess = new StaffDataAccess();
            var staff = new Staff()
            {
                FirstName = "sayed",
                LastName = "Reda",
                Phone = "01008927985",
                // must change
                Email = $"{Guid.NewGuid()}@sayed.com",
                Active = 1,
                ManagerId = 1,
                // must change every cycle
                StoreId = 1
            };

            var result = staffDataAccess.AddStaff(staff);
            Assert.True(result);
            Assert.NotEqual(0, staff.StaffId);

            //act
            result = staffDataAccess.DeleteStaff(staff.StaffId);

            //assert
            Assert.True(result);
        }
    }
}
