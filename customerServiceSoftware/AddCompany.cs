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

namespace customerServiceSoftware
{
    public partial class AddCompany : Form
    {
        public AddCompany()
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
                    CompanyData.LisceneExpiryDate = dateTimePicker1.Value.ToString();

                    string Message = TabClasses.CompanyOperations.AddCompanyData(CompanyData);                    
                    MessageBox.Show("Company added. New id is " +Message);
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
         
            return true;
        }

        private void FormEmailEdit_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
            
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
    }
    }


