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
    public partial class Add_ServiceCase : Form
    {
        IEnumerable<tbl_ProblemDescriptionIssue> issues;

        private void Add_ServiceCase_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
            
        }

        public Add_ServiceCase()
        {
            InitializeComponent();

            issues = TabClasses.RequestFormSheetOperations.LoadIssueCMB();

            cmbIssues.DataSource = issues;
            cmbIssues.DisplayMember = "Issue";
            cmbIssues.ValueMember = "Issue_ID";

        }

        private void Window_change()
        {

            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = FormWindowState.Maximized;
                bunifuTileButton3.Visible = true;
                bunifuTileButton2.Visible = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                bunifuTileButton2.Visible = true;
                bunifuTileButton3.Visible = false;

            }
        }

        private void btn_main_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            main main = new main();
            main.Show();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {

            Window_change();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            Window_change();
            
        }

        private void btnSaveRequest_Click(object sender, EventArgs e)
        {
            try
            { 
            bool check = Service_validation();
            if (check)
            {
                DialogResult m = MessageBox.Show("Do You want to continue?", "Create Service Request", MessageBoxButtons.YesNo);
                if (m == DialogResult.Yes)
                {
                    FormSheetVM FormSheetdata = new FormSheetVM();

                    FormSheetdata.Customer = new tbl_customer();
                    FormSheetdata.Customer.company = txtCompany.Text;
                    FormSheetdata.Customer.street = txtStreet.Text;
                    FormSheetdata.Customer.Zipcode = txtZipcode.Text;
                    FormSheetdata.Customer.Country = txtCountry.Text;
                    FormSheetdata.Customer.CustomerRefNo = txtReferenceNo.Text;

                    FormSheetdata.Person1 = new tbl_contact_person();
                    FormSheetdata.Person1.name = txtcp1Name.Text;
                    FormSheetdata.Person1.phone = txtcp1Phone.Text;
                    FormSheetdata.Person1.email = txtcp1Email.Text;

                    FormSheetdata.Person2 = new tbl_contact_person();
                    FormSheetdata.Person2.name = txtcp2Name.Text;
                    FormSheetdata.Person2.phone = txtcp2Phone.Text;
                    FormSheetdata.Person2.email = txtcp2Phone.Text;

                    FormSheetdata.Request = new tbl_customer_request();
                    FormSheetdata.Request.issue = Convert.ToInt32(cmbIssues.SelectedValue);
                    FormSheetdata.Request.error_description = txtReason.Text;
                    FormSheetdata.Request.ref_num = txtReferenceNo.Text;
                    FormSheetdata.Request.date_added = System.DateTime.Now;
                    FormSheetdata.Request.Last_Modified = System.DateTime.Now;
                   // FormSheetdata.Request.Individual_FootNote = txtFootNote.Text;
                    FormSheetdata.Request.FurtherInformatipn = Furtherinfo_text.Text;
                    FormSheetdata.Request.isActive = true;
                    FormSheetdata.Request.isDelete = false;
                    FormSheetdata.Request.Company_ID = Convert.ToInt32(AppConfigReader.CompanyId);


                        string result = TabClasses.AddServiceOperations.SaveFormSheet(FormSheetdata);
                        if (result == "Unsuccessful")
                        {
                            MessageBox.Show("Customer Service Request not Added");
                        }
                        else
                        {
                            TabClasses.AddServiceOperations.uploadFiles(txtUploadData.Text,Convert.ToInt32(result));
                            MessageBox.Show("Customer Service Request Added");
                            btnSaveRequest.Enabled = false;
                            this.Close();
                            main main = new main();
                            main.Show();
                        }
                   
                   
                   
                    }
            }
        }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool Service_validation()
        {
            //if (txtCompany.Text == "")
            //{
            //    MessageBox.Show("Enter Company");
            //    txtCompany.Focus();
            //    return false;
            //}
            //else if (txtStreet.Text == "")
            //{
            //    MessageBox.Show("Enter Street");
            //    txtStreet.Focus();
            //    return false;
            //}
            //else if (txtZipcode.Text == "")
            //{
            //    MessageBox.Show("Enter Zip Code");
            //    txtZipcode.Focus();
            //    return false;
            //}
            //else if (txtCountry.Text == "")
            //{
            //    MessageBox.Show("Enter Country");
            //    txtCountry.Focus();
            //    return false;
            //}
            //else
            if (txtcp1Name.Text == "")
            {
                MessageBox.Show("Enter Contact Person 1 Name");
                txtcp1Name.Focus();
                return false;
            }
            else if (txtcp1Email.Text == "")
            {
                MessageBox.Show("Enter Contact Person 1 Email");
                txtcp1Email.Focus();
                return false;
            }            
            else if (txtcp1Phone.Text == "")
            {
                MessageBox.Show("Enter Contact Person 1 Phone");
                txtcp1Phone.Focus();
                return false;
            }
            //else if (txtcp2Name.Text == "")
            //{
            //    MessageBox.Show("Enter Contact Person 2 Name");
            //    txtcp2Name.Focus();
            //    return false;
            //}
            //else if (txtcp2Email.Text == "")
            //{
            //    MessageBox.Show("Enter Contact Person 2 Email");
            //    txtcp2Email.Focus();
            //    return false;
            //}          
            //else if (txtcp2Phone.Text == "")
            //{
            //    MessageBox.Show("Enter Contact Person 2 Phone");
            //    txtcp2Phone.Focus();
            //    return false;
            //}
            else if (cmbIssues.Text == "--Select--")
            {
                MessageBox.Show("Select Issue");
                cmbIssues.Focus();
                return false;
            }
            else if (txtReason.Text == "")
            {
                MessageBox.Show("Enter Reason");
                txtReason.Focus();
                return false;
            }
            else if (txtReferenceNo.Text == "")
            {
                MessageBox.Show("Enter Reference Number");
                txtReferenceNo.Focus();
                return false;
            }
            //else if (Furtherinfo_text.Text == " Further Information")
            //{
            //    MessageBox.Show("Enter Further Information");
            //    Furtherinfo_text.Text = "";
            //    Furtherinfo_text.Focus();
            //    return false;
            //}
            //else if (Furtherinfo_text.Text == "")
            //{
            //    MessageBox.Show("Enter Further Information");
            //    Furtherinfo_text.Focus();
            //    return false;
            //}
            //else if (txtFurtherInfo.Text == "")
            //{
            //    MessageBox.Show("Enter Further Information");
            //   txtFurtherInfo.Focus();
            //    return false;
            //}
            //else if (txtUploadData.Text == "")
            //{
            //    MessageBox.Show("Please Upload Data");
            //    txtUploadData.Focus();
            //    return false;
            //}
            else if (txtcp1Email.Text != "" )
            {
                var chech1 = TabClasses.AddServiceOperations.emailCheck(txtcp1Email.Text);
                var chech = TabClasses.AddServiceOperations.emailCheck(txtcp2Email.Text);
                if (!chech1) // || !chech)
                {                    
                    MessageBox.Show("Enter Valid Contact Person Email");
                    return false;
                }
            }           
            return true;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.InitialDirectory = "c:\\";
            OpenFileDialog1.Filter =
            //"CSV Files (*.csv)|*.csv|" +
            //"Excel Files (*.xls)|*.xls|" +
            "All Files (*.*)|*.*";
            OpenFileDialog1.FilterIndex = 2;
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (txtUploadData.Text == "")
                {
                    txtUploadData.Text = OpenFileDialog1.FileName;
                }
                else
                {
                    txtUploadData.Text = txtUploadData.Text + Environment.NewLine + OpenFileDialog1.FileName;
                }
                
            }

            //u can also save or see the path  
            
        }

        private void Header_main_Paint(object sender, PaintEventArgs e)
        {
            
        }

       
    }
}
