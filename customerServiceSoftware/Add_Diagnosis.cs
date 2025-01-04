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


namespace customerServiceSoftware
{
    public partial class Add_Diagnosis : Form
    {
        public Add_Diagnosis()
        {
            InitializeComponent();

            IEnumerable<tbl_Diagnosis> ServiceList = TabClasses.InspectionFunctions.LoadDiagnosisCMB();
            cmbDiagnosis.DataSource = ServiceList;
            cmbDiagnosis.DisplayMember = "Diagnosis";
            cmbDiagnosis.ValueMember = "DiagnosisID";
        }

        private void Add_Diagnosis_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = Diagnosis_validation();
                if (check)
                {
                    tbl_Diagnosis diagnosis = new tbl_Diagnosis();
                    diagnosis.Diagnosis = txt_diagnosis.Text;
                    diagnosis.isdelete = false;
                    diagnosis.Company_ID = Convert.ToInt32(AppConfigReader.CompanyId);
                    using (HttpClient client = new HttpClient())
                    {
                        // client.DefaultRequestHeaders.Accept.Clear();
                        client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                     // client.BaseAddress = new Uri("http://localhost:58989/");
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                        var DiagnosisRequest = Newtonsoft.Json.JsonConvert.SerializeObject(diagnosis);
                        HttpResponseMessage response;

                        response = client.PostAsJsonAsync("api/_Diagnosis/CreateDiagnosis", DiagnosisRequest).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsAsync<string>().Result;
                            if (result == "Successful")
                            {
                                txt_diagnosis.Text = "";
                                cmbDiagnosis.DataSource = null;
                                IEnumerable<tbl_Diagnosis> ServiceList = TabClasses.InspectionFunctions.LoadDiagnosisCMB();
                                cmbDiagnosis.DataSource = ServiceList;
                                cmbDiagnosis.DisplayMember = "Diagnosis";
                                cmbDiagnosis.ValueMember = "DiagnosisID";
                                MessageBox.Show(result);
                               // this.Close();
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private bool Diagnosis_validation()
        {
            if (txt_diagnosis.Text == "")
            {
                MessageBox.Show("Enter Diagnosis");
                txt_diagnosis.Focus();
                return false;
            }
           
            return true;
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteDiagnosis_Click(object sender, EventArgs e)
        {
            try
            {               
                    tbl_Diagnosis diagnosis = new tbl_Diagnosis();
                    diagnosis.DiagnosisID = Convert.ToInt32(cmbDiagnosis.SelectedValue);

                    using (HttpClient client = new HttpClient())
                    {
                        // client.DefaultRequestHeaders.Accept.Clear();
                        client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //    client.BaseAddress = new Uri("http://localhost:58989/");
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                        var DiagnosisRequest = Newtonsoft.Json.JsonConvert.SerializeObject(diagnosis);
                        HttpResponseMessage response;

                        response = client.PostAsJsonAsync("api/_Diagnosis/DelteDiagnosis", DiagnosisRequest).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsAsync<string>().Result;
                            if (result == "Successful" || result == "Diagnosis cannot be delete, It is used in Inspection")
                            {
                            cmbDiagnosis.DataSource = null;
                            IEnumerable<tbl_Diagnosis> ServiceList = TabClasses.InspectionFunctions.LoadDiagnosisCMB();
                            cmbDiagnosis.DataSource = ServiceList;
                            cmbDiagnosis.DisplayMember = "Diagnosis";
                            cmbDiagnosis.ValueMember = "DiagnosisID";
                            MessageBox.Show(result);
                                //this.Close();
                            }

                        }
                    }

                }         
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
