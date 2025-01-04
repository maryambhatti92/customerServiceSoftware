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
    public interface IDiagnosisRepository : IRepository<tbl_Diagnosis>
    {
        IEnumerable<tbl_Diagnosis> GetActiveDiagnosis();
        IEnumerable<tbl_Diagnosis> GetDiagnosisCompanyVise(int companyID);
    }
}
