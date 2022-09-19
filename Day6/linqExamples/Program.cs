using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqExamples
{

    class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static void Main1()
        {
            AddRecs();
            //var emps = from single_object in collection select select_object;
           var emps = from emp in lstEmp select emp;
            //IEnumerable<Employee> emps = from emp in lstEmp select emp;


            //foreach (Employee item in emps)
            //{
            //    Console.WriteLine(item.);
            //}

            Console.ReadLine();
        }
        static void Main2()
        {
            AddRecs();
            var emps = from emp in lstEmp select emp.Name;
            //var emps = from emp in lstEmp select emp.EmpNo;



            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
        static void Main3()
        {
            AddRecs();
            var emps = from emp in lstEmp select new { emp.Name, emp.EmpNo };
            foreach (var item in emps)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void Main4()
        {
            AddRecs();


            var emps = from emp in lstEmp
                       where emp.Basic > 10000
                       select emp;
            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000 && emp.Basic < 12000
            //           select emp;
            //var emps = from emp in lstEmp
            //           where emp.Name.StartsWith("V")
            //           select emp;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }
        static void Main5()
        {
            AddRecs();


            //var emps = from emp in lstEmp
            //           orderby emp.Name 
            //           select emp;
            //var emps = from emp in lstEmp
            //           orderby emp.Name descending
            //           select emp;

            var emps = from emp in lstEmp
                       orderby emp.DeptNo, emp.Name descending
                       select emp;


            foreach (var emp in emps)
            {
                Console.Write(emp.DeptNo  + " "  );
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }
        static void Main6()
        {
            AddRecs();

            //var emps = from emp in lstEmp
            //           join dept in lstDept
            //                 on emp.DeptNo equals dept.DeptNo
            //           select new { dept.DeptName, emp.Name };


            var emps = from emp in lstEmp
                       join dept in lstDept
                             on emp.DeptNo equals dept.DeptNo
                       select new { emp, dept };

            //foreach (var emp in emps)
            //{
            //    Console.WriteLine(emp.Name);
            //}
            foreach (var item in emps)
            {
                //item.dept.DeptName;
            }
            Console.ReadLine();
        }

        static void Main7()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       group emp by emp.DeptNo;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Key); //deptno
                foreach (var e in emp)  //e is an Employee, emp is a grouping of Employee
                {
                    Console.WriteLine("   " + e.Name);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }

        static void Main1111()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       group emp by emp.DeptNo into group1
                       select group1;


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Key); //deptno
                foreach (var e in emp)  //e is an Employee
                {
                    Console.WriteLine("   " + e.Name);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }

        static void Main9()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       group emp by emp.DeptNo into group1
                       select new { group1, Count = group1.Count(), Max = group1.Max(x => x.Basic), Min = group1.Min(x => x.Basic) };


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Count); //count
                Console.WriteLine(emp.Min); //count
                Console.WriteLine(emp.Max); //count
                //emp.group1.Key;  //DeptNo

                foreach (var e in emp.group1)  //e is an Employee
                {
                    Console.WriteLine(e.Name);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        //public override string ToString()
        //{
        //    string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
        //    return s;
        //}
    }
}
namespace LinqExamplesWithLambda
{
    class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static Employee GetEmps1(Employee obj)
        {
            return obj;
        }
        static string GetEmps2(Employee obj)
        {
            return obj.Name;
        }
        static void MainToday()
        {
            //var emps = from emp in lstEmp select emp;
            var emps1 = lstEmp.Select(GetEmps1);
            var emps1a = lstEmp.Select( emp => emp );


            //var emps = from emp in lstEmp select emp.Name;
            var emps2 = lstEmp.Select(GetEmps2);
            var emps2a = lstEmp.Select(emp => emp.Name);

            //var emps = from emp in lstEmp select new { emp.Name, emp.EmpNo};
            var emps3a = lstEmp.Select(emp => new { emp.Name, emp.EmpNo });

            var emps = from emp in lstEmp where emp.EmpNo > 5 select emp;

            var emps4a = lstEmp.Where(emp => emp.EmpNo > 5);
            var emps4b = lstEmp.Select(emp => emp).Where(emp => emp.EmpNo > 5);
            var emps4c = lstEmp.Where(emp => emp.EmpNo > 5).Select(emp => emp);

            var emps4d = lstEmp.Where(emp => emp.EmpNo > 5).Select(emp => emp.Name);
            //var emps4e = lstEmp.Select(emp => emp.Name).Where(emp => emp.EmpNo > 5); //error


        }


        static void Main0()
        {
            // var emps = from emp in lstEmp select emp;
            var emps1 = lstEmp.Select(GetEmps1);
            var emps1a = lstEmp.Select(obj => obj);


            // var emps = from emp in lstEmp select emp.Name;
            var emps2 = lstEmp.Select(GetEmps2);
            var emps2a = lstEmp.Select(obj => obj.Name);
            var emps2b = lstEmp.Select(obj => new { obj.Name, obj.EmpNo });


        }
        
       
        static void Main1()
        {
            AddRecs();


            //var emps1 = from emp in lstEmp select emp;

            //using a function
            //var emps = lstEmp.Select(GetEmps1); //GetEmps1 returns Employee
            //var emps = lstEmp.Select(GetEmps2); //GetEmps2 returns string

            //using lambdas
            //var emps = lstEmp.Select(x => x);  //return Employee
            //var emps = lstEmp.Select(x => x.Name);  //return string
            var emps = lstEmp.Select(x => new { x.EmpNo, x.Name });  //return anonymous type whch contains int, string


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }
            Console.ReadLine();
        }

        static void Main4()
        {
            AddRecs();


            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000
            //           select emp;
            //var e2 = lstEmp.Where(emp => emp.Basic > 10000).Select(emp => emp);
            var e2 = lstEmp.Where(emp => emp.Basic > 10000);
            var e3 = lstEmp.Where(emp => emp.Basic > 10000).Select(emp => emp.Name);
            var emps = lstEmp.Where(x => x.Basic > 10000).Select(x => x.Name);



            //var emps = lstEmp.Where(x => x.Basic > 10000);
            //var emps = lstEmp.Where(x => x.Basic > 10000).Select(x => new { x.EmpNo, x.Name });
            //var emps = lstEmp.Select(x => new { x.EmpNo, x.Name }).Where(x => x.Basic > 10000);  //wont work



            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000 && emp.Basic < 12000
            //           select emp;
            //var emps = from emp in lstEmp
            //           where emp.Name.StartsWith("V")
            //           select emp;

            foreach (var emp in emps)
            {
                //Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }
        static void Main5()
        {
            AddRecs();


            //var emps = from emp in lstEmp
            //           orderby emp.Name
            //           select emp; 
            //var emps = from emp in lstEmp
            //                                  orderby emp.Name descending
            //                                  select emp;

            //var emps = from emp in lstEmp
            //           orderby emp.DeptNo, emp.Name descending
            //           select emp;

            //var emps = lstEmp.OrderBy(x => x.Name).Select(x => x);
            //var emps = lstEmp.OrderBy(x => x.Name);
            //var emps = lstEmp.OrderByDescending(x => x.Name);

           var emps = lstEmp.OrderBy(x => x.DeptNo).ThenByDescending(x => x.Name);



            foreach (var emp in emps)
            {
                Console.Write(emp.DeptNo);
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }

        static void Main6()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       join dept in lstDept
                             on emp.DeptNo equals dept.DeptNo
                       select new { dept.DeptName, emp.Name };

          
            var emps2 = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp);
            var emps2a = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept);
            var emps2b = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp.DeptNo);
            var emps2c = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept.DeptName);
            var emps2d = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { emp, dept });
            var emps2e = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { emp.Name, dept.DeptName });

     
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }
        static void Main7777()
        {
            AddRecs();
            //deferred execution
            var emps = from emp in lstEmp select emp;
            
            Console.WriteLine();
            lstEmp.RemoveAt(0);


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();
            Console.WriteLine();
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "F" });
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();
        }
        static void Main()
        {
            AddRecs();
            var emps = from emp in lstEmp select emp;
            //immediate execution
            emps = emps.ToList();  //.ToArray .ToDictionary

            Console.WriteLine();
            lstEmp.RemoveAt(0);
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();
            Console.WriteLine();
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "F" });
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();
        }

        static void Main5555()
        {
            AddRecs();

            var emps = from emp in lstEmp select emp;
            //deferred execution
            lstEmp.RemoveAt(0);
            foreach (Employee item in emps)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

            lstEmp.RemoveAt(0);
            foreach (Employee item in emps)
            {
                Console.WriteLine(item.Name);
            }


            Console.ReadLine();
        }
        static void Main12345()
        {
            AddRecs();
            //Employee emp = lstEmp.Single(e => e.Basic < 5000);
            //Employee emp = lstEmp.Single(e => e.EmpNo == 1);

            Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo == 123);

            if (emp != null)
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            else
                Console.WriteLine("not found");
            Console.ReadLine();
        }

      

    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        //public override string ToString()
        //{
        //    string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
        //    return s;
        //}
    }
}