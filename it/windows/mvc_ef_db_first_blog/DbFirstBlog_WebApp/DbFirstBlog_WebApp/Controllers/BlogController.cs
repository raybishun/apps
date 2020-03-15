using System.Data;
using System.Linq;
using System.Web.Mvc;

using DbFirstBlog_WebApp.Models;

namespace DbFirstBlog_WebApp.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            using (var db = new BloggingContext())
            {
                return View(db.Blogs.ToList());
            }
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new BloggingContext())
            {
                return View(db.Blogs.Where(x => x.BlogId == id).FirstOrDefault());
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
                using (var db = new BloggingContext())
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
            using (var db = new BloggingContext())
            {
                return View(db.Blogs.Where(x => x.BlogId == id).FirstOrDefault());
            }
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Blog blog)
        {
            try
            {
                using (var db = new BloggingContext())
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
            using (var db = new BloggingContext())
            {
                return View(db.Blogs.Where(x => x.BlogId == id).FirstOrDefault());
            }
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var db = new BloggingContext())
                {
                    Blog blog = db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
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
