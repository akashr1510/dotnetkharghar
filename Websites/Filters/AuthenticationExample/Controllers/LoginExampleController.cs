using AuthenticationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthenticationExample.Controllers
{
    public class LoginExampleController : Controller
    {
       
        [AllowAnonymous]
        // GET: LoginExample/Login
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]

        // POST: LoginExample/Login
        [HttpPost]
        public ActionResult Login(User u, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (u.UserName == "a" && u.passWord == "b")
                {
                    FormsAuthentication.SetAuthCookie(u.UserName, true); //persistent cookie

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("authenticationError", "User name or Password is wrong. Try it again");
                }
            }
            return View(u);
        }

        [Authorize]
        [HttpGet]
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
    }

}









/*

To create a custom authentication filter in ASP.NET MVC, we need to create a class 
that implements the IAuthenticationFilter Interface. This IAuthenticationFilter interface has 2 methods.
OnAuthentication
OnAuthenticationChallenge

Demo
https://www.c-sharpcorner.com/article/custom-authentication-filter-in-asp-net-mvc/
https://visualstudiomagazine.com/articles/2013/08/28/asp_net-authentication-filters.aspx
*/ 