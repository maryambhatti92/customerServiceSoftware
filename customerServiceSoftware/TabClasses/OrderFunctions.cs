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
   public class OrderFunctions
    {
        public static tbl_OrderData LoadOrderData(int RequestID)
        {
            tbl_OrderData fillfields = new tbl_OrderData();
            try
            {                
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_OrderData/GetOneOrderData?RequestId=" + RequestID.ToString();
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        fillfields = response.Content.ReadAsAsync<tbl_OrderData>().Result;
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

        public static string SaveOrderData(tbl_OrderData OrderData)
        {
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var OrderRequest = Newtonsoft.Json.JsonConvert.SerializeObject(OrderData);
                HttpResponseMessage response;
                if (OrderData.Order_id == 0)
                {
                     response = client.PostAsJsonAsync("api/_OrderData/CreateOrderData", OrderRequest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<tbl_OrderData>().Result;                       
                            return result.Order_id.ToString();
                       

                    }
                }
                else
                {
                     response = client.PutAsJsonAsync("api/_OrderData/UpdateOrderData", OrderRequest).Result;
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
  
        public static string UpdateOrderEmailSent(tbl_OrderData OrderData)
        {
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                //client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var OrderRequest = Newtonsoft.Json.JsonConvert.SerializeObject(OrderData);
                HttpResponseMessage response  = client.PutAsJsonAsync("api/_OrderData/UpdateOrderEmail", OrderRequest).Result;               
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
