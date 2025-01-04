using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using css.Data.Models;
using css.Shared.ViewModels;
using SequwareWebapp.WebHelper;
using System.Net.Http;
using System.Net.Mail;
using System.Net;


namespace SequwareWebapp.Controllers
{
    public class OperationsController : Controller
    {
        // GET: Operations
        public ActionResult Operations()
        {
            if (Session["Language"] != null)
            {
                IEnumerable<tbl_Company> companies = GetOperationsGrid();
                ViewData["CompanyList"] = companies;
                if (Session["Language"].ToString() == "1")
                {
                    return View(companies);
                }
                else
                {
                    return View("Operations-DE", companies);
                }
            }
            else
            {
                return View("~/Views/Login/Login.cshtml");
            }
           
            
            
        }


        public ActionResult companyGrid()
        {

            if (Session["Language"] != null)
            {
                IEnumerable<tbl_Company> ActiveCases = GetOperationsGrid();

                if (Session["Language"].ToString() == "1")
                {
                    return PartialView("_companyGridView", ActiveCases);
                }
                else
                {
                    return PartialView("_companyGridView-DE", ActiveCases);
                }
            }
            else
            {
                return View("~/Views/Login/Login.cshtml");
            }

          
           
        }

        public ActionResult UsercompanyGrid(int id)
        {
            IEnumerable<tbl_SequawareLogin> ActiveCases = GetCompanyUsersGrid(id);
            if (Session["Language"].ToString() == "1")
            {
                return PartialView("_UsercompanyGridView", ActiveCases);
            }
            else
            {
                return PartialView("_UsercompanyGridView-DE", ActiveCases);
            }
           
        }
        [NonAction]
        public IEnumerable<tbl_Company> GetOperationsGrid()
        {
            IEnumerable<tbl_Company> Companies = new List<tbl_Company>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");               

                // Get grid data
                //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                string url = " api/_Company/GetAllCompany"; //companyID;
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    Companies = response.Content.ReadAsAsync<IEnumerable<tbl_Company>>().Result;

                }
            }
            return Companies;
        }

        [NonAction]
        public IEnumerable<tbl_SequawareLogin> GetCompanyUsersGrid( int companyID)
        {
            IEnumerable<tbl_SequawareLogin> Companies = new List<tbl_SequawareLogin>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");               

                // Get grid data
                //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                string url = "  api/_Login/GetUserViaCompany?CompanyID=" + companyID;
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    Companies = response.Content.ReadAsAsync<IEnumerable<tbl_SequawareLogin>>().Result;

                }
            }
            return Companies;
        }


        [NonAction]
        public IEnumerable<tbl_Company> GetCompanies()
        {
            IEnumerable<tbl_Company> Companies = new List<tbl_Company>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");               

                // Get grid data
                //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                string url = " api/_Company/GetAllCompany"; //companyID;
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    Companies = response.Content.ReadAsAsync<IEnumerable<tbl_Company>>().Result;

                }
            }
            return Companies;
        }

        [HttpPost]
        public ActionResult CreateUser(tbl_SequawareLogin login)
        {
            dynamic showMessageString = string.Empty;
            //tbl_SequawareLogin login = new tbl_SequawareLogin();
            //login.Email = cmpusremail;
            //login.Password = cmpuserpsw;
            //login.UserName = cmpUsernm + "-C" + addusercompany;
            //login.Company_ID = Convert.ToInt32(addusercompany);           
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var CreateLoginRequest = Newtonsoft.Json.JsonConvert.SerializeObject(login);
                HttpResponseMessage response;

                if (login.Id == 0)
                {
                   
                    response = client.PostAsJsonAsync("api/_Login/CreateLogin", CreateLoginRequest).Result;
                }
                else
                {                    
                    response = client.PostAsJsonAsync("api/_Login/UpdateLogin", CreateLoginRequest).Result;
                }
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<string>().Result;
                    if (result == "Successful") 
                    {
                        showMessageString = new
                        {
                            param1 = result                            
                        };
                        if (login.Id != 0)
                        {
                            if (Session["Language"].ToString() == "1")
                            {

                                ViewBag.SuccessMsg = "Success! User information Updated";
                                
                            }
                            else
                            {
                                ViewBag.SuccessMsg = "Erfolg! Benutzerinformationen aktualisiert";
                            }
                            return Json(showMessageString, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (Session["Language"].ToString() == "1")
                            {
                                ViewBag.SuccessMsg = "Success! New User creation sucessfull";
                                SendUserCreationEmail(login.Email, login.UserName, login.Password);
                            }
                            else
                            {
                                ViewBag.SuccessMsg = "Erfolg! Neuer Benutzer erfolgreich erstellt";
                                SendUserCreationEmailGerman(login.Email, login.UserName, login.Password);
                            }
                            return Json(showMessageString, JsonRequestBehavior.AllowGet);
                        }

                       
                    }
                  return  Json(showMessageString, JsonRequestBehavior.AllowGet);
                }

                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
        }

       
        public ActionResult LoadDeleteCompanyModal(int id)
        {
            tbl_Company company = new tbl_Company();
            company.Company_id = id;
            if (Session["Language"].ToString() == "1")
            {
                return PartialView("_DeleteCompanyModal", company);
            }
            else
            {
                return PartialView("_DeleteCompanyModal-DE", company);
            }
            
        }

       
        public ActionResult LoadDeleteUserModal(int id)
        {
            tbl_SequawareLogin User = new tbl_SequawareLogin();
            User.Id = id; if (Session["Language"].ToString() == "1")
            {
                return PartialView("_DeleteUserModal", User);
            }
            else
            {
                return PartialView("_DeleteUserModal-DE", User);
            }
            
        }

        public ActionResult LicenseRenewalModal(int companyID)
        {
            IEnumerable<tbl_LicenseHistory> Licenses = new List<tbl_LicenseHistory>();
            Licenses = LoadLicenseViaId(companyID);
            if (Session["Language"].ToString() == "1")
            {
                return PartialView("_LicenseRenewalModal", Licenses);
            }
            else
            {
                return PartialView("_LicenseRenewalModal-DE", Licenses);
            }
            
        }

        public static IEnumerable<tbl_LicenseHistory> LoadLicenseViaId(int Comapnyid)
        {
            IEnumerable<tbl_LicenseHistory> fillfields = new List<tbl_LicenseHistory>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");
                    string url = " api/_Company/GetLicenseViacmpID/?companyID=" + Comapnyid.ToString();
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<IEnumerable<tbl_LicenseHistory>>().Result;
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

        [NonAction]
        public void SendUserCreationEmail(string emailID, string username, string password)
        {
            var fromEmail = new MailAddress("customerservicesoftware460@gmail.com", "Sequware Support");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "xpurkvqedxuwpfxm"; //"Phil@345"; // Replace with actual password            

            string user = username.Split('-')[0];

            string subject = "Your Sequware Account Login";
            string body = "Hello " + user + ",<br/><br/>Thank you for your trust in Sequware. Your account is now available.<br/> Here are your login credentials: <br/><br/><br/> " +
                    "User Name: " + username + "<br/> <br/>" +
                    "Password: " + password + "  (You can reset your password in the login area) <br/><br/>" +
                    "Sequware Login-Link: <br/> https://www.sequware.com/ <br/> <br/><br/>" +
                    "If you have any questions, please let us now at support@sequware.de. <br/>" +
                    "We are available for you and appreciate your feedback.<br/> <br/>" +
                    "We wish you a wonderful experience with your new After-Sales Customer Service tool. <br/><br/> Best regards, <br/> Your Sequware Team";




            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        [NonAction]
        public void SendUserCreationEmailGerman(string emailID, string username, string password)
        {
            var fromEmail = new MailAddress("customerservicesoftware460@gmail.com", "Sequware Support");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "xpurkvqedxuwpfxm"; //"Phil@345"; // Replace with actual password            

            string user = username.Split('-')[0];

            string subject = "Ihr Sequware-Konto-Login";
            string body = "Hallo " + user + ",<br/><br/>Vielen Dank für Ihr Vertrauen in Sequware. Ihr Konto ist jetzt verfügbar.<br/> Hier sind Ihre Zugangsdaten: <br/><br/><br/> " +
                    "Nutzername: " + username + "<br/> <br/>" +
                    "Passwort: " + password + "  (Sie können Ihr Passwort im Login-Bereich zurücksetzen) <br/><br/>" +
                    "Sequware Login-Link: <br/> https://www.sequware.com/ <br/> <br/><br/>" +
                    "Wenn Sie Fragen haben, wenden Sie sich jetzt bitte an support@sequware.de. <br/>" +
                    "Wir sind für Sie erreichbar und freuen uns über Ihr Feedback.<br/> <br/>" +
                    "Wir wünschen Ihnen viel Freude mit Ihrem neuen After-Sales-Kundenservice-Tool. <br/><br/> Freundliche Grüße, <br/> lhr Sequware-Team";




            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

    }
}