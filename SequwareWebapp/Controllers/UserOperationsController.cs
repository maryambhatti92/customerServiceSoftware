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
    public class UserOperationsController : Controller
    {
        // GET: UserOperation
        public ActionResult Usercontrols()
        {
            if (Session["Language"] != null)
            {
                if (Session["Language"].ToString() == "1")
                {
                    return View();
                }
                else
                {
                    return View("UserControls-DE");
                }
            }
            else
            {
                return View("Login", "login");
            }

        }

        public ActionResult UsercompanyGrid(int id)
        {
            if (Session["Language"] != null)
            {
                IEnumerable<tbl_SequawareLogin> Users = loadUserGrid(id);
                if (Session["Language"].ToString() == "1")
                {
                    return PartialView("_UserControlGridView", Users);
                }
                else
                {
                    return PartialView("_UserControlGridView-DE", Users);
                }
            }
            else
            {
                return View("Login", "login");
            }

        }

        [NonAction]
        public IEnumerable<tbl_SequawareLogin> loadUserGrid(int companyID)
        {             
                IEnumerable<tbl_SequawareLogin> Users = new List<tbl_SequawareLogin>();
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/);


                    // Get grid data
                    //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                    string url = " api/_Login/GetUserViaCompany?CompanyID=" + companyID;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Users = response.Content.ReadAsAsync<IEnumerable<tbl_SequawareLogin>>().Result;                        
                    }

                    return Users;
                }
          
          

        }
    }
}