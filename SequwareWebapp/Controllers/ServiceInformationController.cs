using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using css.Data.Models;
using css.Shared.ViewModels;
using SequwareWebapp.WebHelper;
using System.Net.Http;
using OfficeOpenXml;
using Xceed.Words.NET;
using System.Web;
using System.Text;
using Pechkin;
using Pechkin.Synchronized;
using System.Drawing.Printing;


namespace SequwareWebapp.Controllers
{
    public class ServiceInformationController : Controller
    {    
        // GET: ServiceInformation
        public ActionResult ServiceInformation(int id, int companyid)
        {
            var Prioritylist = new SelectList(new[]
                                          {
                                              new {ID="1",Name="1"},
                                              new{ID="2",Name="2"},
                                              new{ID="3",Name="3"},
                                          },
                            "ID", "Name", 1);
            ViewData["list"] = Prioritylist;

            
            
            

            if (Session["Language"] != null)
            {
                string Langid = Session["Language"].ToString();
                ServiceFormVM serviceinfo = new ServiceFormVM();
                serviceinfo = LoadServiceInfoDataPerformance(id, companyid, Langid);

                if (serviceinfo.customerRequest.priority == null)
                {
                    serviceinfo.customerRequest.priority = "";
                }

                if (serviceinfo.customerRequest.status == null)
                {
                    serviceinfo.customerRequest.status = "1";
                }
                if (serviceinfo.orderData == null)
                {
                    tbl_OrderData ord = new tbl_OrderData();
                    serviceinfo.orderData = ord;
                    
                }
                if (serviceinfo.inspectionData == null)
                {
                    tbl_Inspection ins = new tbl_Inspection();
                    serviceinfo.inspectionData = ins;
                    serviceinfo.inspectionData.ServiceTask = 0;
                    serviceinfo.inspectionData.Department =0;
                    serviceinfo.inspectionData.Diagnosis = 0;
                    serviceinfo.inspectionData.Reason = 0;
                    serviceinfo.inspectionData.Operator = "";
                    serviceinfo.inspectionData.OrderId = 0;
                    serviceinfo.inspectionData.report8DDone = "";
                    serviceinfo.inspectionData.ReportDone = "";
                    serviceinfo.inspectionData.Complaint = "";
                    serviceinfo.inspectionData.Create8DReport = "";
                    serviceinfo.inspectionData.createRp = "";
                    serviceinfo.inspectionData.Description = "";
                    serviceinfo.inspectionData.Email_Sent = 0;
                    serviceinfo.inspectionData.Operator = "";
                  

                }

                if (serviceinfo.solutionData == null)
                {
                                  
                    //List<tbl_SolutionOptions> opt = new List<tbl_SolutionOptions>();
                    tbl_Solution solu = new tbl_Solution();
                    SolutionVM sol = new SolutionVM();
                    serviceinfo.solutionData.solution = solu;
                    serviceinfo.solutionData.solution.solution_id = 0;
                    //serviceinfo.solutionData.solution = solu;
                    //serviceinfo.solutionData.options = opt;

                }

                if (serviceinfo.completionData == null)
                {
                    tbl_Completion comp = new tbl_Completion();
                    serviceinfo.completionData = comp;
                }
                serviceinfo.status = loadbasicDataCmbStatus(Langid);
                serviceinfo.issues = LoadIssueCMB(Langid);
                {
                    if (serviceinfo.customerRequest != null)
                    {

                        if (serviceinfo.customerRequest.status == null)
                        {
                            serviceinfo.customerRequest.status = "0";
                        }
                    }

                }
                if (Session["Language"].ToString() == "1")
                {
                    
                    return View(serviceinfo);
                }
                else
                {                    
                    return View("ServiceInformationDE", serviceinfo);
                }
            }
            else
            {
                return View("~/Views/Login/Login.cshtml");
            }

            
        }

        public IEnumerable<tbl_status> loadbasicDataCmbStatus(string langID)
        {
            try
            {
                //DataTable dt = new DataTable();
                // dt = opr.mainTableDataLoadData(info);

                IEnumerable<tbl_status> statusData = new List<tbl_status>();
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader
.WebServiceUrl);


                    // Get grid data
                    //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                    string url = " api/_BasicData/GetStatusDropdown?Langid=" + langID;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        statusData = response.Content.ReadAsAsync<IEnumerable<tbl_status>>().Result;
                        return statusData;
                    }
                    else
                    {
                        return statusData;
                    }



                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                IEnumerable<tbl_status> st = new List<tbl_status>();
                return st;
            }
        }

        public static IEnumerable<tbl_ProblemDescriptionIssue> LoadIssueCMB(string id)
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
                    string url = " api/_Issue/GetAllIssues?LanguageID=" + id;
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

        public static ServiceFormVM LoadServiceInfoDataPerformance(int RequestID, int companyID, string langID)
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
                    string url = " api/_BasicData/GetAllServiceForm?requestID=" + RequestID.ToString() + "&companyID=" + companyID + "&LangID=" + langID;
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

        public static tbl_contact_person LoadContactData(string RequestID)
        {
            tbl_contact_person fillfields = new tbl_contact_person();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    // client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_BasicData/GetContactDetail?requestID=" + RequestID;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<tbl_contact_person>().Result;
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

        public static tbl_Inspection LoadInspectionEmailData(string RequestID, int LangID)
        {
            tbl_Inspection fillfields = new tbl_Inspection();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    // client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_Inspection/GetInspectionEmailData?requestID=" + RequestID;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<tbl_Inspection>().Result;
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

        public ActionResult EmailSendModal(string emailCode, string refnum, string evalid)
        {
            string Custrefnum = "";
            string DearName = "";
            string bodyInfo = "";
            string ToEmail = "";

            string companyID = Session["CompanyId"].ToString();
            if (Session["Language"] != null)
            {
                int LangID = Convert.ToInt32( Session["Language"].ToString());
                Tbl_EmailContents email = new Tbl_EmailContents();
                tbl_Company companyData = LoadCompanyDataViaId(Convert.ToInt32(companyID));
                string Email = Session["UserEmail"].ToString();
                if (emailCode == "Yes" || emailCode == "No" || emailCode == "Not-Necessary" || emailCode == "Solution" || emailCode == "Evaluation")
                {
                    tbl_contact_person contactDetails = LoadContactData(refnum);
                    DearName = contactDetails.name;
                    ToEmail = contactDetails.email;

                }
                else if (emailCode == "Inspection_ExternalDept")
                {
                    tbl_Inspection Inspection = LoadInspectionEmailData(refnum,LangID);
                    if (Inspection != null)
                    {
                        DearName = Inspection.Complaint; // Complaint has dept name.
                        bodyInfo = Inspection.Operator;
                        ToEmail = Inspection.report8DDone;
                    }
                }


                email = FormEmailEdit(refnum, bodyInfo, DearName, emailCode, companyData.Phone_Num, Email, companyData.Comapany_Name, companyID, Custrefnum, evalid, LangID);
                if (emailCode == "Yes" || emailCode == "No" || emailCode == "Not-Necessary" || emailCode == "Solution" || emailCode == "Evaluation" || emailCode == "Inspection_ExternalDept")
                {
                    email.To = ToEmail;
                }               
                    if (Session["Language"].ToString() == "1")
                    {
                        return PartialView("_EmailSendModal", email);
                    }
                    else
                    {
                        return PartialView("_EmailSendModalDE", email);
                    }
                    

            }
            else
            {
                return View("~/Views/Login/Login.cshtml");
            }
        }

        public ActionResult EmailEditModal(string emailCode, string refnum, string evalid)
        {
            string Custrefnum = "";
            string DearName = "";
            string bodyInfo = "";
            if (Session["Language"] != null)
            {
                int LangID = Convert.ToInt32(Session["Language"].ToString());
                string companyID = Session["CompanyId"].ToString();
                Tbl_EmailContents email = new Tbl_EmailContents();
                tbl_Company companyData = LoadCompanyDataViaId(Convert.ToInt32(companyID));
                if (emailCode == "Yes" || emailCode == "No" || emailCode == "Not-Necessary" || emailCode == "Solution")
                {
                    tbl_contact_person contactDetails = LoadContactData(refnum);
                    DearName = contactDetails.name;

                }
                else if (emailCode == "Inspection_ExternalDept")
                {
                    tbl_Inspection Inspection = LoadInspectionEmailData(refnum, LangID);
                    if (Inspection != null)
                    {
                        DearName = Inspection.Complaint; // Complaint has dept name.
                        bodyInfo = Inspection.Operator;
                    }
                }
                else if (emailCode == "Evaluation")
                {

                }
                string Email = Session["UserEmail"].ToString();
                email = FormEmailEdit(refnum, bodyInfo, DearName, emailCode, companyData.Phone_Num, Email, companyData.Comapany_Name, companyID, Custrefnum, evalid, LangID);
                if (Session["Language"].ToString() == "1")
                {
                    return PartialView("_EmailEditModal", email);
                }
                else
                {
                    return PartialView("_EmailEditModalDE", email);
                }
               
            }
            else
            {
                return View("~/Views/Login/Login.cshtml");
            }
        }


        public Tbl_EmailContents FormEmailEdit(string refNum, string bodyInfo, string DearName, string EmailCode,  string phone, string Email, string companyName, string companyId, string custRef, string evalid, int LangID)
        {
            Tbl_EmailContents Final_Email = new Tbl_EmailContents();
            Tbl_EmailContents Email_Obj = LoadEmailData(EmailCode, companyId, LangID);

            Final_Email.Subject = Email_Obj.Subject.Replace("{Refnum}", "RMA" + refNum);
            Final_Email.Email_Code = EmailCode;
            Final_Email.RMA  = Email_Obj.RMA + " : " + refNum;
            Final_Email.Reference = Email_Obj.Reference + " : " + custRef;
            Final_Email.Date = Email_Obj.Date + " : " + DateTime.Now;
            Final_Email.Dear = Email_Obj.Dear + " : " + DearName;
            Final_Email.Signature = Email_Obj.Signature;
            Final_Email.Footer = Email_Obj.Footer.Replace("{Phone}", phone);
            Final_Email.Footer = Final_Email.Footer.Replace("{email}", Email);
            if (EmailCode == "Yes" || EmailCode == "No" || EmailCode == "Not-Necessary")
            {
                Final_Email.Email_text = Email_Obj.Email_text;               
            }
            else if (EmailCode == "Inspection_ExternalDept")
            {
                Final_Email.Email_text = Email_Obj.Email_text.Replace("{Task}", bodyInfo + Environment.NewLine);
            }
            else
            {                
                if (EmailCode == "Evaluation")
                {
                    string url = WebConfigReader.CompletionEvalutionUrl + "?eval=" + evalid;
                    Email_Obj.Email_text = Email_Obj.Email_text.Replace("{Link}", "\n " + url + "\n");
                    Email_Obj.Email_text = Email_Obj.Email_text.Replace("{company} ", companyName + " ");

                    Final_Email.Email_text = Email_Obj.Email_text;
                }
                else
                {
                    Final_Email.Email_text = Email_Obj.Email_text;//+ " : " + bodyInfo + Environment.NewLine; // + x[1] + " : ";
                }
              
            }
           

            return Final_Email;
        }

        private void EmailUpdate(object sender, EventArgs e)
        {
            //DialogResult m = MessageBox.Show("Do You want to continue?", "Email Update", MessageBoxButtons.YesNo);
            //if (m == DialogResult.Yes)
            //{
            //    bool check = EmailEdit_validation();
            //    if (check)
            //    {

            //        Tbl_EmailContents EmailContent = new Tbl_EmailContents();
            //        EmailContent.RMA = (txtRMA.Text).Split(':')[0].ToString();
            //        EmailContent.Reference = (txtRefernce.Text).Split(':')[0].ToString();
            //        EmailContent.Date = (txtDate.Text).Split(':')[0].ToString();
            //        EmailContent.Dear = (txtDear.Text).Split(':')[0].ToString();
            //        if (txtEmailCode.Text == "Yes")
            //        {
            //            EmailContent.Email_text = txtBody.Text;
            //            EmailContent.Footer = (txtFooter.Text).Split(':')[0].ToString();
            //        }
            //        else
            //        {
            //            EmailContent.Footer = txtFooter.Text;

            //            if (txtEmailCode.Text == "Evaluation")
            //            {
            //                //var x = (txtBody.Text).Split('-');
            //                EmailContent.Email_text = txtBody.Text;
            //            }
            //            else
            //            {
            //                var x = (txtBody.Text).Split('\n');
            //                EmailContent.Email_text = x[0].Split(':')[0] + ":" + x[1];
            //            }
            //        }
            //        EmailContent.Signature = txtSignature.Text;
            //        EmailContent.Email_Code = txtEmailCode.Text;
            //        EmailContent.Company_ID = Convert.ToInt32(AppConfigReader.CompanyId);
            //        string Message = TabClasses.EmailOPerations.UpdateEmail(EmailContent);
            //        MessageBox.Show(Message);
            //    }
            //}
        }

        public static Tbl_EmailContents LoadEmailData(string Code, String Companyid, int langID )
        {
            Tbl_EmailContents fillfields = new Tbl_EmailContents();
            
            
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    
                    string url = " api/_Email/GetEmailContent?Code=" + Code + "&companyID=" + Companyid + "&LangID=" + langID;
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

        public static string UpdateEmail(Tbl_EmailContents EmailContent, string id, string LangID)
        {
            EmailContent.Company_ID = Convert.ToInt32(id);            

            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
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

        public static string CreateBodyText(string ref_num, string Customer, string EmailCode, string RMA, string phone, string Email, string companyName, string Evaluation, string companyid, int LangID)
        {
           
            Tbl_EmailContents Email_Obj = LoadEmailData(EmailCode, companyid, LangID);

            // txtEmailCode.Text = EmailCode;
            string emailText = Email_Obj.Email_text;
            if (EmailCode == "Evaluation")
            {
                string url = WebConfigReader.CompletionEvalutionUrl + "?eval=" + Evaluation;
                emailText = emailText.Replace("\n \nLink here \n\n\n", "\n " + url + "\n\n\n");
                var x = Email_Obj.Email_text.Split(':');
                if (x.Count() > 1)
                {

                    emailText = x[0] + " " + companyName + " " + x[1] + " " + Environment.NewLine + Evaluation + Environment.NewLine + x[2];



                }
            }
            string EmailBody = Email_Obj.RMA + " : " + RMA + Environment.NewLine +
                                Email_Obj.Reference + " : " + ref_num + Environment.NewLine +
                                Email_Obj.Date + " : " + DateTime.Now + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Dear + " : " + Customer + Environment.NewLine + Environment.NewLine +
                                emailText + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Footer + " : Phone - " + phone + " And Email - " + Email + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Signature;

            return EmailBody;
        }

        public static string CreateInspectionBodyText(string ref_num, string department, string service, string EmailCode, string RMA, string operatorname, string companyid, int LangID)
        {

            Tbl_EmailContents Email_Obj = LoadEmailData(EmailCode, companyid, LangID);
            var x = Email_Obj.Email_text.Split(':');
            // txtEmailCode.Text = EmailCode;
            string EmailBody = Email_Obj.RMA + " : " + RMA + Environment.NewLine +
                                Email_Obj.Reference + " : " + ref_num + Environment.NewLine +
                                Email_Obj.Date + " : " + DateTime.Now + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Dear + " : " + department + Environment.NewLine + Environment.NewLine +
                                x[0] + " : " + service + Environment.NewLine + x[1] + " : " + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Footer + " " + operatorname + Environment.NewLine + Environment.NewLine +
                                Email_Obj.Signature;

            return EmailBody;
        }

       public static tbl_Company LoadCompanyDataViaId(int Comapnyid)
        {
            tbl_Company fillfields = new tbl_Company();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(WebConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_Company/GetCompanyViaID/?id=" + Comapnyid.ToString();
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<tbl_Company>().Result;
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

        public ActionResult AddServiceCase()
        {
            string id = Session["Language"].ToString();
           IEnumerable<tbl_ProblemDescriptionIssue> issues = LoadIssueCMB(id);
            if (Session["Language"].ToString() == "1")
            {
                return View("AddServiceCase",issues);
            }
            else
            {
                return View("AddServiceCase-DE", issues);
            }
           
        }

        public ActionResult CreatInspectionReport(string format)
        {
            string handle = Guid.NewGuid().ToString();
            string name = "";
            if (format == "Excel")
            {
                // Validate the Model is correct and contains valid data
                // Generate your report output based on the model parameters
                // This can be an Excel, PDF, Word file - whatever you need.

                // As an example lets assume we've generated an EPPlus ExcelPackage
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage excelEngine = new ExcelPackage();
                // Do something to populate your workbook


                // Generate a new unique identifier against which the file can be stored


                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    excelEngine.Workbook.Worksheets.Add("sheet1");
                    excelEngine.SaveAs(memoryStream);
                    memoryStream.Position = 0;
                    TempData[handle] = memoryStream.ToArray();
                    name = "InspectionReport.xlsx";
                }
            }


            else
            {
                             

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {                   
                    DocX doc = DocX.Create(memoryStream);
                    memoryStream.Position = 0;
                    TempData[handle] = memoryStream.ToArray();
                    name = "InspectionReport.docx";
                }
            }

            var Data = new { FileGuid = handle, FileName = name };
            return Json (Data, JsonRequestBehavior.AllowGet);

           

        }

        //void printSolPdf(SolutionVM solution, int id, int companyid)
        //{

        //    ServiceFormVM serviceinfo = new ServiceFormVM();
        //    serviceinfo = LoadServiceInfoDataPerformance(id, companyid);

        //    string original = System.IO.File.ReadAllText(@"~\templates\temp1.html", Encoding.UTF8);
        //    string updated = original;
        //    string handle = Guid.NewGuid().ToString();
        //    //   string randomTempFileName = UriPath + "\\files\\Customer_Request_" + txtService.Text + "\\" + "Infopaket_EN" + ".html";
        //    // string randomTempFileNamePDF = UriPath + "\\files\\Customer_Request_" + txtService.Text + "\\" + "Info-PDF" + ".pdf";

        //    //  string randomTempFileName = Path.GetTempFileName() + ".html";
        //    //string randomTempFileNamePDF = Path.GetTempFileName() + ".pdf";//

        //    updated = updated.Replace("(RMA)", txtService.Text);
        //    updated = updated.Replace("(RMA-Nr.) (tt.mm.yyyy)", "RMA Number:   " + txtService.Text + "    Service Request Date: " + txtDateofEntry.Text);
        //    updated = updated.Replace("(tt.mm.yyyy)", dt_Ord_DeliveryDate.Value.ToString());
        //    updated = updated.Replace("(Date of Entry)", txtDateofEntry.Text);
        //    updated = updated.Replace("(Customer Reference Number)", textRefnumb.Text);
        //    updated = updated.Replace("(Company)", textcompany.Text);
        //    updated = updated.Replace("(Street)", textstreet.Text);
        //    updated = updated.Replace("(Zip Code and city)", textzip.Text);
        //    updated = updated.Replace("(Country)", textcountry.Text);

        //    updated = updated.Replace("(Name)", txtcp1Name.Text);
        //    updated = updated.Replace("(Email)", txtcp1Email.Text);
        //    updated = updated.Replace("(Phone)", txtcp1Phone.Text);

        //    updated = updated.Replace("(Service Request)", cmbIssues.Text);
        //    updated = updated.Replace("(Reason from problem description)", txtReason.Text);
        //    updated = updated.Replace(" (from original quantity)", Txt_ord_Orignal_Quantity.Text);

        //    updated = updated.Replace("(From Diagnosis and Diagnosis Type Box)", cmb_Ins_Diagnosis.Text + " & " + cmb_Ins_ServiceTask.Text);
        //    updated = updated.Replace("(From Description Textbox in Inspection section)", txt_ins_Desc.Text);

        //    //Console.OutputEncoding = System.Text.Encoding.UTF8;
        //    string OptionStr = "";
        //    foreach (var options in solution.options)
        //    {
        //        OptionStr = OptionStr + "<tr><td width=\"312\" style=\"border-bottom:1pt solid black; \"><p>" + options.Options + ":</p></td> <td width =\"168\" style=\"border-bottom:1pt solid black; \"><p>" + options.price + " EUR</p></td></tr>";
        //    }
        //    updated = updated.Replace("<tr>(options)</tr>", OptionStr);


        //    using (System.IO.StreamWriter writetext = new System.IO.StreamWriter("Info-PDF.xlsx"))
        //    {
        //        writetext.Write(updated);
        //    }

        //    /// System.IO.File.WriteAllText(@"C:\Users\hp1\Desktop\templateupdated.html", updated);

        //    var startinfo = new ProcessStartInfo( @"~\wkhtmltopdf\wkhtmltopdf.exe")
        //    {
        //        WindowStyle = ProcessWindowStyle.Normal,
        //        CreateNoWindow = true,
        //        UseShellExecute = false,
        //        RedirectStandardOutput = true,
        //        RedirectStandardError = true,
        //        Arguments = string.Format(" --load-error-handling ignore {0} {1} ", "Info-PDF.xlsx", handle)
        //    };

        //    var Data = new { FileGuid = handle, FileName = "Info-PDF.xlsx" };
        //    return Json(Data, JsonRequestBehavior.AllowGet);
        //}


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


        public void CreateSolutionReport(string reqid, string compId, string LangID)
        {
            
            // If using Professional version, put your serial key below.
            //ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            // Load input HTML file.
            var link = new Uri(WebConfigReader.LiveSiteUrlssl) + "SolutionReport/SolutionReport?id=" + reqid + "&companyid=" + compId + "&LangID=" + LangID; ;
          //  var link = new Uri(WebConfigReader.LiveSiteUrl) + "SolutionReport/SolutionReport?id=" + reqid + "&companyid=" + compId;

            // create global configuration object
            Pechkin.GlobalConfig gc = new GlobalConfig();

            // set it up using fluent notation
            // Remember to import the following type:;\

            //     using System.Drawing.Printing;
            //
            // a new instance of Margins with 1-inch margins.
            gc.SetMargins(new Margins(100, 100, 100, 100))
                .SetDocumentTitle("Inspection Report")
                .SetPaperSize(PaperKind.Letter)
            // Set to landscape
            //.SetPaperOrientation(true)
            ;

            // Create converter
            IPechkin pechkin = new SynchronizedPechkin(gc);

            // Create document configuration object
            ObjectConfig configuration = new ObjectConfig();

            // and set it up using fluent notation too
            configuration.SetCreateExternalLinks(false)
                .SetFallbackEncoding(Encoding.ASCII)
                .SetLoadImages(true)
                .SetPageUri(link);         
            byte[] pdfContent = pechkin.Convert(configuration);


            // Clears all content output from the buffer stream                 
            Response.Clear();
            // Gets or sets the HTTP MIME type of the output stream.
            Response.ContentType = "application/pdf";
            // Adds an HTTP header to the output stream
            Response.AddHeader("Content-Disposition", "attachment; filename=InfoPaketReport.pdf");

            //Gets or sets a value indicating whether to buffer output and send it after
            // the complete response is finished processing.
            Response.Buffer = true;
            // Sets the Cache-Control header to one of the values of System.Web.HttpCacheability.
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            // Writes a string of binary characters to the HTTP output stream. it write the generated bytes .
            Response.BinaryWrite(pdfContent);
            // Sends all currently buffered output to the client, stops execution of the
            // page, and raises the System.Web.HttpApplication.EndRequest event.

            Response.End();
            // Closes the socket connection to a client. it is a necessary step as you must close the response after doing work.its best approach.
            Response.Close();
            


        }


        //public ActionResult CreateSolutionReport(string reqid, string compId)
        //{
        //    var url = new Uri(WebConfigReader.LiveSiteUrl) + "SolutionReport/SolutionReport?id=" + reqid + "&companyid=" + compId;
        //    MemoryStream memory = new MemoryStream();
        //    Codaxy.WkHtmlToPdf.PdfDocument document = new Codaxy.WkHtmlToPdf.PdfDocument() { Url = url };
        //    PdfOutput output = new PdfOutput() { OutputStream = memory };

        //    PdfConvert.ConvertHtmlToPdf(document, output);
        //    memory.Position = 0;

        //    return File(memory, "application/pdf", Server.UrlEncode("InfoPaketReport.pdf"));
        //}

    }



}

