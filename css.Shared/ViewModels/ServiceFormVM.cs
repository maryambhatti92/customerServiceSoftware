using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;

namespace css.Shared.ViewModels
{
    public class ServiceFormVM
    {
        public tbl_customer_request  customerRequest { get; set; }
        public tbl_customer Customer { get; set; }
        public IEnumerable<tbl_contact_person> Contacts { get; set; }
        public tbl_OrderData orderData { get; set; }
        public tbl_Inspection inspectionData { get; set; }
        public SolutionVM solutionData { get; set; }
        public tbl_Completion completionData { get; set; }
        public IEnumerable<tbl_Departments> departments { get; set; }
        public IEnumerable<tbl_Diagnosis>diagnosis { get; set; }
        public IEnumerable<tbl_Reason> reason { get; set; }
        public IEnumerable<tbl_ServiceTask> serviceTask { get; set; }
        public IEnumerable<tbl_status> status { get; set; }
        public IEnumerable<tbl_ProblemDescriptionIssue> issues { get; set; }
        public string isArchive { get; set; }
        public string ProblemDescriptionIssue { get; set; }
        public string Diagnosis { get; set; }
        public string ServiceTask { get; set; }
        

    }
}

