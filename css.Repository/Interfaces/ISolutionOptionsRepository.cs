using css.Data.Models;
using css.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace css.Repository.Interfaces
{
    public interface ISolutionOptionsRepository : IRepository<tbl_SolutionOptions>
    {
       IEnumerable<tbl_SolutionOptions> GetSolutionOptionsViaRequest(int requestId);
       //IEnumerable<tbl_SolutionOptions> RemoveSolutionOptionsViaSolution(int SolutionId);
    }
}
