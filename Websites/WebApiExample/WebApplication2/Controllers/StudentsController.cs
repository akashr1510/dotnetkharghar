using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentsController : ApiController
    {
        // GET: api/Students
        public IEnumerable<Student> Get()
        {
            List<Student> lstStudents = new List<Student>();

            //read values from db

            return lstStudents;

            //return new string[] { "value1", "value2" };
        }

        // GET: api/Students/5
        public Student Get(int id)
        {
            Student obj = new Student();
            //read from db
            return obj;
        }

        // POST: api/Students
        public void Post([FromBody] Student value)
        {

            //insert into db
        }

        // PUT: api/Students/5
        public void Put(int id, [FromBody] Student value)
        {
            //update in db
        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
            //delete from db
        }
    }
}
