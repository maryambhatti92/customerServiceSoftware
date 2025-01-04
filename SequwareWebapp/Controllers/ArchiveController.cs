using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using css.Data.Models;
using css.Shared.ViewModels;
using SequwareWebapp.WebHelper;
using System.Net.Http;

namespace SequwareWebapp.Controllers
{
    
    public class ArchiveController : Controller
    {
        // GET: Archive
        public ActionResult Archive()
        {
            if (Session["Language"] != null)
            {
                if (Session["Language"].ToString() == "1")
                {
                    return View();
                }
                else
                {
                    return View("Archive-DE");
                }
            }
            else
            {
                return View("~/Views/Login/Login.cshtml");
            }
        }


        public ActionResult ArchiveCasesGrid()
        {
            if (Session["CompanyId"] != null)
            {
                int company = Convert.ToInt32(Session["CompanyId"].ToString());
                IEnumerable<sp_GetArchiveGriddata_Result> ArchivedCases = loadGrid(company);
                if (Session["Language"].ToString() == "1")
                {
                    return PartialView("_ArchiveGrid", ArchivedCases);
                }
                else
                {
                    return PartialView("_ArchiveGrid-DE", ArchivedCases);
                }
                
            }
            else
            {
                return View("~/Views/Login/Login.cshtml");
            }
        }
        [NonAction]
        public static IEnumerable<sp_GetArchiveGriddata_Result> loadGrid(int companyid)
        {
            IEnumerable<sp_GetArchiveGriddata_Result> ArchiveData = new List<sp_GetArchiveGriddata_Result>();
            try
            {
                //DataTable dt = new DataTable();
                // dt = opr.mainTableDataLoadData(info);  
                
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");                   
                    //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                    string url = " api/_CustomerRequest/GetArchiveRequest?companyID=" + companyid;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        ArchiveData = response.Content.ReadAsAsync<IEnumerable<sp_GetArchiveGriddata_Result>>().Result;
                        return ArchiveData;
                    }

                    return ArchiveData;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return ArchiveData;
            }

        }
    }
}

   