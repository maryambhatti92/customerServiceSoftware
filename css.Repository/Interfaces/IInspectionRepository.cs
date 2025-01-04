using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Repository.Interfaces
{
    public interface IInspectionRepository : IRepository<tbl_Inspection>
    {
        tbl_Inspection GetInspectionViaRequest(int requestId);
        IEnumerable<tbl_Inspection> GetInspectionViaDiagnosis(int diagnosisId);
    }
}
