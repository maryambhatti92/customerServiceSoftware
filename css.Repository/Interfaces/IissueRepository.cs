using css.Data.Models;
using css.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace css.Repository.Interfaces
{
    public interface IissueRepository : IRepository<tbl_ProblemDescriptionIssue>
    {
        IEnumerable<tbl_ProblemDescriptionIssue> GetIssueViaLanguage(int LanguageID);
    }
}
