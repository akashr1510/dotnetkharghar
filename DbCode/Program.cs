using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DbCode
{
    class Program
    {
        static void Main()
        {
            //OpenConnection();
            //Insert(null);
            Employee obj = new Employee { EmpNo = 7, Name = "D'Silva" +
                "", Basic = 10000, DeptNo = 10 };
            //InsertWithParameters(obj);
            //InsertWithStoredProcedure(obj);
            //GetSingleValue();
            //GetMultipleValuesUsingSqlDataReader();
            //GetMultipleResultsUsingSqlDataReader();

            //MARS();
            //CallFuncReturningSqlDataReader();


            Transactions();
            Console.ReadLine();
        }
        static void OpenConnection()
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;User Id=sa;Password=pwd";
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";

            try
            {
                cn.Open();
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }
        static void Insert(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            //cmdInsert.CommandText = "insert into Employees values(4, 'Shweta', 12345, 30)";
            cmdInsert.CommandText = "insert into Employees values(" + obj.EmpNo+ ", '" + obj.Name +"',"
                                                                    + obj.Basic + "," + obj.DeptNo + ")";
            Console.WriteLine(cmdInsert.CommandText);
            try
            {
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("no errors");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }

        static void Transactions()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();
            SqlTransaction t = cn.BeginTransaction();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.Transaction = t;

            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(10, 'Shweta', 12345, 30)";
            
            SqlCommand cmdInsert2 = new SqlCommand();
            cmdInsert2.Connection = cn;
            cmdInsert2.Transaction = t;

            cmdInsert2.CommandType = System.Data.CommandType.Text;
            cmdInsert2.CommandText = "insert into Employees values(20, 'Shweta', 12345, 30)";
            try
            {
                cmdInsert.ExecuteNonQuery();
                cmdInsert2.ExecuteNonQuery();
                t.Commit();
                Console.WriteLine("no errors- commit");
            }
            catch (Exception ex)
            {
                t.Rollback();
                Console.WriteLine("Rollback");
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }
        static void InsertWithParameters(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";
            //cmdInsert.CommandText = "update Employees set Name=@Name, Basic=@Basic, DeptNo=@DeptNo  where EmpNo=@EmpNo";
            //cmdInsert.CommandText = "delete from Employees where EmpNo=@EmpNo";


            cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
            cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
            cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
            cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

            try
            {
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("no errors");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }
        static void InsertWithStoredProcedure(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsert.CommandText = "InsertEmployee";

            cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
            cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
            cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
            cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

            try
            {
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("no errors");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }

        static void GetSingleValue()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            //cmdInsert.CommandText = "select * from Employees ";
            // cmdInsert.CommandText = "select Name from Employees where EmpNo = 1";
            cmdInsert.CommandText = "select count(*) from Employees ";

            try
            {
                object retval = cmdInsert.ExecuteScalar();  //ideal for queries that return single value
                //returns first row, first column
                Console.WriteLine(retval);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }
        static void GetMultipleValuesUsingSqlDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Employees ";

            try
            {
               SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[1]);
                    Console.WriteLine(dr["Name"]);
                    Employee obj = new Employee();
                    obj.Name = dr["Name"].ToString();
                    obj.EmpNo = (int)dr["EmpNo"];
                    obj.Name = dr.GetString(1);
                    obj.EmpNo= dr.GetInt32(0);


                }
                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }

        static void GetMultipleResultsUsingSqlDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Employees;select * from Departments";

            try
            {
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr["Name"]);
                }

                dr.NextResult();
                while (dr.Read())
                {
                    Console.WriteLine(dr["DeptName"]);
                }

                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();

        }

        static void MARS()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKJan22;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Departments";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read())
            {
                Console.WriteLine(   (drDepts["DeptName"]));

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    Console.WriteLine( ("    " + drEmps["Name"]));
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();

        }

        static void CallFuncReturningSqlDataReader()
        {
            SqlDataReader dr = GetDataReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[1]);
            }
            dr.Close();
            Console.ReadLine();
        }
        static SqlDataReader GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "select * from Employees ";


            SqlDataReader dr = cmdInsert.ExecuteReader(CommandBehavior.CloseConnection);
            //SqlDataReader dr = cmdInsert.ExecuteReader();
            //dr.Close();
            //cn.Close();

            return dr;
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

    }
}
