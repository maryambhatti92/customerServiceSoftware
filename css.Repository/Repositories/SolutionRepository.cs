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
   public class SolutionRepository : Repository<tbl_Solution>, ISolutionRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public SolutionRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public tbl_Solution GetSolutionViaRequest(int requestId)
        {
            return cssDbContext.tbl_Solution.Where(x => x.request_id == requestId).FirstOrDefault();
        }
    }
}
