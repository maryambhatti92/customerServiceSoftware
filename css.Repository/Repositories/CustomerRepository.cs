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
    public class CustomerRepository : Repository<tbl_customer>, ICustomerRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public CustomerRepository(DbContext context) : base(context)
        {
            // Constructor
        }
        public tbl_customer GetCustomerViatblRequest(int requestId)
        {
            return cssDbContext.tbl_customer.Where(x => x.Customer_id == requestId).FirstOrDefault();
        }
    }
}
