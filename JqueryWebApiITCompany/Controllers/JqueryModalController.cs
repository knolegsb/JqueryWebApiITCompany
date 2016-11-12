using JqueryWebApiITCompany.Models;
using JqueryWebApiITCompany.PageList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace JqueryWebApiITCompany.Controllers
{
    public class JqueryModalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JqueryModal
        public ActionResult Index(string filter = null, int page=1, int pageSize=5, string sort="Id", string sortdir="DESC")
        {
            var records = new PagedList<Company>();
            ViewBag.filter = filter;
            records.Content = db.Companies
                                    .Where(co => filter == null
                                            || co.Name.Contains(filter)
                                            || co.Industry.Contains(filter)
                                            || co.Headquarters.Contains(filter))
                                    .OrderBy(sort + " " + sortdir)
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

            records.TotalRecords = db.Companies
                                    .Where(co => filter == null
                                            || co.Name.Contains(filter)
                                            || co.Industry.Contains(filter)
                                            || co.Headquarters.Contains(filter))
                                    .Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }    
        
        // GET: /JqueryModal/Details/5
        public ActionResult Details(int id=0)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return PartialView("ModalPartials/Details", company);
        }    

        // GET: /JqueryModal/Create
        [HttpGet]
        public ActionResult Create()
        {
            var company = new Company();
            return PartialView("ModalPartials/Create", company);
        }

        // POST: /JqueryModal/Create
        [HttpPost]
        public JsonResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(company, JsonRequestBehavior.AllowGet);
        }

        // GET: /JqueryModal/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }

            return PartialView("ModalPartials/Edit", company);
        }

        // POST: /JqueryModal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("ModalPartials/Edit", company);
        }

        // GET: /JqueryModal/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return PartialView("ModalPartials/Delete", company);
        }

        // POST: /JqueryModal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}