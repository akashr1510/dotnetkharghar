using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExample.Controllers
{
    public class ResultFilterExampleController : Controller
    {
        // GET: ResultFilterExample
        [OutputCache(Duration =60, VaryByParam ="none")]
        public string Index()
        {
            return DateTime.Now.ToString("T");
        }
        [OutputCache(Duration = 60, VaryByParam ="id")]
        public string Index2(int id= 0)
        {
            return DateTime.Now.ToString("T");
        }
    }
}