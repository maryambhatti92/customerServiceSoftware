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
    public interface ICustomerRepository : IRepository<tbl_customer>
    {
        tbl_customer GetCustomerViatblRequest(int requestId);

    }
}
