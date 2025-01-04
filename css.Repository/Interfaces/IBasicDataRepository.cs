using css.Data.Models;
using css.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace css.Repository.Interfaces
{
     public interface IBasicDataRepository : IRepository<tbl_customer>
    {
        DataTable GetBasicDatadb(string connectionString, int custid);
        DataTable GetServiceInfoDatadb(string connectionString, int requestID);
        DataTable GetServiceFormData(string connectionString, int requestID);
    }
    
}
