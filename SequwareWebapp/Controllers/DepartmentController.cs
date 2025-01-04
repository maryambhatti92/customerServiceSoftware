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
    
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Department()
        {
            if (Session["Language"] != null)
            {
                if (Session["Language"].ToString() == "1")
                {
                    return View();
                }
                else
                {
                    return View("DepartmentDE");
                }
            }
            else
            {
                return View("~/Views/Login/Login.cshtml");
            }
           
        }

        public ActionResult DepartmentGrid(int id)
        {
            int LangID = Convert.ToInt32(Session["Language"].ToString());
            IEnumerable<tbl_Departments> Depart = loadDepartmentGrid(id,LangID);
            if (Session["Language"].ToString() == "1")
            {
                return PartialView("_DepartmentGridView", Depart);
            }
            else
            {
                return PartialView("_DepartmentGridViewDE", Depart);
            }
            
        }

        public ActionResult LoadDeleteDepartModal (int id)
        {
            tbl_Departments depart = new tbl_Departments();
            depart.DepartmentID = id;
            if (Session["Language"].ToString() == "1")
            {
                return PartialView("_DeleteDepartmentModal", depart);
            }
            else
            {
                return PartialView("_DeleteDepartmentModalDE", depart);
            }
            
        }

        [NonAction]
        public IEnumerable<tbl_Departments> loadDepartmentGrid(int companyID, int lang)
        {
            IEnumerable<tbl_Departments> Departments = new List<tbl_Departments>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/);


                // Get grid data
                //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                string url = " api/_Department/GetDepartmentbyCompanyID?CompanyID=" + companyID + "&&Lang=" + lang;
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    Departments = response.Content.ReadAsAsync<IEnumerable<tbl_Departments>>().Result;
                }

                return Departments;
            }



        }
    }
}