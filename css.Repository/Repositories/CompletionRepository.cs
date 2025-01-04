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
   public class CompletionRepository : Repository<tbl_Completion>, ICompletionRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public CompletionRepository(DbContext context) : base(context)
        {
            // Constructor
        }
        public tbl_Completion GetCompletionViaRequest(int requestId)
        {
            return cssDbContext.tbl_Completion.Where(x => x.request_id == requestId).FirstOrDefault();
        }
    }
}

