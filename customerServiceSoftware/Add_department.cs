using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using css.Data.Models;
using css.Shared.ViewModels;
using System.Net.Http;
using System.IO;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace customerServiceSoftware
{
    public partial class Add_department : Form
    {
        public Add_department()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bool check = Department_validation();
            if (check)
            {
                tbl_Departments department = new tbl_Departments();
                department.Dep_Name = txt_department.Text;
                department.Email = txt_email.Text;
                using (HttpClient client = new HttpClient())
                {
                    // client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                    var DiagnosisRequest = Newtonsoft.Json.JsonConvert.SerializeObject(department);
                    HttpResponseMessage response;

                    response = client.PostAsJsonAsync("api/_Department/CreateDepartment", DiagnosisRequest).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<string>().Result;
                        if (result == "Successful")
                        {
                            MessageBox.Show(result);
                            this.Close();
                        }

                    }
                }

            }
        }

        private bool Department_validation()
        {

            string email = txt_email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                MessageBox.Show("Enter Correct Department Email");
                txt_email.Focus();
                return false;
            }

            if (txt_department.Text == "")
            {
                MessageBox.Show("Enter Department Name");
                txt_department.Focus();
                return false;
            }
            else if (txt_email.Text == "")
            {
                MessageBox.Show("Enter Department Email");
                txt_email.Focus();
                return false;
            }

            return true;
        }

    }
}
