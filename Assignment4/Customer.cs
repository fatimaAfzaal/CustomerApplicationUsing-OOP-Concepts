using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Customer
    {

        public String CompanyID
        {
            get; set;
        }
        public String CompanyName
        {
            get; set;
        }
        public String ContactName
        {
            get; set;
        }
        public String Phone
        {
            get; set;
        }
       
        private static String myConn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public const String InsertQuery = "Insert Into customers(CompanyName,ContactName,Phone) Values(@CompanyName,@ContactName,@Phone)";
        public bool InsertEmployee(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    
                    com.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    com.Parameters.AddWithValue("@ContactName", customer.ContactName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        public const String UpdateQuery = "update customers set CompanyName=@CompanyName,ContactName=@ContactName,Phone=@Phone where CompanyID=@CompanyID";
        public bool UpdateEmployee(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@CompanyID", customer.CompanyID);
                    com.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    com.Parameters.AddWithValue("@ContactName", customer.ContactName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);

                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        public const String DeleteQuery = "delete from customers where CompanyID=@CompanyID";
        public bool DeleteEmployee(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@CompanyID", customer.CompanyID);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public const String SelectQuery = "select * from customers";
        public DataTable GetCustomer()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
    }
}
