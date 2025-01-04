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
using System.Net.Http;

namespace customerServiceSoftware
{
    public partial class Create_User_CompanyAdmin : Form
    {
        public Create_User_CompanyAdmin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
            loadUserGrid(Convert.ToInt32(AppConfigReader.CompanyId));
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
                login.Company_ID = Convert.ToInt32(AppConfigReader.CompanyId);
                login.Id = Convert.ToInt32(txtUserId.Text);


                using (HttpClient client = new HttpClient())
                {
                    // client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                   //  client.BaseAddress = new Uri("http://localhost:58989/");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                    var CreateLoginRequest = Newtonsoft.Json.JsonConvert.SerializeObject(login);
                    HttpResponseMessage response;

                    if (txtUserId.Text == "0")
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
                            loadUserGrid(Convert.ToInt32(AppConfigReader.CompanyId));
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

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txt_create_Useremail_OnValueChanged(object sender, EventArgs e)
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
                    //if (row.Cells["Company_ID"].Value != null)
                    //{
                    //    CmbCompany.SelectedValue = Convert.ToInt32(row.Cells["Company_ID"].Value.ToString());
                    //}
                    if (row.Cells[1].Value != null)
                    {
                        txtUserId.Text = row.Cells[0].Value.ToString();
                    }
                    tabControl1.SelectedTab = tabPage1;
                }
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
                    //client.BaseAddress = new Uri("http://localhost:58989/);


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

        void clearAddUser()
        {
            txt_create_UserName.Text = "";
            txt_Create_Password.Text = "";
            Txt_Create_confirmPass.Text = "";
            Txt_create_Useremail.Text = "";            
            txtUserId.Text = "0";
        }

    }
}
