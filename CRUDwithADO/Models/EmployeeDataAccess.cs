using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;

namespace CRUDwithADO.Models
{
    public class EmployeeDataAccess
    {
        DBConnection DBConnection;
        public EmployeeDataAccess()
        {
            DBConnection = new DBConnection();
        }
        public List<Employees> GetEmployees()
        {
            string Sp = "SP_EMPLOYEE";
            SqlCommand sql = new SqlCommand(Sp, DBConnection.Connection);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@action", "SELECT_JOIN");
            if (DBConnection.Connection.State == ConnectionState.Closed)
            {
                DBConnection.Connection.Open();
            }
            SqlDataReader dr = sql.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            while(dr.Read())
            {
                Employees Emp = new Employees();
                Emp.Id = (int)dr["id"];
                Emp.Name = dr["name"].ToString();
                Emp.Email = dr["email"].ToString();
                Emp.Mobile = dr["mobile"].ToString();
                Emp.Gender= dr["gender"].ToString();
                Emp.DName = dr["department"].ToString();
                employees.Add(Emp);
            }
            DBConnection.Connection.Close();
            return employees;
        }
        
    }
}
