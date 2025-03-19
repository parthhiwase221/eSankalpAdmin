using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSankalpAdmin.Models;

using System.Web.Security;

namespace eSankalpAdmin.Controllers
{
   
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult loginIndex()
        {
            return View();
        }
        public ActionResult LogIn(LoginModel model)
        {
            if (ModelState.IsValid)
            { if (model.UserID == "Admin" && model.Password == "parth@123")
                
                {
                    FormsAuthentication.SetAuthCookie(model.UserID, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                { ModelState.AddModelError("","Invalid Username or Password"); }
            }
            return View("..\\Login\\loginIndex", model);


        }
    }
}
