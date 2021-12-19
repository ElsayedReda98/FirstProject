using ConsoleApp1.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreConsoleApp;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.DataAccess
{
    public class EFStaffDataAccess : IStaffDataAccess
    {
        private readonly StoreContext _dbContext;
        public EFStaffDataAccess()
        {
            _dbContext = new StoreContext();
        }
        public bool AddStaff(Staff staff)
        {
            _dbContext.Staffs.Add(staff);
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }

        public bool DeleteStaff(int id)
        {
            var staff = _dbContext.Staffs.Find(id);
            if(staff == null)
                throw new ArgumentOutOfRangeException("id", $"There is no brand with id '{id}'");
            
            _dbContext.Staffs.Remove(staff);
            var deletedRows = _dbContext.SaveChanges();
            return deletedRows > 0;

        }

        public Staff GetStaff(int id)
        {
            return _dbContext.Staffs.Find(id);
        }
        public List<Staff> GetStaffsList()
        {   
            return _dbContext.Staffs.ToList();
        }

        public bool UpdateStaff(Staff staff)
        {
            var entry = _dbContext.Entry(staff);
            if (entry.State == EntityState.Detached)
                _dbContext.Staffs.Attach(staff);

            entry.State = EntityState.Modified;
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows > 0;
        }
    }
}
