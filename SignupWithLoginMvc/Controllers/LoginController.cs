using Microsoft.AspNetCore.Mvc;
using SignupWithLoginMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Mvc;
//using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
//using ActionResult = System.Web.Mvc.ActionResult;
//using ActionResult Signup()

namespace SignupWithLoginMvc.Controllers
{
    public class LoginController : Controller
    {
        SignupLoginEntities db = new SignupLoginEntities();
        // GET: Login
        public System.Web.Mvc.ActionResult Index()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public System.Web.Mvc.ActionResult Index(user u)
        {
            var user = db.users.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
            if(user!=null)
            {
                Session["UserId"]=u.Id.ToString();
                Session["Username"]=u.username.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfully !!')</script>";
                return RedirectToAction("Index","User");

            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or Password is invalid !!')</script>";
                return View();
            }
            return View();
        }

        public System.Web.Mvc.ActionResult Signup()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public System.Web.Mvc.ActionResult Signup(user u)
        {
            if(ModelState.IsValid == true)
            {
                db.users.Add(u);
                int a = db.SaveChanges();
                if(a>0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully !!')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Register failed !!')</script>";
                }
            }
            return View();
        }

    }
}