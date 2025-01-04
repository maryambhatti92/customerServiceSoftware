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
   public class CompanyOperations
    {
        public static tbl_Company LoadCompanyData()
        {
            tbl_Company fillfields = new tbl_Company();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");

                    //   int customerID = Convert.ToInt32(this.mainCustomerDataDisplay.CurrentRow.Cells[6].Value);

                    // Get grid data
                    string url = " api/_Company/GetCompany";
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

            public static tbl_Company LoadCompanyDataViaId(int Comapnyid)
            {
                tbl_Company fillfields = new tbl_Company();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
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

            public static string AddCompanyData(tbl_Company CompanyData)
        {
            ///tbl_Company CompanyData = new tbl_Company();
            //string UriPath = System.IO.Directory.GetCurrentDirectory();


            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                    var CompanyRequest = Newtonsoft.Json.JsonConvert.SerializeObject(CompanyData);
                    HttpResponseMessage response;
                    if (CompanyData.Company_id == 0)
                    {
                        response = client.PutAsJsonAsync("api/_Company/AddCompany", CompanyRequest).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsAsync<tbl_Company>().Result;
                          //  CsvWriter.WriteFile(UriPath, CompanyRequest, "CompanyDetails");
                            return result.Company_id.ToString();
                        }
                    }
                    else
                    {
                        response = client.PutAsJsonAsync(" api/_Company/UpdateCompany", CompanyRequest).Result;
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
            catch (Exception ex)
            {
               
                string error = ex.Message.ToString();
              //  CsvWriter.WriteFile(UriPath, error, "CompanyDetails");
                return error;
            }


        }
    }
}
