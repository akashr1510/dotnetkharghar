using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        public void AddNewEmployee(Employee emp)
        {
            //add code to add Employee here
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = cn;
            cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
            cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Basic", emp.Basic);
            cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
            cmd.ExecuteNonQuery();
            cn.Close();

        }

        public void DeleteEmployee(string EmpNo)
        {
            //add code to delete Employee here

        }

        public Employee GetEmployeeDetails(string EmpNo)
        {
            Employee obj = new Employee { EmpNo = 1, Basic = 12345, DeptNo = 10, Name = "Yash" };
            return obj;
        }

        public void UpdateEmployee(Employee emp)
        {
            //add code to update Employee here

        }
    }
}
