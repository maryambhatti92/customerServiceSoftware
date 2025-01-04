using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using css.Data.Models;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace customerServiceSoftware
{
    public partial class CompanyControls_Owner : Form
    {
        public CompanyControls_Owner()
        {
            InitializeComponent();
         
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Do You want to continue?", "Add Company", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {
                bool check = AddCompany_validation();
                if (check)
                {

                    tbl_Company CompanyData = new tbl_Company();
                    CompanyData.Comapany_Name = txtCmpName.Text;
                    CompanyData.Email = txtCmpEmail.Text;
                    CompanyData.Address = txtCmpAddress.Text;
                    CompanyData.Liscense = txtCmpLiscence.Text;
                    CompanyData.Phone_Num = txtPhoneNo.Text;
                    CompanyData.LisceneExpiryDate = dateTimePicker1.Value.ToString();
                    CompanyData.Company_id = Convert.ToInt32(txtcompanyID.Text);

                    string Message = TabClasses.CompanyOperations.AddCompanyData(CompanyData);
                    loadCompanyGrid();
                    clearAddComoany();
                    if (txtcompanyID.Text == "0")
                    {
                        MessageBox.Show("Company added. New id is " + Message);
                    }
                    else
                    {
                        MessageBox.Show("Company Information Updated");
                    }
                }
            }
        }

        private bool AddCompany_validation()
        {

            if (txtCmpName.Text == "")
            {
                MessageBox.Show("Enter Company Name");
                txtCmpName.Focus();
                return false;
            }
            //else if (txtPhoneNo.Text == "")
            //{
            //    MessageBox.Show("Enter Reference Text");
            //    txtPhoneNo.Focus();
            //    return false;
            //}
            else if (txtCmpEmail.Text == "")
            {
                MessageBox.Show("Enter Company Email");
                txtCmpEmail.Focus();
                return false;
            }          
            else if (txtCmpAddress.Text == "")
            {
                MessageBox.Show("Enter Company Address");
                txtCmpAddress.Focus();
                return false;
            }
            else if (txtCmpLiscence.Text == "")
            {
                MessageBox.Show("Generate Company Liscence");
                txtCmpLiscence.Focus();
                return false;
            }
            else if (txtCmpEmail.Text != "")
            {
                var chech1 = TabClasses.AddServiceOperations.emailCheck(txtCmpEmail.Text);

                if (!chech1) // || !chech)
                {
                    MessageBox.Show("Enter Valid Email");
                    return false;
                }
            }


            return true;
        }

        private void CompanyControl_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;            
            loadCompanyGrid();
            CmbCompany.SelectedIndex = -1;
           // comboBox1.SelectedIndex = -1;
            CmbCompany.Text = "-- Select --";
            // comboBox1.Text = "-- Select --";
            loadUserGrid(Convert.ToInt32(comboBox1.SelectedValue));
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRMA_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_cmp_liscence_Click(object sender, EventArgs e)
        {
            Guid obj = Guid.NewGuid();
            txtCmpLiscence.Text =  obj.ToString();
          


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_create_UserName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void tblCompanyBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btn_create_Signup_Click(object sender, EventArgs e)
        {
            bool check = User_validation();
            if (check)
            {
                tbl_SequawareLogin login = new tbl_SequawareLogin();
                login.Email = Txt_create_Useremail.Text;
                login.Password = txt_Create_Password.Text;
                login.UserName = txt_create_UserName.Text;
                login.Company_ID = Convert.ToInt32(CmbCompany.SelectedValue);
                login.Id = Convert.ToInt32(txtuserid.Text);

                using (HttpClient client = new HttpClient())
                {
                    // client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                      client.BaseAddress = new Uri("http://localhost:58989/");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                    var CreateLoginRequest = Newtonsoft.Json.JsonConvert.SerializeObject(login);
                    HttpResponseMessage response;

                    if (txtuserid.Text == "0")
                    {
                        response = client.PostAsJsonAsync("api/_Login/CreateLogin", CreateLoginRequest).Result;
                    }
                    else
                    {
                        
                         response = client.PostAsJsonAsync("api/_Login/UpdateLogin", CreateLoginRequest).Result;
                    }                    
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsAsync<string>().Result;
                        if (result == "Successful")
                        {
                            loadUserGrid(Convert.ToInt32(comboBox1.SelectedValue));
                            clearAddUser();
                            MessageBox.Show(result);
                            
                        }

                    }
                }
            }
        }


        private bool User_validation()
        {
            if (txt_create_UserName.Text == "")
            {
                MessageBox.Show("Enter User Name");
                txt_create_UserName.Focus();
                return false;
            }
            if (txt_Create_Password.Text == "")
            {
                MessageBox.Show("Enter Password");
                txt_Create_Password.Focus();
                return false;
            }            
            if (Txt_Create_confirmPass.Text == "")
            {
                MessageBox.Show("Enter Confirm Password");
                Txt_Create_confirmPass.Focus();
                return false;
            }
            if (Txt_create_Useremail.Text == "")
            {
                MessageBox.Show("Enter Email");
                Txt_create_Useremail.Focus();
                return false;
            }
            if (txt_Create_Password.Text != Txt_Create_confirmPass.Text)
            {
                MessageBox.Show("Entered passwords mismatch");
                txt_Create_Password.Focus();
                return false;
            }
            else if (CmbCompany.Text == "-- Select --")
            {
                MessageBox.Show("Select Company");
                CmbCompany.Focus();
                return false;
            }
            if (Txt_create_Useremail.Text != "")
            {
                var chech1 = TabClasses.AddServiceOperations.emailCheck(Txt_create_Useremail.Text);
               
                if (!chech1) // || !chech)
                {
                    MessageBox.Show("Enter Valid Email");
                    return false;
                }
            }

            return true;
        }

        public void loadCompanyGrid()
        {
            try
            {
                //DataTable dt = new DataTable();
                // dt = opr.mainTableDataLoadData(info);

                IEnumerable<tbl_Company> Companies = new List<tbl_Company>();
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");
                   

                    // Get grid data
                    //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                    string url = " api/_Company/GetAllCompany";
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Companies = response.Content.ReadAsAsync<IEnumerable<tbl_Company>>().Result;
                        dataGridView1.DataSource = Companies;
                      //  dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // to resize the coloumn with wrt window size
                        dataGridView1.ClearSelection();


                        CmbCompany.DataSource = Companies;
                        CmbCompany.DisplayMember = "Comapany_Name";
                        CmbCompany.ValueMember = "Company_id";
                        CmbCompany.Text = "-- Select --";

                        IEnumerable<tbl_Company> UserCompany = Companies;
                        comboBox1.DataSource = UserCompany;
                        comboBox1.DisplayMember = "Comapany_Name";
                        comboBox1.ValueMember = "Company_id";
                        comboBox1.Text = "-- Select --";

                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }

        }

        public void loadUserGrid(int companyID)
        {
            try
            {
                //DataTable dt = new DataTable();
                // dt = opr.mainTableDataLoadData(info);

                IEnumerable<tbl_SequawareLogin> Users = new List<tbl_SequawareLogin>();
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");


                    // Get grid data
                    //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                    string url = " api/_Login/GetUserViaCompany?CompanyID=" + companyID;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Users = response.Content.ReadAsAsync<IEnumerable<tbl_SequawareLogin>>().Result;
                        dataGridView2.DataSource = Users;
                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // to resize the coloumn with wrt window size
                        dataGridView2.ClearSelection();

                     
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                if (!row.IsNewRow)
                {
                    if (row.Cells["Comapany_Name"].Value != null)
                    {
                        txtCmpName.Text = row.Cells["Comapany_Name"].Value.ToString();
                    }
                    if (row.Cells["Phone_Num"].Value != null)
                    {
                        txtPhoneNo.Text = row.Cells["Phone_Num"].Value.ToString();
                    }
                    if (row.Cells["Address"].Value != null)
                    {
                        txtCmpAddress.Text = row.Cells["Address"].Value.ToString();
                    }
                    if (row.Cells["Email"].Value != null)
                    {
                        txtCmpEmail.Text = row.Cells["Email"].Value.ToString();
                    }
                    if (row.Cells["Liscense"].Value != null)
                    {
                        txtCmpLiscence.Text = row.Cells["Liscense"].Value.ToString();
                    }
                    if (row.Cells["LisceneExpiryDate"].Value != null)
                    {
                        dateTimePicker1.Text = row.Cells["LisceneExpiryDate"].Value.ToString();
                    }
                    if (row.Cells["Company_ID"].Value != null)
                    {
                        txtcompanyID.Text = row.Cells["Company_ID"].Value.ToString();
                    }

                    tabControl1.SelectedTab = tabPage1;

                }
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.SelectedValue);
            loadUserGrid(id);
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
           

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                DataGridViewRow row = dataGridView2.CurrentRow;
                if (!row.IsNewRow)
                {
                    if (row.Cells["UserName"].Value != null)
                    {
                        txt_create_UserName.Text = row.Cells["UserName"].Value.ToString();
                    }
                    if (row.Cells["Password"].Value != null)
                    {
                        txt_Create_Password.Text = row.Cells["Password"].Value.ToString();
                    }
                    if (row.Cells["Password"].Value != null)
                    {
                        Txt_Create_confirmPass.Text = row.Cells["Password"].Value.ToString();
                    }
                    if (row.Cells["Email"].Value != null)
                    {
                        Txt_create_Useremail.Text = row.Cells["Email"].Value.ToString();
                    }
                    if (row.Cells["Company_ID"].Value != null)
                    {
                        CmbCompany.SelectedValue = Convert.ToInt32(row.Cells["Company_ID"].Value.ToString());
                    }
                    if (row.Cells[1].Value != null)
                    {
                        txtuserid.Text = row.Cells[0].Value.ToString();
                    }
                    tabControl1.SelectedTab = tabPage3;
                }
            }
        }

        void clearAddComoany()
        {
            txtCmpName.Text = "";
            txtCmpLiscence.Text = "";
            txtCmpEmail.Text = "";
            txtCmpAddress.Text = "";
            txtPhoneNo.Text = "";
            dateTimePicker1.Text = DateTime.Today.ToString();
            txtcompanyID.Text = "0";

        }

        void clearAddUser()
        {
            txt_create_UserName.Text = "";
            txt_Create_Password.Text = "";
            Txt_Create_confirmPass.Text = "";
            Txt_create_Useremail.Text = "";
            CmbCompany.SelectedIndex = -1;
            CmbCompany.Text = "-- Select --";
            txtuserid.Text = "0";
        }
    }
}


