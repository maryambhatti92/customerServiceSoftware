using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Repository.Interfaces
{
    public interface IstatusRepository : IRepository<tbl_status>
    {
        IEnumerable<tbl_status> GetStatusViaLang(int langID);
    }
}
