using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Repository.Interfaces
{
    public interface ILicenseHistoryRepository : IRepository<tbl_LicenseHistory>
    {       
        IEnumerable<tbl_LicenseHistory> GetLicenseHistoryViaCompany (int CompanyID);
    }
}
