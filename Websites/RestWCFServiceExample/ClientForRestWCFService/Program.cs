using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using ClientForRestWCFService.ServiceReference1;

namespace ClientForRestWCFService
{
    class Program
    {
        //get employee
        static void Main()
        {
            WebClient proxy = new WebClient();
            string EmpNo = "1";
            string serviceURL = "http://localhost:53971/Service1.svc/GetEmployeeDetails/" + EmpNo;

            //fetch the data from the service as a byte array
            byte[] data = proxy.DownloadData(serviceURL);

            //convert the byte array into a MemoryStream
            Stream stream = new MemoryStream(data);
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(Employee));

            //use DataContractJsonSerializer to convert the stream to an Employee object(deserialize)
            Employee emp = (Employee)obj.ReadObject(stream) ;
            Console.WriteLine(emp.Name);
            
            Console.ReadLine();
        }
        //add Employee
        static void Main2()
        {
            Employee emp = new Employee { EmpNo = 12345, Name = "Vikram", Basic = 12345, DeptNo = 10 };

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Employee));
            MemoryStream mem = new MemoryStream();
            ser.WriteObject(mem, emp); //(serialize)

            string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);

            WebClient webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;

            webClient.UploadString("http://localhost:53971/Service1.svc/AddNewEmployee", "POST", data);

            Console.WriteLine("done");
            Console.ReadLine();
        }

        //edit employee
        static void Main3()
        {
            Employee emp = new Employee { EmpNo = 12345, Name = "Vikram", Basic = 12345, DeptNo = 10 };

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";

            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Employee));
            ser.WriteObject(ms, emp);

            // invoke the REST method
            client.UploadData("http://localhost:53971/Service1.svc/UpdateEmployee", "PUT", ms.ToArray());

            Console.WriteLine("done");
            Console.ReadLine();

        }

        //delete employee
        static void Main4()
        {
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";

            string EmpNo = "1";
            
            byte[] arr = new byte[0];
           
            
            client.UploadData("http://localhost:53971/Service1.svc/DeleteEmployee/" + EmpNo, "DELETE", arr);
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
