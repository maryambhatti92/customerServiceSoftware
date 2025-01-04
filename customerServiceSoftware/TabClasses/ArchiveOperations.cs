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
   public class ArchiveOperations
    {
        public static IEnumerable<sp_GetArchiveGriddata_Result> loadGrid()
        {
            IEnumerable<sp_GetArchiveGriddata_Result> ArchiveData = new List<sp_GetArchiveGriddata_Result>();
            try
            {
                //DataTable dt = new DataTable();
                // dt = opr.mainTableDataLoadData(info);  
                int companyID = Convert.ToInt32(AppConfigReader.CompanyId);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");                   
                    //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                    string url = " api/_CustomerRequest/GetArchiveRequest?companyID=" + companyID;
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
