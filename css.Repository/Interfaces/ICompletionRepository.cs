using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Repository.Interfaces
{
    public interface ICompletionRepository : IRepository<tbl_Completion>
    {
        tbl_Completion GetCompletionViaRequest(int requestId);
    }
}
