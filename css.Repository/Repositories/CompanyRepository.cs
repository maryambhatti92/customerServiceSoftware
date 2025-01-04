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
    public class CompanyRepository : Repository<tbl_Company>, ICompanyRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public CompanyRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public tbl_Company GetCompanyWithName(tbl_Company name)
        {
            try
            {
                var y = cssDbContext.tbl_Company.Where(x => x.Comapany_Name.Contains(name.Comapany_Name) && x.isActive == true).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                string errrror = ex.Message.ToString();
                throw;
            }

        }

        public tbl_Company GetCompanyWithId(int companyId)
        
        {
            try
            {
                var y = cssDbContext.tbl_Company.Where(x => x.Company_id.Equals(companyId) && x.isActive == true).FirstOrDefault();
                return y;
            }
            catch (Exception ex)
            {
                string errrror = ex.Message.ToString();
                throw;
            }

        }

        public IEnumerable<tbl_Company> GetAllActiveCompany()
        {
            try
            {
                var y = cssDbContext.tbl_Company.Where(x => x.isActive == true).ToList();
                return y;
            }
            catch (Exception ex)
            {
                string errrror = ex.Message.ToString();
                throw;
            }

        }
    }
       

}
