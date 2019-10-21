using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class accountController : Controller
    {
        // GET: account
        public ActionResult Index()
        {
           using (Ourdbcontext db =new Ourdbcontext())
            {
                return View(db.useraccount.ToList());
            }
        }
        public  ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(useraccount account)
        {
            if (ModelState.IsValid)
            {
                using (Ourdbcontext db = new Ourdbcontext())
                {
                    db.useraccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + "sucessfully registered.";
            }
            return View();
        }
            //login methods//
            public ActionResult Login()
            {
                return View();
            }
        [HttpPost]
        public ActionResult Login(useraccount User)
        {
            using (Ourdbcontext db =new Ourdbcontext())
            {
                var usr = db.useraccount.Single(u => u.UserName == User.UserName && u.Password == User.Password);
                if(usr !=null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("Loggedin");
                }
                else
                {
                    ModelState.AddModelError("", "check credentials");
                }
            }
            return View();
        }

     public ActionResult Loggedin()
        {
            if(Session["UserId"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}