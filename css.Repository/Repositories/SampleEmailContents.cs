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

    
    public class SampleEmailContentsRepository : Repository<SampleEmailContent>, ISampleEmailContentsRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public SampleEmailContentsRepository(DbContext context) : base(context)
        {
            // Constructor
        }
    }
}
