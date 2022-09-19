using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsyncControllerExample.Controllers
{
    public class DefaultController : AsyncController
    {
        // GET: Default
        public void IndexAsync()
        {
            ViewBag.BeforeTime = DateTime.Now.ToLongTimeString();
            ServiceReference1.Service1Client o1 = new ServiceReference1.Service1Client();
            o1.DoWorkCompleted += O1_DoWorkCompleted;
            o1.DoWorkAsync();
            AsyncManager.OutstandingOperations.Increment();

            ServiceReference1.Service1Client o2 = new ServiceReference1.Service1Client();
            o2.DoWorkCompleted += O2_DoWorkCompleted;
            o2.DoWorkAsync();
            AsyncManager.OutstandingOperations.Increment();
        }
        private void O1_DoWorkCompleted(object sender, ServiceReference1.DoWorkCompletedEventArgs e)
        {
            ViewBag.Result1 = e.Result;
            AsyncManager.OutstandingOperations.Decrement();

        }
        private void O2_DoWorkCompleted(object sender, ServiceReference1.DoWorkCompletedEventArgs e)
        {
            ViewBag.Result2 = e.Result;
            AsyncManager.OutstandingOperations.Decrement();

        }

        public ActionResult IndexCompleted()
        {
            ViewBag.AfterTime = DateTime.Now.ToLongTimeString();
            return View();
        }
    }
}