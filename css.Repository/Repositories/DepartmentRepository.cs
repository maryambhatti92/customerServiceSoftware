using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;
using css.Repository.Interfaces;
using System.Data.Entity;

namespace css.Repository.Repositories
{
    public class DepartmentRepository : Repository<tbl_Departments>, IDepartmentRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public DepartmentRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public tbl_Departments GetOneDepartment(int ID)
        {
            return cssDbContext.tbl_Departments.Where(x => x.DepartmentID == ID).FirstOrDefault();
        }


        public  IEnumerable<tbl_Departments> GetDepartViaCompany(int CompanyID,int Lang)
        {
            return cssDbContext.tbl_Departments.Where(x => x.Company_ID == CompanyID &&  x.LanguageID == Lang).ToList();
        }
    }
}
