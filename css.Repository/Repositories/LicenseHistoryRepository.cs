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
    class LicenseHistoryRepository : Repository<tbl_LicenseHistory>, ILicenseHistoryRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public LicenseHistoryRepository(DbContext context) : base(context)
        {
            // Constructor
        }
      

       public  IEnumerable<tbl_LicenseHistory> GetLicenseHistoryViaCompany(int CompanyID)
        {
            try
            {
                var y = cssDbContext.tbl_LicenseHistory.Where(x => x.companyId == CompanyID).ToList();
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
