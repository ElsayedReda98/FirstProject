using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1.DataAccess
{
    public class StaffDataAccess : IStaffDataAccess
    {
        SqlConnection connection;
        public StaffDataAccess()
        {
            connection = new SqlConnection("Data Source =.; Initial Catalog = BikeStores; Integrated Security = True");
        }
        public bool AddStaff(Staff staff)
        {
            string sqlstmt = @"INSERT INTO sales.staffs    
                  ( first_name,
                    last_name,
                    email,
                    phone,
                    active,
                    store_id,
                    manager_id )
                OUTPUT Inserted.staff_id
                VALUES
                    (@FirstName,
                    @LastName,
                    @Email,
                    @Phone, 
                    @Active,
                    @StoreId,
                    @ManagerId )";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstmt;
            command.Parameters.AddWithValue("@FirstName", staff.FirstName);
            command.Parameters.AddWithValue("@LastName", staff.LastName);
            command.Parameters.AddWithValue("@Email", staff.Email);
            command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(staff.Phone) ? DBNull.Value : (object)staff.Phone);
            command.Parameters.AddWithValue("@Active", staff.Active);
            command.Parameters.AddWithValue("@StoreId", staff.StoreId);
            command.Parameters.AddWithValue("@ManagerId", staff.ManagerId);
            connection.Open();
            
            //staff.StaffId = Convert.ToInt32(command.ExecuteScalar());
            var effectedRows = command.ExecuteNonQuery();
            connection.Close();
            return effectedRows > 0;
        }
        public Staff GetStaff(int id)
        {
            string sqlstm = @$"SELECT
                    staff_id,                
                    first_name,
                    last_name,
                    email,
                    phone,
                    active,
                    store_id,
                    manager_id
                FROM sales.staffs 
                WHERE staff_id={id} ";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            Staff staff = null;
            if (reader.Read())
            {
                staff = new Staff()
                {
                    StaffId = Convert.ToInt32(reader["staff_id"]),
                    FirstName = Convert.ToString(reader["first_name"]),
                    LastName = Convert.ToString(reader["last_name"]),
                    Email = Convert.ToString(reader["email"]),
                    Phone = Convert.ToString(reader["phone"]),
                    Active = Convert.ToInt32(reader["active"]),
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    ManagerId = Convert.ToInt32(reader["manager_id"])
                };
            }
            connection.Close();
            return staff;
        }
        public List<Staff> GetStaffsList()
        {
            string sqlstm = @" SELECT
                    staff_id,                
                    first_name,
                    last_name,
                    email,
                    phone,
                    active,
                    store_id,
                    manager_id
               FROM sales.staffs ";

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            List<Staff> staffs = new List<Staff>();

            while (reader.Read())
            {
                staffs.Add(new Staff()
                {
                    StaffId = Convert.ToInt32(reader["staff_id"]),
                    FirstName = Convert.ToString(reader["first_name"]),
                    LastName = Convert.ToString(reader["last_name"]),
                    Email = Convert.ToString(reader["email"]),
                    Phone = Convert.ToString(reader["phone"]),
                    Active = Convert.ToInt32(reader["active"]),
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    ManagerId = Convert.ToInt32(reader["manager_id"])
                });
            }
            connection.Close();
            return staffs;
        }
        public bool UpdateStaff(Staff staff)
        {
            string sqlstm = @" UPDATE sales.staffs
                    SET first_name=@FirstName,
                        last_name=@LastName,
email=@Email,
phone=@Phone,
active=@Active,
store_id=@StoreId,
manager_id=@ManagerId
                    WHERE satff_id = @StaffId";

            SqlCommand command1 = connection.CreateCommand();
            command1.CommandText = sqlstm;
            
            command1.Parameters.AddWithValue("@FirstName", staff.FirstName);
            command1.Parameters.AddWithValue("@LastName", staff.LastName);
            command1.Parameters.AddWithValue("@Email",staff.Email);
            command1.Parameters.AddWithValue("@Phone", staff.Phone);
            command1.Parameters.AddWithValue("@Active",staff.Active);
            command1.Parameters.AddWithValue("@StoreId", staff.StoreId);
            command1.Parameters.AddWithValue("@ManagerId", staff.ManagerId);
            command1.Parameters.AddWithValue("@StaffId", staff.StaffId);

            connection.Open();
            int effectedRows = command1.ExecuteNonQuery();
            connection.Close();
            return effectedRows > 0;
        }
        public bool DeleteStaff(int id)
        {
            string sqlstm = @"DELETE 
                             FROM sales.staffs
                             WHERE staff_id=" + id;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            int effectedRows = command.ExecuteNonQuery();
            connection.Close();
            return effectedRows > 0;
        }
        
    }
}
