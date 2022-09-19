using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExample.Controllers
{
    //[HandleError]
    public class ExceptionFilterExampleController : Controller
    {
        // GET: ExceptionFilterExample

        //[HandleError]
        [MyErrorHandler]
        public ActionResult Index(int ID = 0)
        {
            //some code here
            int i = 100;
            i = i / ID;
            return View();
        }
    }
}