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
using System.Net.Mail;
using System.Net;

namespace SequwareWebapp.Controllers
{
    
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult PasswordChanged()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPasswordLink(string username, string Email)
        {
            tbl_SequawareLogin user = GetSingleUser(username);

            if (user != null &&
                user.UserName == username &&
                user.Email == Email)
            {             
                // Send email for reset password
                string resetCode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(Email, resetCode, "ResetPassword");
                string x= UpdateActivationCode(username, resetCode);
                ViewBag.LoginMessage = "Reset password link has been sent to your email.";

                return View("ForgotPassword");
            }                
            else
            {
                ViewBag.ErrorMessage = "Warning! Entered Username or Email doesnot match.";
               return View("ForgotPassword");
            }

           
        }

        [NonAction]
        public tbl_SequawareLogin GetSingleUser(string username)
        {
            tbl_SequawareLogin Logins = new tbl_SequawareLogin();
            Logins.UserName = username;           

            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var LoginRequest = Newtonsoft.Json.JsonConvert.SerializeObject(Logins);
                HttpResponseMessage response = client.PostAsJsonAsync("api/_Login/GetDataforForgetPassword", LoginRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    Logins = response.Content.ReadAsAsync<tbl_SequawareLogin>().Result;
                }
                return Logins;
            }
        }

        [NonAction]
        public string UpdateActivationCode(string username, string code)
        {
            string responceCode = "";
            tbl_SequawareLogin Logins = new tbl_SequawareLogin();
            Logins.ForgotPasswordCode = code;
            var x = username.Split('-');
            if (x.Count() > 1)
            {
                var id = x[1].Substring(1, x[1].Length - 1);
                Logins.Company_ID = Convert.ToInt32(id);
            }
            Logins.UserName = username;
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var LoginRequest = Newtonsoft.Json.JsonConvert.SerializeObject(Logins);
                HttpResponseMessage response = client.PostAsJsonAsync("api/_Login/UpdateActivationCode", LoginRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    responceCode = response.Content.ReadAsAsync<string>().Result;
                }
                return responceCode;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "ResetPassword")
        {
            var verifyUrl = "/ForgotPassword/ResetPassword" + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("customerservicesoftware460@gmail.com", "Sequware Support");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "xpurkvqedxuwpfxm"; //"Phil@345"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/><br/>We got request for reset your account password. Please click on the link below to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }


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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ResetPasswordModel model)
        {            
            var message = "";
            if (ModelState.IsValid)
            {
                if (model.NewPassword == model.ConfirmPassword)
                {
                    string res = UpdatePassword(model);
                   
                    if (res == "")
                    {
                        message = "Link Expired! Initiate forgot password request here. ";
                        ViewBag.LoginMessage = message;
                        return View("ForgotPassword");
                    }
                    ViewBag.LoginMessage = "Password Reset! Login to continue.";
                    return RedirectToAction("PasswordChanged", "ForgotPassword");

                }
                else
                {
                    message = "Entered passwords does not match";
                    ViewBag.LoginMessage = message;
                    return View("ResetPassword");
                }
            }
            else
            {
                message = "Entered passwords does not match";
                ViewBag.LoginMessage = message;
                return View("ResetPassword");
            }
            
        }


        public ActionResult ResetPassword(string id)
        {
            //Verify the reset password link
            //Find account associated with this link
            //redirect to reset password page
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            tbl_SequawareLogin user = GetUserViaCode(id);
            if (user.UserName != null)
            {
                ResetPasswordModel model = new ResetPasswordModel();
                model.ResetCode = id;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [NonAction]
        public tbl_SequawareLogin GetUserViaCode(string code)
        {
            tbl_SequawareLogin company = new tbl_SequawareLogin();


            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");               

                // Get grid data
                //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                string url = " api/_Login/GetUserViaAuthenticationCode?code=" + code;
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    company = response.Content.ReadAsAsync<tbl_SequawareLogin>().Result;

                }
                return company;

            }
        }

        [NonAction]
        public string UpdatePassword(ResetPasswordModel model)
        {
            string responceCode = "";            
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var LoginRequest = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                HttpResponseMessage response = client.PostAsJsonAsync("api/_Login/UpdatePassword", LoginRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    responceCode = response.Content.ReadAsAsync<string>().Result;
                }
                return responceCode;
            }
        }


    }


}
