using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;
using System.Data;
using System.Data.Entity;


using css.Repository.Interfaces;

namespace css.Repository.Repositories
{
    public class StatusRepository : Repository<tbl_status>, IstatusRepository 
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public StatusRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public IEnumerable<tbl_status> GetStatusViaLang(int LangID)
        {
            try
            {
                var y = cssDbContext.tbl_status.Where(x => x.languageID == LangID).ToList();
                return y;
            }
            catch (Exception ex)
            {
                string errrror = ex.Message.ToString();
                throw;
            }

        }
    }
}
