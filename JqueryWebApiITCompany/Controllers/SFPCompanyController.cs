using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JqueryWebApiITCompany.Models;
using PagedList;

namespace JqueryWebApiITCompany.Controllers
{
    public class SFPCompanyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SFPCompany
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.RankSortParam = String.IsNullOrEmpty(sortOrder) ? "rank_desc" : "";
            ViewBag.NameSortParam = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.DateSortParam = sortOrder == "Date" ? "date_desc" : "Date";            
            ViewBag.RevenueSortParam = sortOrder == "Revenue" ? "revenue_desc" : "Revenue";
            ViewBag.EmployeeSortParam = sortOrder == "Employee" ? "employee_desc" : "Employee";
            ViewBag.MarketCapSortParam = sortOrder == "MarketCap" ? "marketcap_desc" : "MarketCap";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var companies = from c in db.Companies
                            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                companies = companies.Where(c => c.Name.Contains(searchString)
                                              || c.Industry.Contains(searchString)
                                              || c.Headquarters.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "rank_desc":
                    companies = companies.OrderByDescending(c => c.Rank);
                    break;
                case "Name":
                    companies = companies.OrderBy(c => c.Name);
                    break;
                case "name_desc":
                    companies = companies.OrderByDescending(c => c.Name);
                    break;
                case "Date":
                    companies = companies.OrderBy(c => c.FiscalYear);
                    break;
                case "date_desc":
                    companies = companies.OrderByDescending(c => c.FiscalYear);
                    break;
                //case "Rank":
                //    companies = companies.OrderBy(c => c.Rank);
                //    break;
                //case "rank_desc":
                //    companies = companies.OrderByDescending(c => c.Rank);
                //    break;
                case "Revenue":
                    companies = companies.OrderBy(c => c.Revenue);
                    break;
                case "revenue_desc":
                    companies = companies.OrderByDescending(c => c.Revenue);
                    break;
                case "Employee":
                    companies = companies.OrderBy(c => c.Employees);
                    break;
                case "employee_desc":
                    companies = companies.OrderByDescending(c => c.Employees);
                    break;
                case "MarketCap":
                    companies = companies.OrderBy(c => c.MarketCap);
                    break;
                case "marketcap_desc":
                    companies = companies.OrderByDescending(c => c.MarketCap);
                    break;
                default:
                    companies = companies.OrderBy(c => c.Rank);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(companies.ToPagedList(pageNumber, pageSize));
        }

        // GET: SFPCompany/Details/5
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

        // GET: SFPCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SFPCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rank,Name,Industry,Revenue,FiscalYear,Employees,MarketCap,Headquarters")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: SFPCompany/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: SFPCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rank,Name,Industry,Revenue,FiscalYear,Employees,MarketCap,Headquarters")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: SFPCompany/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: SFPCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
