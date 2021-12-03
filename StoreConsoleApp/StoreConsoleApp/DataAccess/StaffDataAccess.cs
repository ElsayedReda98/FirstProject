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
                (   
                    first_name,
                    last_name,
                    email,
                    phone,
                    active,
                    store_id,
                    manager_id
                )
                OUTPUT Inserted.staff_id
                VALUES
                (@FirstName,
                @LastName,
                @Email,
                @Phone, 
                @Active,
                @StoreId,
                @ManagerId
                )";

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
            staff.StaffId = Convert.ToInt32(command.ExecuteScalar());
            // staff.StoreId=Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return staff.StaffId > 0;
        }

        public bool DeleteStaff(int id)
        {
            string sqlstm = @"DELETE 
                             FROM sales.staff
                             WHERE staff_id=" + id;

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
            return id > 0;

        }

        public Staff GetStaff(int id)
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
FROM sales.staffs 
WHERE staff_id=" + id;

            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstm;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            Staff staff = null;
            while (reader.Read())
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
                    StaffId = Convert.ToInt32(reader["customer_id"]),
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
            string sqlstm = @"
update sales.staffs
set first_name=@FirstName,
    last_name=@LastName
where satff_id=@StaffId";
            SqlCommand command1 = connection.CreateCommand();
            command1.CommandText = sqlstm;
            command1.Parameters.AddWithValue("@FirstName", staff.FirstName);
            command1.Parameters.AddWithValue("@LastName", staff.LastName);
            connection.Open();
            int effectedRows = command1.ExecuteNonQuery();
            return effectedRows > 0;
        }
    }
}
