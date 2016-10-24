using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JqueryWebApiITCompany.Models
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company Get(int id);
        Company Add(Company student);
        void Remove(int id);
        bool Update(int id, Company student);
    }
}
