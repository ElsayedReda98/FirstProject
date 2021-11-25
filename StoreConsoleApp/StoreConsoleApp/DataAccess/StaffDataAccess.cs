using ConsoleApp1.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataAccess
{
    class StaffDataAccess : IStaffDataAccess
    {
        SqlConnection connection;
        public StaffDataAccess()
        {
            connection = new SqlConnection("Data Source =.; Initial Catalog = BikeStores; Integrated Security = True");

        }
        public bool AddStaff(Staffs staff)
        {
            string sqlstmt = $@"INSERT INTO sales.staffs
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
            command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(staff.Phone) ? DBNull.Value : staff.Phone);
            command.Parameters.AddWithValue("@Email", staff.Email);
            command.Parameters.AddWithValue("@Active", staff.Active);
            command.Parameters.AddWithValue("@StaffId", staff.StaffId);
            //
            command.Parameters.AddWithValue("@ManagerId",staff.ManagerId );
            connection.Open();
            staff.StaffId = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return staff.StaffId > 0;
        }

        public bool DeleteStaff(int id)
        {
            throw new NotImplementedException();
        }

        public Staffs GetStaff(int id)
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

            Staffs staff = null;
            while (reader.Read())
            {
                staff = new Staffs()
                {
                    StaffId = Convert.ToInt32(reader["customer_id"]),
                    FirstName = Convert.ToString(reader["first_name"]),
                    LastName = Convert.ToString(reader["last_name"]),
                    Email = Convert.ToString(reader["email"]),
                    Phone = Convert.ToString(reader["phone"]),
                    Active = Convert.ToInt32(reader["active"]),
                    StoreId = Convert.ToInt32(reader["store_id"]),
                    ManagerId = Convert.ToInt32(reader["manager_id"])
                };
            }
            reader.Close();
            return staff;
        }
        public List<Staffs> GetStaffsList()
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

            List<Staffs> staffs = new List<Staffs>();
            while (reader.Read())
            {
                staffs.Add(new Staffs()
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
            reader.Close();
            return staffs;
        
        }

        public bool UpdateStaff(Staffs staff)
        {
            throw new NotImplementedException();
        }
    }
}
