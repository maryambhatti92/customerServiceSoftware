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
    class IssueRepository  : Repository<tbl_ProblemDescriptionIssue>, IissueRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public IssueRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public IEnumerable<tbl_ProblemDescriptionIssue> GetIssueViaLanguage(int LanguageID)
        {
            try
            {
                var y = cssDbContext.tbl_ProblemDescriptionIssue.Where(x => x.LanguageID == LanguageID).ToList();
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
