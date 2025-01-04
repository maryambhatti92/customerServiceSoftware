using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using css.Data.Models;
using css.Shared.ViewModels;
using SequwareWebapp.WebHelper;
using System.Net.Http;
using OfficeOpenXml;
using System.Text;
//using IronPdf;

namespace SequwareWebapp.Controllers
{
    public class SolutionReportController : Controller
    {
       

        // GET: SolutionReport
        public ActionResult SolutionReport(int id, int companyid, int LangID)
        {
            //if (Session["Language"] != null)
            //{
                
            
            ServiceFormVM serviceinfo = new ServiceFormVM();
            serviceinfo = LoadServiceInfoDataPerformance(id, companyid, LangID);
            //serviceinfo.status = loadbasicDataCmbStatus();
            if (serviceinfo.orderData == null)
            {
                tbl_OrderData ord = new tbl_OrderData();
                serviceinfo.orderData = ord;
            }
            if (serviceinfo.inspectionData == null)
            {
                tbl_Inspection ins = new tbl_Inspection();
                serviceinfo.inspectionData = ins;
            }
                if (serviceinfo.solutionData == null)
                {                    
                        tbl_Solution sol = new tbl_Solution();
                        serviceinfo.solutionData.solution = sol;                    
                }
            if (serviceinfo.completionData == null)
            {
                tbl_Completion comp = new tbl_Completion();
                serviceinfo.completionData = comp;
            }
            serviceinfo.issues = LoadIssueCMB(LangID.ToString());
            {
                if (serviceinfo.issues != null)
                {
                    serviceinfo.ProblemDescriptionIssue = serviceinfo.issues.Where(x => x.Issue_ID == serviceinfo.customerRequest.issue).FirstOrDefault().Issue;
                }

            }
            if (serviceinfo.diagnosis != null && serviceinfo.inspectionData.Diagnosis != null)
            {
                serviceinfo.Diagnosis = serviceinfo.diagnosis.Where(x => x.DiagnosisID == serviceinfo.inspectionData.Diagnosis).FirstOrDefault().Diagnosis;
            }
            if (serviceinfo.serviceTask != null && serviceinfo.inspectionData.ServiceTask !=null)
            {
                serviceinfo.ServiceTask = serviceinfo.serviceTask.Where(x => x.DiagnosisCatID == serviceinfo.inspectionData.ServiceTask).FirstOrDefault().Categories;
            }

                if (LangID == 1)
                {
                    return PartialView("SolutionReportView", serviceinfo);
                }
                else
                {
                    return PartialView("SolutionReportView-DE", serviceinfo);
                }
                
            //}
            //else
            //{
            //    return View("~/Views/Login/Login.cshtml");
            //}
        }

        public static ServiceFormVM LoadServiceInfoDataPerformance(int RequestID, int companyID, int langID)
        {
            ServiceFormVM fillfields = new ServiceFormVM();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    // client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_BasicData/GetAllServiceForm?requestID=" + RequestID.ToString() + "&companyID=" + companyID + "&LangID=" + langID; ;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<ServiceFormVM>().Result;
                        return fillfields;
                    }

                    return fillfields;


                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return fillfields;
            }


        }

        public static IEnumerable<tbl_ProblemDescriptionIssue> LoadIssueCMB(string LangID)
        {
            IEnumerable<tbl_ProblemDescriptionIssue> fillfields = new List<tbl_ProblemDescriptionIssue>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_Issue/GetAllIssues?LanguageID=" + LangID ;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<IEnumerable<tbl_ProblemDescriptionIssue>>().Result;
                        return fillfields;
                    }

                    return fillfields;


                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return fillfields;
            }

        }
    }
}