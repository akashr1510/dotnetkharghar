using LocalizationExample.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LocalizationExample.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        ResourceManager rm;
        CultureInfo ci;
       
        public ActionResult Index(string culture="mr-IN")
        {

            Person model = new Person ();
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture); //localization
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture); //globalization

            rm = new ResourceManager("Resources.Resource", System.Reflection.Assembly.Load("App_GlobalResources"));
            model.Name = rm.GetString("Name", Thread.CurrentThread.CurrentCulture);
            model.Message = rm.GetString("Message", Thread.CurrentThread.CurrentCulture);
            model.Today = DateTime.Now.ToLongDateString();

            return View(model);
        }
    }
}