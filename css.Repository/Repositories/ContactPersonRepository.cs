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
    class ContactPersonRepository : Repository<tbl_contact_person>, IContactPersonRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public ContactPersonRepository(DbContext context) : base(context)
        {
            // Constructor
        }
        public IEnumerable<tbl_contact_person> GetContactViatblCustomer(int customerId)
        {
            return cssDbContext.tbl_contact_person.Where(x => x.customer_id == customerId).ToList();
        }

        public tbl_contact_person GetSingleContactViatblCustomer(int customerId)
        {
            return cssDbContext.tbl_contact_person.Where(x => x.customer_id == customerId).First();
        }
    }
}
