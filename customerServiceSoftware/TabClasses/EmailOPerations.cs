using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;
using css.Shared.ViewModels;
using System.Net.Http;
using System.Net.Mail;
using System.IO;
using Outlook = Microsoft.Office.Interop.Outlook;
//using Office = Microsoft.Office.Core;


namespace customerServiceSoftware.TabClasses
{
    public  class EmailOPerations
    {
        public static string  SendEmail(string requestID, string subject, string to, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("customerservicesoftware460@gmail.com");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("customerservicesoftware460", "Phil@345");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                SaveEmail(requestID, body, to, subject, "");
                return "Mail Sent";               
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return "Mail not Sent";
            }

        }

        public static Tbl_EmailContents LoadEmailData(string Code)
        {
            Tbl_EmailContents fillfields = new Tbl_EmailContents();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_Email/GetEmailContent?Code=" + Code + "&companyID=" +AppConfigReader.CompanyId ;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<Tbl_EmailContents>().Result;
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

        public static string UpdateEmail(Tbl_EmailContents EmailContent)
        {
            EmailContent.Company_ID = Convert.ToInt32(AppConfigReader.CompanyId);
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                   client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
               // client.BaseAddress = new Uri]("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var UpdateRequest = Newtonsoft.Json.JsonConvert.SerializeObject(EmailContent);
                HttpResponseMessage response = client.PutAsJsonAsync("api/_Email/UpdateEmailContent", UpdateRequest).Result;              
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<string>().Result;
                    if (result == "Successful")
                    {
                        return "Successful";
                    }
                }
            }




            return "Successful";
        }

        public static void SaveEmail(string requestID, string body, string to, string subject, string name)
        { try
            {

                string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
                string EmailFile = UriPath + "\\files\\Customer_Request_" + requestID + "\\" + name + ".txt";


                using (StreamWriter writer = new StreamWriter(EmailFile, true))
                {
                    writer.WriteLine("To: " + to);
                    writer.WriteLine("Subject: " + subject);
                    writer.WriteLine(body);
                }
            }

            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }

        public static string CreateBodyText(string ref_num, string Customer, string EmailCode, string RMA, string phone, string Email, string companyName, string Evaluation)
        {

            Tbl_EmailContents Email_Obj = TabClasses.EmailOPerations.LoadEmailData(EmailCode);

            // txtEmailCode.Text = EmailCode;
            string emailText = Email_Obj.Email_text;
            if (EmailCode == "Evaluation")
            {
                string url = AppConfigReader.CompletionEvalutionUrl + "?eval=" + Evaluation;
               emailText = emailText.Replace("\n \nLink here \n\n\n", "\n " + url + "\n\n\n");
                var x = Email_Obj.Email_text.Split(':');
                if (x.Count() > 1)
                {
                   
                    emailText = x[0] + " " + companyName + " " + x[1] + " " + Environment.NewLine + Evaluation + Environment.NewLine + x[2];

                    

                }               
            }
            string EmailBody =  Email_Obj.RMA + " : " + RMA + Environment.NewLine +
                                Email_Obj.Reference + " : " + ref_num + Environment.NewLine + 
                                Email_Obj.Date + " : " + DateTime.Now + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Dear + " : " + Customer + Environment.NewLine + Environment.NewLine +
                                emailText + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Footer + " : Phone - " + phone + " And Email - " + Email + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Signature;

            return EmailBody;
        }

        public static string CreateInspectionBodyText(string ref_num, string department, string service, string EmailCode, string RMA, string operatorname)
        {

            Tbl_EmailContents Email_Obj = TabClasses.EmailOPerations.LoadEmailData(EmailCode);
            var x = Email_Obj.Email_text.Split(':');
            // txtEmailCode.Text = EmailCode;
            string EmailBody = Email_Obj.RMA + " : " + RMA + Environment.NewLine +
                                Email_Obj.Reference + " : " + ref_num + Environment.NewLine +
                                Email_Obj.Date + " : " + DateTime.Now + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Dear + " : " + department + Environment.NewLine + Environment.NewLine +
                                x[0] + " : " + service + Environment.NewLine + x[1] + " : " + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Footer + " " + operatorname+ Environment.NewLine + Environment.NewLine +
                                Email_Obj.Signature;

            return EmailBody;
        }

        public static string SendOutlookEmail(string requestID, string subject, string to, string body, string name)
        {
            try
            {                
               // System.Diagnostics.Process.Start("outlook.exe");
                string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
                string EmailFile = UriPath + "\\files\\Customer_Request_" + requestID + "\\" +name + ".txt";                
                //Outlook.MailItem mailItem = (Outlook.MailItem)
                // this.Application.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Application app = new Outlook.Application();
                Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.DeleteAfterSubmit = false;
                mailItem.Subject = subject;
                mailItem.To = to;
                mailItem.Body = body;
                
                if (name.Substring(0,15) == "Solution_Email_")
                {
                  //  string file = UriPath + "\\files\\Customer_Request_" + requestID + "\\Infopaket_EN.pdf";
                  //  Attachment data = new Attachment(file);
                    mailItem.Attachments.Add(UriPath + "\\files\\Customer_Request_" + requestID + "\\Info-PDF.pdf", Outlook.OlAttachmentType.olByValue);
                }
                
                //mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
                mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
                mailItem.Display(true);

                 // force storage to sent items folder (ignore user options)
               // Outlook._NameSpace _ns = app.GetNamespace("IMAP");
               // Outlook.MAPIFolder sent = _ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
               // foreach (Outlook.MailItem item in sent.Items)
               // {

               // }
               ////   Outlook.Folder sentFolder = app.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
                //                                    //   if (sentFolder != null)
               // mailItem.SaveSentMessageFolder = sent; // override the default sent items location
            //    mailItem.Save() ;

                SaveEmail(requestID, body, to, subject, name);
                
                return "Mail Sent";
            }

            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return "Mail not Sent";
            }
        }     


    }

}

