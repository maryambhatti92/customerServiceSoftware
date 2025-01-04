using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Repository.Interfaces
{
    public interface IContactPersonRepository : IRepository<tbl_contact_person>
    {
        IEnumerable<tbl_contact_person> GetContactViatblCustomer(int customerId);
        tbl_contact_person GetSingleContactViatblCustomer(int customerId);
    }
}
