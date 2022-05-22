using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogEngine.Models;

namespace BlogEngine.Controllers
{
    public class BlogsController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
       
        // GET: Blogs
        public async  Task<ActionResult> Index()
        {
            
            var bloglist = _dbContext.Blogs.ToList();
            var UserID = User.Identity.Name;           
            var newlist = bloglist.Select(s => s).Where(g=>g.Author == UserID && g.IsDeleted== false).ToList();
            return View(newlist);
            //return View(_dbContext.Blogs.ToList());
        }
        public ActionResult GBlog()
        {
            var bloglist = _dbContext.Blogs.ToList();
            var newlist = bloglist.Select(s => s).Where(g =>  g.IsDeleted == false).ToList();
            return View(newlist);
        }

        [HttpGet]
        //Button Ajax call
        public HttpStatusCodeResult AjaxMethod(string id)
        {
            var bloglist = _dbContext.Blogs.ToList();
            var UserID = User.Identity.Name;
            Blog objblog = bloglist.Where(s => s.ID == Convert.ToInt32(id)).ToList().FirstOrDefault();
            objblog.LikeCount = objblog.LikeCount + 1;
            _dbContext.Entry(objblog).State = EntityState.Modified;


            Like objlike = new Like();
            objlike.BlogID = Convert.ToInt32(id);
            objlike.UserID = UserID;
            objlike.LikedON = DateTime.Now;
            _dbContext.Likes.Add(objlike);
            _dbContext.SaveChanges();
            //return RedirectToAction("GBlog");
            //return Redirect(Request.UrlReferrer.ToString());
            return new HttpStatusCodeResult(HttpStatusCode.OK,"1");
        }
        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _dbContext.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Author,Content,CreatedON")] Blog blog)
        {
            if (ModelState.IsValid)
            {

                _dbContext.Blogs.Add(blog);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _dbContext.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Author,Content,CreatedON")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(blog).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _dbContext.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = _dbContext.Blogs.Find(id);
            blog.IsDeleted = true;
            _dbContext.Entry(blog).State = EntityState.Modified;
            _dbContext.SaveChanges();

            //_dbContext.Blogs.Remove(blog);
            //_dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
