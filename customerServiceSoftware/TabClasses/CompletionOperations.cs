using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using css.Data.Models;
using css.Shared.ViewModels;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace customerServiceSoftware.TabClasses
{
   public class CompletionOperations
    {
        public static tbl_Completion LoadCompletionData(int RequestID)
        {
            tbl_Completion fillfields = new tbl_Completion();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = "api/_Completion/GetOneCompletionData?RequestId=" + RequestID.ToString();
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<tbl_Completion>().Result;
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

        public static string SaveCompletionData(tbl_Completion CompletionData)
        {
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var OrderRequest = Newtonsoft.Json.JsonConvert.SerializeObject(CompletionData);
                HttpResponseMessage response;
                if (CompletionData.Completion_id == 0)
                {
                    response = client.PostAsJsonAsync("api/_Completion/CreateCompletionData", OrderRequest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<tbl_Completion>().Result;
                        return result.Completion_id.ToString();


                    }
                }
                else
                {
                    response = client.PutAsJsonAsync("api/_Completion/UpdateCompletionData", OrderRequest).Result;
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

        public static string UpdateCompletionEvalEmailSent(tbl_Completion EValData)
        {
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var OrderRequest = Newtonsoft.Json.JsonConvert.SerializeObject(EValData);
                HttpResponseMessage response = client.PutAsJsonAsync("api/_Completion/UpdateCompletionEmail", OrderRequest).Result;
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

    }
}
