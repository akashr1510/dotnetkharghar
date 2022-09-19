using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsyncControllerExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            ServiceReference1.Service1Client o = new ServiceReference1.Service1Client();

            ServiceReference1.Service1Client o2 = new ServiceReference1.Service1Client();

            ViewBag.BeforeTime = DateTime.Now.ToLongTimeString();
            ViewBag.Result1 = o.DoWork();
            ViewBag.Result2 = o2.DoWork();
            ViewBag.AfterTime = DateTime.Now.ToLongTimeString();


            return View();
        }
        //public ActionResult Index()
        //{
        //    ServiceReference1.Service1Client o = new ServiceReference1.Service1Client();

        //    o.DoWorkCompleted += O_DoWorkCompleted;
        //    o.DoWorkAsync();
        //    return View();
        //}

        //private void O_DoWorkCompleted(object sender, ServiceReference1.DoWorkCompletedEventArgs e)
        //{
        //    ViewBag.retval = e.Result;
        //}
    }
}