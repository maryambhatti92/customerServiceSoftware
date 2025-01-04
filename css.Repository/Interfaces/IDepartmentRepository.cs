using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Repository.Interfaces
{
    public interface IDepartmentRepository : IRepository<tbl_Departments>
    {
        tbl_Departments GetOneDepartment(int ID);
        IEnumerable<tbl_Departments> GetDepartViaCompany(int CompanyID, int Lang);
    }
}

