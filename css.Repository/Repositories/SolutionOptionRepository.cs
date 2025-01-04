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
   public class SolutionOptionRepository : Repository<tbl_SolutionOptions>, ISolutionOptionsRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public SolutionOptionRepository(DbContext context) : base(context)
        {
            // Constructor
        }
        public IEnumerable<tbl_SolutionOptions> GetSolutionOptionsViaRequest(int requestId)
        {
            return cssDbContext.tbl_SolutionOptions.Where(x => x.request_id == requestId).ToList();
        }

        //public IEnumerable<tbl_SolutionOptions> RemoveSolutionOptionsViaSolution(int SolutionId)
        //{
        //    return cssDbContext.tbl_SolutionOptions.RemoveRange(x => x.solution_id == SolutionId);
        //}

    }
}
