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
    public interface IServiceTaskRepository : IRepository<tbl_ServiceTask>
    {
         IEnumerable<tbl_ServiceTask> GetActiveServiceTasks();
         tbl_ServiceTask GetOneServiceTasks(int ID);
        IEnumerable<tbl_ServiceTask> GetStatusViaLang(int langID);
    }
}
