using css.Data.Models;
using css.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace css.Repository.Interfaces
{
    // Interface
    public interface ICustomerRequestRepository : IRepository<tbl_customer_request>
    {
        DataTable GetMainDatadb(string connectionString, int CompanyID);
        DataTable GetArchiveDatadb(string connectionString, int companyID);
        tbl_customer_request GetCustomerRequestViaRequestID(int requestId);
        IEnumerable<tbl_customer_request> GetCustomerRequestViaCompanyID(int ComID);
    }  

}
