using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using eSankAlumni.Models;

namespace eSankAlumni.Controllers
{
    public class LoginController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }   

        public ActionResult LoginIN(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "Admin" && model.Password == "123")
                {
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or password.");
                }
            }
            return View("..\\Home\\AdminIndex", model);
        }
        public ActionResult UserDashBoard()
        {
            //return View("..\\Login\\Index");
            return View("..\\Home\\AdminIndex");
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            
            return View("..\\Home\\AdminIndex");
        }
    }
}