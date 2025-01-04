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
    public interface ISolutionRepository : IRepository<tbl_Solution>
    {
       tbl_Solution GetSolutionViaRequest(int requestId);
    }
}
