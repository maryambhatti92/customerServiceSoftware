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

    
    public class SampleDepartmentContentsRepository : Repository<tbl_SampleDepartments>, ISampleDEpartmentRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public SampleDepartmentContentsRepository(DbContext context) : base(context)
        {
            // Constructor
        }
    }
}
