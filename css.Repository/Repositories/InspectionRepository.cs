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
    public class InspectionRepository : Repository<tbl_Inspection>, IInspectionRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public InspectionRepository(DbContext context) : base(context)
        {
            // Constructor
        }
        public tbl_Inspection GetInspectionViaRequest(int requestId)
        {
            return cssDbContext.tbl_Inspection.Where(x => x.RequestId == requestId).FirstOrDefault();
        }
        public IEnumerable<tbl_Inspection> GetInspectionViaDiagnosis(int diagnosisId)
        {
            return cssDbContext.tbl_Inspection.Where(x => x.Diagnosis == diagnosisId).ToList();
        }

    }
}
