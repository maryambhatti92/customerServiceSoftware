using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using css.Data.Models;
using css.Shared.ViewModels;
using System.Net.Http;
using SequwareWebapp.WebHelper;
using System.Web.Security;
using SequwareWebapp.ActionFilters;

namespace SequwareWebapp.Controllers
{
    public class LoginDEController : Controller
    {
        // GET: Login
        
        public ActionResult LoginDE()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            try
            {
                tbl_SequawareLogin user = GetSingleUser(username, password);


                if (user != null &&
                    user.UserName == username &&
                    user.Password == password)
                {
                    tbl_Company companyDetails = GetcompanyViaID(user.Company_ID.ToString());
                    if (companyDetails != null)
                    {
                        
                        if (companyDetails.LisceneExpiryDate != null)
                        {
                            DateTime ExpiryDate = DateTime.Parse(companyDetails.LisceneExpiryDate); // Convert.ToDateTime(companyDetails.LisceneExpiryDate);
                            DateTime dt = DateTime.Now;
                            int result = DateTime.Compare(dt, ExpiryDate);
                            if (result <= 0)
                            {
                                Session["Sequware"] = user;
                                Session["CompanyId"] = user.Company_ID;
                                Session["CompanyName"] = companyDetails.Comapany_Name;
                                Session["Role"] = user.role;
                                Session["UserEmail"] = user.Email;
                                Session["Language"] = user.languageID;
                                return RedirectToAction("Cases", "Cases");
                            }
                        }
                    }
                    else
                    {
                        ViewBag.LoginMessage = "Lizenzablauf nicht festgelegt, bitte kontaktieren Sie Sequware Eigentümer!";
                        return View("LoginDE");
                    }

                    ViewBag.LoginMessage = "Warnung! Unternehmensdaten vom Eigentümer aktivieren.";
                    return View("LoginDE");
                }
                else
                {
                    ViewBag.LoginMessage = "Warnung! Benutzername oder Passwort ist falsch.";
                    return View("LoginDE");
                }

            }
            catch(Exception ex)
            {
                ViewBag.LoginMessage = "Warnung! Geben Sie das richtige Benutzernamenformat ein!";
                return View("LoginDE");
            }

        }
        [NoCacheAttribute]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

          
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("LoginDE", "LoginDE");
        }



        [NonAction]
        public tbl_SequawareLogin GetSingleUser(string email, string password)
        {
            tbl_SequawareLogin Logins = new tbl_SequawareLogin();
            Logins.UserName = email;
            Logins.Password = password;
            var x = email.Split('-');
            if (x.Count() > 1)
            {
                var id = x[1].Substring(1, x[1].Length-1);
                Logins.Company_ID = Convert.ToInt32(id);
            }

            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var LoginRequest = Newtonsoft.Json.JsonConvert.SerializeObject(Logins);
                HttpResponseMessage response = client.PostAsJsonAsync("api/_Login/GetLogin", LoginRequest).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    Logins = response.Content.ReadAsAsync<tbl_SequawareLogin>().Result;
                }
                return Logins;
            }
        }

        [NonAction]
        public tbl_Company GetcompanyViaID(string id)
        {
            tbl_Company company = new tbl_Company();


            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");               

                // Get grid data
                //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                string url = " api/_Company/GetCompanyViaID?id=" + id;
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    company = response.Content.ReadAsAsync<tbl_Company>().Result;

                }
                return company;

            }
        }

        

    }
}


