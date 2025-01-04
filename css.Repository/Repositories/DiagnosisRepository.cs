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
    public class DiagnosisRepository : Repository<tbl_Diagnosis>, IDiagnosisRepository
    {
        public cssDbContext cssDbContext
        {
            get { return _DbContext as cssDbContext; }
        }
        public DiagnosisRepository(DbContext context) : base(context)
        {
            // Constructor
        }
        public IEnumerable<tbl_Diagnosis> GetActiveDiagnosis()
        {
            return cssDbContext.tbl_Diagnosis.Where(x => x.isdelete == false).ToList();
        }
        public IEnumerable<tbl_Diagnosis> GetDiagnosisCompanyVise(int companyID)
        {
            return cssDbContext.tbl_Diagnosis.Where(x => x.isdelete == false && x.Company_ID == companyID).ToList();
        }
    }
}
