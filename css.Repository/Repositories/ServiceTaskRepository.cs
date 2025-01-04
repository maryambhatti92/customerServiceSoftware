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
    public class ServiceTaskRepository : Repository<tbl_ServiceTask>, IServiceTaskRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public ServiceTaskRepository(DbContext context) : base(context)
        {
            // Constructor
        }

        public IEnumerable<tbl_ServiceTask> GetActiveServiceTasks()
        {
            return cssDbContext.tbl_ServiceTask.Where(x => x.isDelete == false).ToList();
        }

        public tbl_ServiceTask GetOneServiceTasks(int ID)
        {
            return cssDbContext.tbl_ServiceTask.Where(x => x.DiagnosisCatID == ID).FirstOrDefault();
        }

        public IEnumerable<tbl_ServiceTask> GetStatusViaLang(int ID)
        {
            return cssDbContext.tbl_ServiceTask.Where(x => x.LangID == ID).ToList();
        }
    }
}
