using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dividends.Models;

namespace Dividends.Controllers
{
    public class DividendsController : Controller
    {
        private DividendContext db = new DividendContext();

        // GET: Dividends
        public ActionResult Index()
        {
            return View(db.Dividends.ToList());
        }

        // GET: Dividends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dividend dividend = db.Dividends.Find(id);
            if (dividend == null)
            {
                return HttpNotFound();
            }
            return View(dividend);
        }

        //public ActionResult Details(string symbol)
        //{
        //    using (var db = new DividendContext())
        //    {
        //        var result = (from s in db.Dividends
        //                       where s.Symbol == symbol.Trim()
        //                       orderby s.Score descending
        //                       select s).FirstOrDefault();

        //        // var results = db.Dividends.Where(s => s.Symbol == symbol.Trim()).FirstOrDefault();

        //        //if (result == null)
        //        //{
        //        //    return View(new Dividend() { Symbol = $"[{symbol}] not found."});
        //        //}

        //        return View(result);
        //    }
        //}

        public ActionResult List(string name)
        {
            var result = from s in db.Dividends
                         where s.Name.Contains(name.Trim())
                         orderby s.Score descending
                         select s;

            return View(result.ToList());
        }

        public ActionResult Search(int score = 100, int streak = 0)
        {
            var result = from s in db.Dividends
                         where 
                            s.Score >= score
                            && s.UninterruptedDividendStreak >= streak
                         orderby s.Name ascending
                         select s;

            return View(result.ToList());
        }


        // GET: Dividends/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Dividends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Symbol,Name,Sector,MarketCap,Beta,DividendYield,PERatio,Score,DividendGrowthStreak,UninterruptedDividendStreak,PaymentFrequency")] Dividend dividend)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Dividends.Add(dividend);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(dividend);
        //}

        // GET: Dividends/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Dividend dividend = db.Dividends.Find(id);
        //    if (dividend == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dividend);
        //}

        // POST: Dividends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Symbol,Name,Sector,MarketCap,Beta,DividendYield,PERatio,Score,DividendGrowthStreak,UninterruptedDividendStreak,PaymentFrequency")] Dividend dividend)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dividend).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(dividend);
        //}

        // GET: Dividends/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Dividend dividend = db.Dividends.Find(id);
        //    if (dividend == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dividend);
        //}

        // POST: Dividends/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Dividend dividend = db.Dividends.Find(id);
        //    db.Dividends.Remove(dividend);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
