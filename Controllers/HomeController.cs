using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleNote.Context;
using SimpleNote.Models;
using SimpleNote.Dto;

namespace SimpleNote.Controllers
{
    public class HomeController : Controller
    {
        private SimpleNoteContext _context;
        public HomeController()
        {
            _context = new SimpleNoteContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Home
        public ActionResult Index()
        {
            if (Session["userName"] != null)
                return RedirectToAction("Index", "Note");
            return View();
        }

        // Signup form
        public ActionResult Signup()
        {
            return View();
        }

        // Login form
        public ActionResult Login()
        {
            return View();
        }

        // Logout button
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        // Forgot password form
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // Post: Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Signup", user);
            }
            var userInDb = _context.Users.Where(u => u.Username == user.Username).SingleOrDefault();
            if (userInDb != null)
            {
                ModelState.AddModelError("", "Username already exists, please choose another user name.");
                return View("Signup", user);
            }
            userInDb = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
            if (userInDb != null)
            {
                ModelState.AddModelError("", "Email already exists, go to login page.");
                return View("Signup", user);
            }
            user.Activation = Guid.NewGuid().ToString();
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(UserLoginDto user)
        {
            var userInDb = _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).SingleOrDefault();
            if (userInDb == null)
            {
                ModelState.AddModelError("", "Email and password do not match.");
                return View("Login", user);
            }
            //else if( userInDb.Activation.ToLower() != "activated")
            //{
            //    ModelState.AddModelError("", "Accout has not been activated. Please use the link in your email to activate your account.");
            //}
            else
            {
                Session["userName"] = userInDb.Username;
                Session["email"] = userInDb.Email;
                Session["userId"] = userInDb.Id;
                return RedirectToAction("Index", "Note");
            }
        }

        [HttpPost]
        public ActionResult ForgotPassword(UserForgotPasswordDto user)
        {
            if (!ModelState.IsValid)
            {
                return View("ForgotPassword", user);
            }
            else
            {
                var userInDb = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
                if(userInDb == null)
                {
                    ModelState.AddModelError("", "Email does not exist.");
                    return View("ForgotPassword", user);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }


    }
}