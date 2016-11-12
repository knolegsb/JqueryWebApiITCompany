using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JqueryWebApiITCompany.Models;

namespace JqueryWebApiITCompany.Controllers
{
    public class JqueryUIController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JqueryUI
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        // GET: JqueryUI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: JqueryUI/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Create()
        {
            return PartialView("CreateModal");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                TempData["msg"] = "Data saved successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            Company company = new Company();
            company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Data Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            TempData["msg"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        // POST: JqueryUI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Rank,Name,Industry,Revenue,FiscalYear,Employees,MarketCap,Headquarters")] Company company)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Companies.Add(company);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(company);
        //}

        //// GET: JqueryUI/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Company company = db.Companies.Find(id);
        //    if (company == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(company);
        //}

        //// POST: JqueryUI/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Rank,Name,Industry,Revenue,FiscalYear,Employees,MarketCap,Headquarters")] Company company)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(company).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(company);
        //}

        //// GET: JqueryUI/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Company company = db.Companies.Find(id);
        //    if (company == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(company);
        //}

        //// POST: JqueryUI/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Company company = db.Companies.Find(id);
        //    db.Companies.Remove(company);
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
