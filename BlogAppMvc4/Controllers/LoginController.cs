using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogAppMvc4.DatabaseContext;
using BlogAppMvc4.Models.User;

namespace BlogAppMvc4.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private MyBlogContext _db = new MyBlogContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register model)
        {
            try
            {
                if (ModelState.IsValid)
                {  
                    _db.Users.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Login");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogIn model)
        {
            if (ModelState.IsValid)
            {
                //if (model.Username == "jed" && model.Password == "albao") // Simulate data store call where Username/Password

                if (DataAccess.DAL.UserIsValid(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("OpinView", "Opinions");
                }
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("OpinView", "Opinions");
        }
    }
}
