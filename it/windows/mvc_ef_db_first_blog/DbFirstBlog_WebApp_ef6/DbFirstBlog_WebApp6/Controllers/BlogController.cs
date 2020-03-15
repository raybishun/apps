using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

using DbFirstBlog_WebApp6.Models;

namespace DbFirstBlog_WebApp6.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            using (var db = new BloggingDbContext())
            {
                return View(db.Blogs.ToList());
            }
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new BloggingDbContext())
            {
                return View(db.Blogs.Where(b => b.BlogId == id).FirstOrDefault());
            }
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            try
            {
                using (var db = new BloggingDbContext())
                {
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new BloggingDbContext())
            {
                return View(db.Blogs.Where(b => b.BlogId == id).FirstOrDefault());
            }
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Blog blog)
        {
            try
            {
                using (var db = new BloggingDbContext())
                {
                    db.Entry(blog).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new BloggingDbContext())
            {
                return View(db.Blogs.Where(b => b.BlogId == id).FirstOrDefault());
            }
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var db = new BloggingDbContext())
                {
                    Blog blog = db.Blogs.Where(b => b.BlogId == id).FirstOrDefault();
                    db.Blogs.Remove(blog);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
