using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Repository.Interfaces
{
    public interface ICompanyRepository : IRepository<tbl_Company>
    {
        tbl_Company GetCompanyWithId(int companyId);
        tbl_Company GetCompanyWithName(tbl_Company name);
        IEnumerable<tbl_Company> GetAllActiveCompany();
    }
}
