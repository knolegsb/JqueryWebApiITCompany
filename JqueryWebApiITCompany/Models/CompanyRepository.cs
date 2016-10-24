using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JqueryWebApiITCompany.Models
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Company Add(Company company)
        {
            if(company == null)
            {
                throw new ArgumentNullException("item");
            }            

            db.Companies.Add(company);
            db.SaveChanges();
            return company;
        }

        public Company Get(int id)
        {
            return db.Companies.Find(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return db.Companies;
        }

        public void Remove(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
        }               

        public bool Update(int id, Company company)
        {
            
            if (company == null)
            {
                throw new ArgumentNullException("company");
            }

            if (id != company.Id)
            {
                return false;
            }

            db.Companies.Add(company);
            return true;
        }
    }
}