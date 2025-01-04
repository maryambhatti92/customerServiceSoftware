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
    public class AddServiceOperations
    {

        public static string SaveFormSheet(FormSheetVM formsheetData)
        {
            using (HttpClient client = new HttpClient())
            {
                // client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
               //    client.BaseAddress = new Uri("http://localhost:58989/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var FormSheetRequest = Newtonsoft.Json.JsonConvert.SerializeObject(formsheetData);
                HttpResponseMessage response;
                response = client.PostAsJsonAsync("api/_FormSheetRequest/CreateFormSheet", FormSheetRequest).Result;
                if (response.IsSuccessStatusCode)
                {

                    var result = response.Content.ReadAsAsync<tbl_customer_request>().Result;
                    return result.Request_id.ToString();

                }
            }
            return "Successful";
        }

        public static string uploadFiles(string sourcePaths, int request_id)
        {
            try
            {

                string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
                string targetPath = UriPath + "\\files\\Customer_Request_" + request_id; // + "\\" + name + ".txt";

                string[] lines = sourcePaths.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }
                foreach (var sourcePath in lines)
                {
                    if (System.IO.File.Exists(sourcePath))
                    {
                        System.IO.File.Copy(sourcePath, targetPath + "\\" + System.IO.Path.GetFileName(sourcePath));

                    }




                }
                return "Successful";
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return "Unsuccessful";
            }


        }

        public static bool emailCheck(string email)
        {
            bool status = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);            
            return status;
        }
    }
}

