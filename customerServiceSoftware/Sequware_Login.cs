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
using System.Text.RegularExpressions;
using Pechkin;
using Pechkin.Synchronized;
using Codaxy.WkHtmlToPdf;
using System.Diagnostics;
using System.IO;
//yar suggestions kion nhi de raha VS? pata
namespace customerServiceSoftware
{
    public partial class sequware_login : Form
    {
        public sequware_login()
        {
            InitializeComponent();
           // txtPassword._t.PasswordChar = '*';


        }

        private void aaa1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged_1(object sender, EventArgs e)
        {

        }

      

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            try
            {
                bool check = Login_validation();
                if (check)
                {
                    tbl_SequawareLogin Logins = new tbl_SequawareLogin();
                    Logins.UserName = txtUsername.Text;
                    Logins.Password = txtPassword.Text;
                    Logins.Company_ID = Convert.ToInt32(AppConfigReader.CompanyId);

                    using (HttpClient client = new HttpClient())
                    {
                        // client.DefaultRequestHeaders.Accept.Clear();
                        client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                        //client.BaseAddress = new Uri("http://localhost:58989/");
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                        var LoginRequest = Newtonsoft.Json.JsonConvert.SerializeObject(Logins);
                        HttpResponseMessage response= client.PostAsJsonAsync("api/_Login/GetLogin", LoginRequest).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsAsync<tbl_SequawareLogin>().Result;
                            if (result == null)
                            {
                                MessageBox.Show("Enter correct User Name or Password");
                            }
                            else
                            {
                                this.Hide();
                                Home home = new Home();
                                home.Show();
                            }
                        }

                    }



                 


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


           
            
        }

        private bool Login_validation()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Enter User Name");
                txtUsername.Focus();
                return false;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter Password");
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void sequware_login_Load(object sender, EventArgs e)
        {
            //string original = System.IO.File.ReadAllText(Application.StartupPath + @"\templates\temp1.html", Encoding.UTF8);
            //string updated = original;
            //string randomTempFileName = Path.GetTempFileName() + ".html";
            //string randomTempFileNamePDF = Path.GetTempFileName() + ".pdf";

            //updated = updated.Replace("(RMA)", "new");
            ////updated = updated.Replace("(RMA)", txtService.Text);
            ////updated = updated.Replace("(RMA)", txtService.Text);
            ////updated = updated.Replace("(RMA)", txtService.Text);
            ////updated = updated.Replace("(RMA)", txtService.Text);
            ////updated = updated.Replace("(RMA)", txtService.Text);
            ////updated = updated.Replace("(RMA)", txtService.Text);
            ////updated = updated.Replace("(RMA)", txtService.Text);
            ////updated = updated.Replace("(RMA)", txtService.Text);


            //using (System.IO.StreamWriter writetext = new System.IO.StreamWriter(randomTempFileName))
            //{
            //    writetext.Write(updated);
            //}

            ///// System.IO.File.WriteAllText(@"C:\Users\hp1\Desktop\templateupdated.html", updated);

            //var startinfo = new ProcessStartInfo(Application.StartupPath + @"\wkhtmltopdf\wkhtmltopdf.exe")
            //{
            //    WindowStyle = ProcessWindowStyle.Normal,
            //    CreateNoWindow = true,
            //    UseShellExecute = false,
            //    RedirectStandardOutput = true,
            //    RedirectStandardError = true,
            //    Arguments = string.Format(" --load-error-handling ignore {0} {1} ",  randomTempFileName, randomTempFileNamePDF)
            //};

            //Process process = new Process { StartInfo = startinfo };

            //process.OutputDataReceived += delegate (object sendere, DataReceivedEventArgs ee) { convert_OutputDataReceived(sendere, ee, process); };
            //process.ErrorDataReceived += delegate (object sendere, DataReceivedEventArgs ee) { convert_ErrorDataReceived(sendere, ee, process); };
            //process.Start();
            //process.BeginErrorReadLine();
            //process.BeginOutputReadLine();
            //process.WaitForExit();


            //if (System.IO.File.Exists(randomTempFileNamePDF))
            //{
            //    Process.Start(randomTempFileNamePDF);
            //}

            //PdfConvert.ConvertHtmlToPdf(


            //    new PdfDocument
            //{
            //   // kya hoa?ss
            //    Url = "http://wkhtmltopdf.org/",
            //    HeaderLeft = "[title]",
            //    HeaderRight = "[date] [time]",
            //    FooterCenter = "Page [page] of [topage]"

            //}, new PdfOutput
            //{
            //    OutputFilePath = @"C:\Users\hp1\Desktop\wkhtmltopdf-page.pdf"
            //});
        }

        void convert_OutputDataReceived(object sender, DataReceivedEventArgs e, Process process)
        {
            if(!string.IsNullOrEmpty(e.Data))
            Console.WriteLine(e.Data);
        }

        void convert_ErrorDataReceived(object sender, DataReceivedEventArgs e, Process process)
        {
            if (!string.IsNullOrEmpty(e.Data))
                Console.WriteLine(e.Data);
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            txtPassword.isPassword = true;
        }
    }
    }
