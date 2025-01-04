using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;
using css.Shared.ViewModels;
using System.Net.Http;



namespace customerServiceSoftware.TabClasses
{
  public class InspectionFunctions
    {
        public static tbl_Inspection LoadInspectionData(int RequestID)
        {
            tbl_Inspection fillfields = new tbl_Inspection();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_Inspection/GetInspection?RequestId=" + RequestID.ToString();
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

        public static string SaveInspectionData(tbl_Inspection InspectionData)
        {
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                  client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var InspectionRequest = Newtonsoft.Json.JsonConvert.SerializeObject(InspectionData);
                HttpResponseMessage response;
                if (InspectionData.InspectionID == 0)
                {
                    response = client.PostAsJsonAsync("api/_Inspection/CreateInspectionData", InspectionRequest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<tbl_Inspection>().Result;
                        return result.InspectionID.ToString();                        

                    }
                }
                else
                {
                    response = client.PutAsJsonAsync("api/_Inspection/UpdateInspection", InspectionRequest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<string>().Result;
                        if (result == "Successful")
                        {
                            return "Successful";
                        }                      

                    }
                }
               
            }




            return "Successful";
        }
    
        public static string UpdateInspectionEmailSent(tbl_Inspection InspectionData)
        {
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var InspectionRequest = Newtonsoft.Json.JsonConvert.SerializeObject(InspectionData);
                HttpResponseMessage response = client.PutAsJsonAsync("api/_Inspection/UpdateInspectionEmail", InspectionRequest).Result;
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

        public static void OpenInspectionReports()
        {

        }

        public static IEnumerable<tbl_ServiceTask> LoadServiceTaskCMB()
        {
            IEnumerable<tbl_ServiceTask> fillfields = new List<tbl_ServiceTask>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_ServiceTask/GetAllServiceTask";
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<IEnumerable<tbl_ServiceTask>>().Result;
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

        public static IEnumerable<tbl_Reason> LoadReasonCMB()
        {
            IEnumerable<tbl_Reason> fillfields = new List<tbl_Reason>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_Reason/GetAllReason";
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<IEnumerable<tbl_Reason>>().Result;
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

        public static IEnumerable<tbl_Diagnosis> LoadDiagnosisCMB()
        {
            IEnumerable<tbl_Diagnosis> fillfields = new List<tbl_Diagnosis>();
            try
            {
                int company = Convert.ToInt32(AppConfigReader.CompanyId);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_Diagnosis/GetAllDiagnosis?companyID=" + company;
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

        public static IEnumerable<tbl_Departments> LoadDepartmentsCMB()
        {
            IEnumerable<tbl_Departments> fillfields = new List<tbl_Departments>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");                    
                    string url = " api/_Department/GetDepartment";
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<IEnumerable<tbl_Departments>>().Result;
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
    
        public static tbl_Departments LoadOneDepartment(int deptID)
        {
            tbl_Departments fillfields = new tbl_Departments();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");                    
                    string url = " api/_Department/GetDepartmentbyID?deptID=" + deptID.ToString();
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<tbl_Departments>().Result;
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
