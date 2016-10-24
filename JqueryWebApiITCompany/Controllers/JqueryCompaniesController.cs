using JqueryWebApiITCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JqueryWebApiITCompany.Controllers
{
    public class JqueryCompaniesController : ApiController
    {
        static readonly ICompanyRepository companyRepository = new CompanyRepository();

        public IEnumerable<Company> GetAllCompany()
        {
            return companyRepository.GetAll();
        }

        public HttpResponseMessage GetCompanies(int id)
        {
            Company company = companyRepository.Get(id);
            if(company == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Company not found for the given Id");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, company);
            }
        }

        public HttpResponseMessage PostCompany(Company company)
        {           
            company = companyRepository.Add(company);
            var response = Request.CreateResponse<Company>(HttpStatusCode.Created, company);
            string uri = Url.Link("DefaultApi", new { id = company.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage PutCompany(int id, Company company)
        {
            //company.Id = id;
            if (!companyRepository.Update(id, company))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to update the student for the given Id");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        public HttpResponseMessage DeleteCompany(int id)
        {
            companyRepository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
