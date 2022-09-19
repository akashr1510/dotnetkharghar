using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExample
{
    public class MyErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Log(filterContext.Exception);

            base.OnException(filterContext);
        }

        private void Log(Exception exception)
        {

            //write code here to log error to db/mail/text file etc
            Debug.Write("my handler ...." + exception.Message);
        }
    }
}