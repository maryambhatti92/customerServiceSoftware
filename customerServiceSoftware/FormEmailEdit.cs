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
    public partial class FormEmailEdit : Form
    {
        public FormEmailEdit(string refNum, string inspectionBody, string customer, string EmailCode, string RMA, string phone, string Email, string companyName, string EvaluationLink)
        {
            InitializeComponent();
            Tbl_EmailContents Email_Obj = TabClasses.EmailOPerations.LoadEmailData(EmailCode);

            txtEmailCode.Text = EmailCode;
            txtRMA.Text = Email_Obj.RMA + " : " + RMA ;
            txtRefernce.Text = Email_Obj.Reference + " : " + refNum;
            txtDate.Text = Email_Obj.Date + " : " + DateTime.Now;
            txtDear.Text = Email_Obj.Dear + " : " + customer;           
            if (EmailCode == "Yes")
            {
                txtBody.Text = Email_Obj.Email_text;
                txtFooter.Text = Email_Obj.Footer + " : Phone - " + phone + " And Email - " + Email;
            }
            else
            {
                var x= Email_Obj.Email_text.Split(':');
                if (EmailCode == "Evaluation")
                {
                    string url = AppConfigReader.CompletionEvalutionUrl + "?eval=" + EvaluationLink;
                    Email_Obj.Email_text = Email_Obj.Email_text.Replace("\n \nLink here \n\n\n", "\n " + url + "\n\n\n");

                    if (x.Count() > 1)
                        txtBody.Text = x[0] + " " + companyName + " " + x[1] + " " + Environment.NewLine + EvaluationLink + Environment.NewLine + x[2];
                    else
                        txtBody.Text = x[0];
                }
                else
                {
                    txtBody.Text = x[0] + " : " + inspectionBody + Environment.NewLine + x[1] + " : ";
                }
                txtFooter.Text = Email_Obj.Footer;
            }
            txtSignature.Text = Email_Obj.Signature;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Do You want to continue?", "Email Update", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {
                bool check = EmailEdit_validation();
                if (check)
                {

                    Tbl_EmailContents EmailContent = new Tbl_EmailContents();
                    EmailContent.RMA = (txtRMA.Text).Split(':')[0].ToString();
                    EmailContent.Reference = (txtRefernce.Text).Split(':')[0].ToString();
                    EmailContent.Date = (txtDate.Text).Split(':')[0].ToString();
                    EmailContent.Dear = (txtDear.Text).Split(':')[0].ToString();
                    if (txtEmailCode.Text == "Yes")
                    {
                        EmailContent.Email_text = txtBody.Text;
                        EmailContent.Footer = (txtFooter.Text).Split(':')[0].ToString();
                    }
                    else
                    {
                        EmailContent.Footer = txtFooter.Text;
                       
                        if (txtEmailCode.Text == "Evaluation")
                        {
                            //var x = (txtBody.Text).Split('-');
                            EmailContent.Email_text = txtBody.Text;
                        }
                        else
                        {
                            var x = (txtBody.Text).Split('\n');
                            EmailContent.Email_text = x[0].Split(':')[0] + ":" + x[1];
                        }
                    }
                    EmailContent.Signature = txtSignature.Text;
                    EmailContent.Email_Code = txtEmailCode.Text;
                    EmailContent.Company_ID = Convert.ToInt32(AppConfigReader.CompanyId);
                    string Message = TabClasses.EmailOPerations.UpdateEmail(EmailContent);
                    MessageBox.Show(Message);
                }
            }
        }

        private bool EmailEdit_validation()
        {

            if (txtRMA.Text == "")
            {
                MessageBox.Show("Enter RMA text");
                txtRMA.Focus();
                return false;
            }
            else if (txtRefernce.Text == "")
            {
                MessageBox.Show("Enter Reference Text");
                txtRefernce.Focus();
                return false;
            }
            else if (txtDate.Text == "")
            {
                MessageBox.Show("Enter Date Text");
                txtDate.Focus();
                return false;
            }
            else if (txtDear.Text == "")
            {
                MessageBox.Show("Enter Greeting Text");
                txtDear.Focus();
                return false;
            }
            else if (txtBody.Text == "")
            {
                MessageBox.Show("Enter Body Text");
                txtBody.Focus();
                return false;
            }
            else if (txtFooter.Text == "")
            {
                MessageBox.Show("Enter Ending Text");
                txtFooter.Focus();
                return false;
            }
            else if (txtFooter.Text == "")
            {
                MessageBox.Show("Enter Orignal Quantity");
                txtFooter.Focus();
                return false;
            }
            else if (txtSignature.Text == "")
            {
                MessageBox.Show("Enter Signature text");
                txtSignature.Focus();
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
    }
    }


