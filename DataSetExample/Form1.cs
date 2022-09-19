using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetExample
{
    public partial class Form1 : Form
    {
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Employees ";

            SqlDataAdapter da = new SqlDataAdapter();
            ds = new DataSet();

            da.SelectCommand = cmd;
            da.Fill(ds, "Emps");

            cmd.CommandText = "select * from Departments ";
            da.Fill(ds, "Deps");


            //dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.DataSource = ds.Tables["Emps"];
            //dataGridView1.DataSource = ds.Tables["Deps"];




        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DataView dv = new DataView(ds.Tables["Emps"]);
            ////dv.Sort = "Name"
            //dv.RowFilter = "DeptNo=" + textBox1.Text;
            //dataGridView1.DataSource = dv;

            ds.Tables["Emps"].DefaultView.RowFilter = "DeptNo=" + textBox1.Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.Tables["Emps"].DefaultView.RowFilter = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan22;Integrated Security=True";
            cn.Open();


            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = System.Data.CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo  where EmpNo = @EmpNo";

            //SqlParameter p = new SqlParameter();
            //p.ParameterName = "@Name";
            //p.SourceColumn = "Name";
            //p.SourceVersion = DataRowVersion.Current;
            //cmdUpdate.Parameters.Add(p);

            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = System.Data.CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = System.Data.CommandType.Text;
            cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";
            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlDataAdapter da = new SqlDataAdapter();

            da.InsertCommand = cmdInsert;
            da.UpdateCommand = cmdUpdate;
            da.DeleteCommand = cmdDelete;
            da.Update(ds, "Emps");
        }
    }
}
