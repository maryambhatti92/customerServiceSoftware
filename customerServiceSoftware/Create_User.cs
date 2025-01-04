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
    public partial class Create_User : Form
    {
        public Create_User()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
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


                using (HttpClient client = new HttpClient())
                {
                    // client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                   //  client.BaseAddress = new Uri("http://localhost:58989/");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                    var CreateLoginRequest = Newtonsoft.Json.JsonConvert.SerializeObject(login);
                    HttpResponseMessage response;

                    response = client.PostAsJsonAsync("api/_Login/CreateLogin", CreateLoginRequest).Result;
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
    }
}
