using css.Shared.ViewModels;
using css.Data.Models;
using css.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Shared;
using System.Data;
namespace css.Repository.Repositories
{   
    // Class
    public class CustomerRequestRepository : Repository<tbl_customer_request>, ICustomerRequestRepository
    {
        // It will give us DbContext from "Repository.cs" 
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public CustomerRequestRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public DataTable GetMainDatadb(string connectionString, int CompanyID)
        {           
            DataTable values = Data.AdoNet.SqlExecuter.GetMainData(connectionString, CompanyID);
            return values;
        }

        public DataTable GetArchiveDatadb(string connectionString, int companyID)
        {
            DataTable values = Data.AdoNet.SqlExecuter.GetArchiveData(connectionString, companyID);            
            return values;
        }
        public tbl_customer_request GetCustomerRequestViaRequestID(int requestId)
        {
            return cssDbContext.tbl_customer_request.Where(x => x.Request_id == requestId).FirstOrDefault();
        }

        public IEnumerable<tbl_customer_request> GetCustomerRequestViaCompanyID(int ComID)
        {
            return cssDbContext.tbl_customer_request.Where(x => x.Company_ID == ComID).ToList();
        }
    }
}
