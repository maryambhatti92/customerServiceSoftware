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
using Newtonsoft.Json;
using SequwareWebapp.ActionFilters;

namespace SequwareWebapp.Controllers
{        
    public class CasesController : Controller
    {
        // GET: Cases
        public ActionResult Cases()
        {
            if (Session["Language"] != null)
            {
                if (Session["Language"].ToString() == "1")
            {
                return View();
            }
            else
            {
                return View("Cases-DE");
            }
            }
            else
            {
                return View("~/Views/Login/Login.cshtml");
            }
        }


        public ActionResult CasesGrid()
        {
            if (Session["CompanyId"] != null)
            {
                string companyid = Session["CompanyId"].ToString();
                IEnumerable<MainDataVM> ActiveCases = GetCasesGrid(companyid);
                if (Session["Language"].ToString() == "1")
                {
                    return PartialView("_CasesGrid", ActiveCases);
                }
                else
                {
                    return PartialView("_CasesGrid-DE", ActiveCases);
                }
            }

            else
            {
                return View("Login", "login");
            }

        }


        [NonAction]
        public IEnumerable<MainDataVM> GetCasesGrid(string companyid)
        {
           
            IEnumerable<MainDataVM> GridData = new List<MainDataVM>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");               

                // Get grid data
                //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                string url = " api/_CustomerRequest/GetMainRequest?CompanyID=" + companyid; //companyID;
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    GridData = response.Content.ReadAsAsync<IEnumerable<MainDataVM>>().Result;

                }
            }
            return GridData;
        }

        public ActionResult CopyCases(List<MainDataVM> data)
        {
            if (data != null)
            {
                List<MainDataExportVM> NewData = data.Select(x => new MainDataExportVM { Case = x.Case, Prioritisation = x.Prioritisation, Status = x.Status, Company = x.Company, ServiceReason = x.ServiceReason, Date = x.Date, LastModified = x.LastModified, Manager = x.Manager, Product = x.Product }).ToList();

                // Validate the Model is correct and contains valid data
                // Generate your report output based on the model parameters
                // This can be an Excel, PDF, Word file - whatever you need.

                // As an example lets assume we've generated an EPPlus ExcelPackage
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage excelEngine = new ExcelPackage();
                // Do something to populate your workbook


                // Generate a new unique identifier against which the file can be stored
                string handle = Guid.NewGuid().ToString();

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {

                    excelEngine.Workbook.Worksheets.Add("sheet1").Cells["A1"].LoadFromCollection(Collection: NewData, PrintHeaders: true);
                    excelEngine.SaveAs(memoryStream);
                    memoryStream.Position = 0;
                    TempData[handle] = memoryStream.ToArray();
                }

                var Data = new { FileGuid = handle, FileName = "CasesGridData.xlsx" };
                return Json(Data, JsonRequestBehavior.AllowGet);


            }
            else
                return null;
        }

        public ActionResult CopyArchiveCases(List<sp_GetArchiveGriddata_Result> data)
        {

            // Validate the Model is correct and contains valid data
            // Generate your report output based on the model parameters
            // This can be an Excel, PDF, Word file - whatever you need.

            // As an example lets assume we've generated an EPPlus ExcelPackage
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelEngine = new ExcelPackage();
            // Do something to populate your workbook


            // Generate a new unique identifier against which the file can be stored
            string handle = Guid.NewGuid().ToString();

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {

                excelEngine.Workbook.Worksheets.Add("sheet1").Cells["A1"].LoadFromCollection(Collection: data, PrintHeaders: true);
                excelEngine.SaveAs(memoryStream);
                memoryStream.Position = 0;
                TempData[handle] = memoryStream.ToArray();
            }

            var Data = new { FileGuid = handle, FileName = "ArchiveGridData.xlsx" };
            return Json(Data, JsonRequestBehavior.AllowGet);



        }

        [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                byte[] data = TempData[fileGuid] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                // Problem - Log the error, generate a blank file,
                //           redirect to another controller action - whatever fits with your application
                return new EmptyResult();
            }
        }

        public ActionResult DiagnosisModal(int companyID)
        {
            IEnumerable<tbl_Diagnosis> diagnosis = new List<tbl_Diagnosis>();
            diagnosis = LoadDiagnosisViaId(companyID);
            
                if (Session["Language"].ToString() == "1")
                {
                    return PartialView("_DiagnosisModal", diagnosis);
                }
                else
                {
                    return PartialView("_DiagnosisModal-DE", diagnosis);
                }
            
           
        }

        public static IEnumerable<tbl_Diagnosis> LoadDiagnosisViaId(int Comapnyid)
        {
            IEnumerable<tbl_Diagnosis> fillfields = new List<tbl_Diagnosis>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");
                    string url = " api/_Diagnosis/GetAllDiagnosis/?companyID=" + Comapnyid.ToString();
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<IEnumerable<tbl_Diagnosis>>().Result;
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

        public ActionResult DeleteCaseModal(int requestID)
        {
            tbl_customer_request cr = new tbl_customer_request();
            cr.Request_id = requestID;
            if (Session["Language"].ToString() == "1")
            {
                return PartialView("_DeleteCaseModal", cr);
            }
            else
            {
                return PartialView("_DeleteCaseModal-DE", cr);
            }
            
        }

        public ActionResult ArciveCaseModal(int requestID)
        {
            tbl_customer_request cr = new tbl_customer_request();
            cr.Request_id = requestID;
            if (Session["Language"].ToString() == "1")
            {
                return PartialView("_ArchiveCaseModal", cr);
            }
            else
            {
                return PartialView("_ArchiveCaseModal-DE", cr);
            }
            
        }

        public ActionResult ReactiveCaseModal(int requestID)
        {
            tbl_customer_request cr = new tbl_customer_request();
            cr.Request_id = requestID;
            return PartialView("_ReactiveCaseModal", cr);
        }
    }      
}
   