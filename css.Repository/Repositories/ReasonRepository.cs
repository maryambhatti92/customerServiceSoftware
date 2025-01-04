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
    public class ReasonRepository : Repository<tbl_Reason>, IReasonRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public ReasonRepository(DbContext context) : base(context)
        {
            // Constructor
        }
        public IEnumerable<tbl_Reason> GetReasonViaLang(int ID)
        {
            return cssDbContext.tbl_Reason.Where(x => x.LanguageID == ID).ToList();
        }
    }
}
