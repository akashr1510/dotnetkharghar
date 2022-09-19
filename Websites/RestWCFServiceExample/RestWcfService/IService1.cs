using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {

        [OperationContract]
        [WebGet(UriTemplate = "/GetEmployeeDetails/{EmpNo}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //[WebInvoke(Method = "GET", UriTemplate = "/GetEmployeeDetails{EmpNo}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Employee GetEmployeeDetails(string EmpNo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddNewEmployee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddNewEmployee(Employee emp);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
        void UpdateEmployee(Employee emp);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteEmployee/{EmpNo}")]
        void DeleteEmployee(string EmpNo);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpNo { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Basic{ get; set; }

        [DataMember]
        public short DeptNo { get; set; }
    }
}
