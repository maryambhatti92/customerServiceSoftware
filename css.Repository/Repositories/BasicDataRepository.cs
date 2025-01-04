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
   public  class BasicDataRepository : Repository<tbl_customer>, IBasicDataRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }

        public BasicDataRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public DataTable GetBasicDatadb(string connectionString,int custid)
        {
            BasicdataVM bsData = new BasicdataVM();
            DataTable values = Data.AdoNet.SqlExecuter.GetBasicData(connectionString, custid);                        
            return values;
        }

        public DataTable GetServiceInfoDatadb(string connectionString, int requestID)
        {
            DataTable values = Data.AdoNet.SqlExecuter.GetServiceInfoData(connectionString, requestID);
            return values;
        }

        public DataTable GetServiceFormData(string connectionString, int requestID)
        {
            DataTable values = Data.AdoNet.SqlExecuter.GetServiceInfoData(connectionString, requestID);
            return values;
        }
    }
}
