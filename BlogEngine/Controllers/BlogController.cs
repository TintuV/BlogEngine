using BlogEngine.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogEngine.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
            //return View();
        }
        //[HttpPost]
        //public ActionResult Create(Blog b)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        using (var ctx= new ApplicationDbContext())
        //        {
                    
        //            ctx.Blogs.Add(b);
        //            ctx.SaveChanges();
        //            return RedirectToAction("Index");

        //        }
        //    }
        //    return View();
        //}
        //public ActionResult Create()
        //{
        //    var loginUser = User.Identity.GetUserName();
        //    ViewData["UserID"] = loginUser;
          

        //    return View();
        //}
        //public ActionResult Generic()
        //{
        //    return View();
        //}
    }
}