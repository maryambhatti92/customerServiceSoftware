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
using System.Threading;
using System.Drawing.Drawing2D;
//using Spire.Pdf;
//using Spire.PdfViewer.Forms;
using System.Diagnostics;
namespace customerServiceSoftware
{
    public partial class Form_ServiceInfo : Form
    {
        public Form_ServiceInfo(int request_id, string formName)
        {
          
            InitializeComponent();
            if (formName == "Archive")
            {
                btnUpdate.Visible = false;
                btnOrdSave.Visible = false;
                btnOrderSave.Visible = false;
                BtnOrderEmail.Visible = false;
                btn_Order_EmEdit.Visible = false;
                btn_Ord_OpenEmail.Visible = false;
                btn_ins_Save.Visible = false;
                btn_ins_Email.Visible = false;
                btn_ins_email_edit.Visible = false;
                btn_ins_Openemail.Visible = false;
                Btn_Sol_Email.Visible = false;
                btn_sol_save.Visible = false;
                btn_completion_email.Visible = false;
                btn_completion_EvaluationEmail.Visible = false;
                lbl_completion_email.Visible = false;
                lbl_completion_evaluation.Visible = false;
                btn_completionEditEmail.Visible = false;
                bunifuGradientPanel17.Visible = false;
                btn_completion_Save.Visible = false;

            }

            IEnumerable<tbl_status> statuslist = loadbasicDataCmbStatus();
            cmbStatus.DataSource = statuslist;
            cmbStatus.DisplayMember = "status";
            cmbStatus.ValueMember = "Status_id";

            IEnumerable<tbl_ProblemDescriptionIssue> issues = TabClasses.RequestFormSheetOperations.LoadIssueCMB();
            cmbIssues.DataSource = issues;
            cmbIssues.DisplayMember = "Issue";
            cmbIssues.ValueMember = "Issue_ID";

            //new Thread(() =>
            //{
                LoadTabsData(request_id);
            //}).Start();
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

        private void Form_ServiceInfo_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            Window_change();

        }
     
        private void btn_main_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            main main = new main();
            main.Show();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Have you saved your work?", "Reminder", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Window_change();

        }

        //Tab load function here

        public void LoadTabsData(int requestid)
        {

            try
            {

                ServiceFormVM fillfields = TabClasses.ServiceInfoOperations.LoadServiceInfoDataPerformance(requestid);

                #region "Basic Data Load"
                if (fillfields.customerRequest.Request_id != 0)
                {

                    txtRequestID.Text = requestid.ToString();
                    txtService.Text = requestid.ToString(); ; // this.mainCustomerDataDisplay.CurrentRow.Cells[0].Value.ToString();
                    txtDateofEntry.Text = fillfields.customerRequest.date_added.ToString();// this.mainCustomerDataDisplay.CurrentRow.Cells[7].Value.ToString();
                    if (fillfields.customerRequest.status != null)
                    {
                        cmbStatus.SelectedValue = Convert.ToInt32(fillfields.customerRequest.status);
                    }
                    if (fillfields.customerRequest.priority != null)
                    {
                        txtPrio.Text = fillfields.customerRequest.priority.ToString(); //this.mainCustomerDataDisplay.CurrentRow.Cells[5].Value.ToString();
                    }

                    txtCustomerId.Text = fillfields.customerRequest.customer_id.ToString();
                    //cmbIssues.SelectedValue = Convert.ToInt32(fillfields.issue);
                    txtFile.Text = fillfields.customerRequest.customer_file;


                    // textcname.Text = fillfields.cname;
                    //  textAddress.Text = fillfields.address;                            
                    textzip.Text = fillfields.Customer.Zipcode;
                    textcountry.Text = fillfields.Customer.Country;
                    textstreet.Text = fillfields.Customer.street;
                    //textRefnum.Text = fillfields.CustomerRefNo;
                    textcompany.Text = fillfields.Customer.company;
                    txtManager.Text = fillfields.customerRequest.worker;
                    textRefnumb.Text = fillfields.Customer.CustomerRefNo;
                    txtReason.Text = fillfields.customerRequest.error_description;

                    if (fillfields.customerRequest.priority == "1")
                    {
                        txtPrio.BackColor = Color.Red;
                    }
                    else if (fillfields.customerRequest.priority == "2")
                    {
                        txtPrio.BackColor = Color.Orange;
                    }
                    else if (fillfields.customerRequest.priority == "3")
                    {
                        txtPrio.BackColor = Color.Green;
                    }


                    if (fillfields.Contacts != null)
                    {
                        txtcp1Name.Text = fillfields.Contacts.First().name.ToString();
                        txtcp1Email.Text = fillfields.Contacts.First().email.ToString();
                        txtcp1Phone.Text = fillfields.Contacts.First().phone.ToString();
                        textperson1_contactid.Text = fillfields.Contacts.First().Contact_id.ToString();
                        if (fillfields.Contacts.Count() > 1)
                        {
                            txtcp2Name.Text = fillfields.Contacts.Skip(1).First().name.ToString();
                            txtcp2Email.Text = fillfields.Contacts.Skip(1).First().email.ToString();
                            txtcp2Phone.Text = fillfields.Contacts.Skip(1).First().phone.ToString();
                            textperson2_contactid.Text = fillfields.Contacts.Skip(1).First().Contact_id.ToString();
                        }
                    }

                }



                #endregion

                #region "Order Data Load"
                //  tbl_OrderData orderData = TabClasses.OrderFunctions.LoadOrderData(Convert.ToInt32(b.txtRequestID.Text));
                if (fillfields.orderData != null)
                {
                    txt_ord_id.Text = fillfields.orderData.Order_id.ToString();
                    Txt_ord_Quantity.Text = fillfields.orderData.Quantity.ToString();
                    Txt_ord_Cust_Numb.Text = fillfields.orderData.CustomerNumber_FrmSheet.ToString();
                    Txt_ord__Cust_Num_Org_ord.Text = fillfields.orderData.CustomerNumber_Org.ToString();
                    Txt_ord_Original_OrdNum.Text = fillfields.orderData.OrginalOrderNumber.ToString();
                    Txt_ord_Orignal_Quantity.Text = fillfields.orderData.Orignal_Quantity.ToString();
                    dt_Ord_DeliveryDate.Value = fillfields.orderData.DeliveryDate ?? DateTime.Now;
                    if (fillfields.orderData.Email_Sent != null)
                    {
                        if (fillfields.orderData.Email_Sent == 1)
                        {
                            // BtnOrderEmail.Enabled = false;
                            BtnOrderEmail.Visible = false;
                            btn_Order_EmEdit.Enabled = false;
                            lbl_ord_EmailDate.Visible = true;
                            lbl_ord_EmailDate.Text = fillfields.orderData.Email_date.ToString();
                            labelorderEmailSent.Visible = true;
                        }
                    }
                    if (fillfields.orderData.Confirmation == "Yes")
                    {
                        Rdb_Yes.Checked = true;
                    }
                    else if (fillfields.orderData.Confirmation == "No")
                    {
                        Rdb_No.Checked = true;
                    }
                    else
                    {
                        Rdb_not_necessary.Checked = true;
                    }

                    if (fillfields.orderData.Waranty == "Inside Period")
                    {
                        rdb_Inside_Period.Checked = true;
                    }
                    else
                    {
                        rdb_Outside_Period.Checked = true;
                    }


                }
                #endregion

                #region "InspectionDataLoad"

                IEnumerable<tbl_Departments> DepartmentList = fillfields.departments;// TabClasses.InspectionFunctions.LoadDepartmentsCMB();
                cmb_ins_department.DataSource = DepartmentList;
                cmb_ins_department.DisplayMember = "Dep_Name";
                cmb_ins_department.ValueMember = "DepartmentID";

                IEnumerable<tbl_Diagnosis> DiagnosisList = fillfields.diagnosis; // TabClasses.InspectionFunctions.LoadDiagnosisCMB();
                cmb_Ins_Diagnosis.DataSource = DiagnosisList;
                cmb_Ins_Diagnosis.DisplayMember = "Diagnosis";
                cmb_Ins_Diagnosis.ValueMember = "DiagnosisID";

                IEnumerable<tbl_Reason> ReasonList = fillfields.reason;//TabClasses.InspectionFunctions.LoadReasonCMB();
                cmb_Ins_Reason.DataSource = ReasonList;
                cmb_Ins_Reason.DisplayMember = "Reason";
                cmb_Ins_Reason.ValueMember = "ReasonID";

                IEnumerable<tbl_ServiceTask> ServiceList = fillfields.serviceTask; // TabClasses.InspectionFunctions.LoadServiceTaskCMB();
                cmb_Ins_ServiceTask.DataSource = ServiceList;
                cmb_Ins_ServiceTask.DisplayMember = "Categories";
                cmb_Ins_ServiceTask.ValueMember = "DiagnosisCatID";

                // tbl_Inspection InspectionData = TabClasses.InspectionFunctions.LoadInspectionData(Convert.ToInt32(txtRequestID.Text));
                if (fillfields != null)
                {
                    if (fillfields.inspectionData != null)
                    {
                        txt_ins_InspectionID.Text = fillfields.inspectionData.InspectionID.ToString();
                        cmb_ins_department.SelectedValue = fillfields.inspectionData.Department;
                        txt_ins_Operator.Text = fillfields.inspectionData.Operator;
                        if (fillfields.inspectionData.Complaint == "Yes")
                        {
                            RDB_ins_yes.Checked = true;
                        }
                        else
                        {
                            rdb_ins_No.Checked = true;
                        }
                        cmb_Ins_ServiceTask.SelectedValue = fillfields.inspectionData.ServiceTask;
                        cmb_Ins_Diagnosis.SelectedValue = fillfields.inspectionData.Diagnosis;
                        cmb_Ins_Reason.SelectedValue = fillfields.inspectionData.Reason;
                        txt_ins_Desc.Text = fillfields.inspectionData.Description;
                        txt_ins_rep_done.Text = fillfields.inspectionData.ReportDone;
                        txt_ins_8D_rep.Text = fillfields.inspectionData.report8DDone;
                        if (fillfields.inspectionData.Email_Sent != null)
                        {
                            if (fillfields.inspectionData.Email_Sent == 1)
                            {
                                lb_ins_emailSent.Text = "Sent On: " + fillfields.inspectionData.Email_date;
                                lb_ins_emailSent.Visible = true;
                                btn_ins_Email.Visible = false;

                                btn_ins_email_edit.Enabled = false;
                            }
                        }

                    }
                }


                #endregion

                #region "SolutionDataLoad"

              //  SolutionVM SolutionData = TabClasses.SolutionOperations.LoadSolutionData(requestid);
                if (fillfields.solutionData != null)
                {
                    if (fillfields.solutionData.solution != null)
                    {
                        txt_Sol_SolutionId.Text = fillfields.solutionData.solution.solution_id.ToString();
                        txt_sol_statement.Text = fillfields.solutionData.solution.statement;
                        txt_sol_notes.Text = fillfields.solutionData.solution.Notes;
                        txt_sol_rem1.Text = fillfields.solutionData.solution.reminder1;
                        txt_sol_rem2.Text = fillfields.solutionData.solution.reminder2;
                    }
                    if (fillfields.solutionData.options != null)
                    {
                        foreach (var option in fillfields.solutionData.options)
                        {
                            if (option.Options == "Repair")
                            {
                                Cb_Repair_optact.Checked = true;
                                txt_sol_Repair.Text = option.price.ToString();
                                Cb_Repair_deccust.Checked = option.decision ?? false;
                                txt_sol_Repair.Enabled = true;
                                Cb_Repair_deccust.Enabled = true;
                            }
                            else if (option.Options == "Retour")
                            {
                                Cb_Retour_optact.Checked = true;
                                txt_Sol_Retour.Text = option.price.ToString();
                                Cb_Retour_deccust.Checked = option.decision ?? false;
                                txt_Sol_Retour.Enabled = true;
                                Cb_Retour_deccust.Enabled = true;
                            }
                            else if (option.Options == "Modification")
                            {
                                Cb_Modification_optact.Checked = true;
                                txt_sol_Modification.Text = option.price.ToString();
                                Cb_Modification_deccust.Checked = option.decision ?? false;
                                txt_sol_Modification.Enabled = true;
                                Cb_Modification_deccust.Enabled = true;
                            }
                            else if (option.Options == "New Product")
                            {
                                Cb_newprd_optact.Checked = true;
                                txt_sol_New_Product.Text = option.price.ToString();
                                Cb_newprd_deccust.Checked = option.decision ?? false;
                                txt_sol_New_Product.Enabled = true;
                                Cb_newprd_deccust.Enabled = true;
                            }
                            else if (option.Options == "Disposal")
                            {
                                Cb_Disposal_optact.Checked = true;
                                txt_sol_Disposal.Text = option.price.ToString();
                                Cb_disposal_deccust.Checked = option.decision ?? false;
                                txt_sol_Disposal.Enabled = true;
                                Cb_disposal_deccust.Enabled = true;
                            }
                            else if (option.Options == "Credit Note")
                            {
                                Cb_cednote_optact.Checked = true;
                                txt_Sol_Credit_note.Text = option.price.ToString();
                                Cb_crdnote_deccust.Checked = option.decision ?? false;
                                txt_Sol_Credit_note.Enabled = true;
                                Cb_crdnote_deccust.Enabled = true;
                            }
                            else if (option.Options == "Special Options")
                            {
                                Cb_splopt_optact.Checked = true;
                                txt_sol_SpclOption.Enabled = true;
                                Cb_splopt_deccust.Enabled = true;
                                txt_sol_SpclOption.Text = option.price.ToString();
                                Cb_splopt_deccust.Checked = option.decision ?? false;
                            }
                        }

                    }
                }
                #endregion


                #region "CompletionDataLoad"

                if (fillfields.completionData != null)
                {
                    txt_completionId.Text = fillfields.completionData.Completion_id.ToString();
                    txt_completion_orderNum.Text = fillfields.completionData.order_number;
                    txt_completion_CrediteNote.Text = fillfields.completionData.credite_note_number;
                    txt_completion_Disposal.Text = fillfields.completionData.Disposal;
                    if (fillfields.completionData.Email_Sent != null)
                    {
                        txt_Emailcount.Text = fillfields.completionData.Email_Sent.ToString();
                        lbl_completionDate.Text =  fillfields.completionData.Email_date.ToString();
                        lbl_completionEmail.Visible = true;
                        lbl_completionDate.Visible = true;
                        lblEmailcounttext.Visible = true;
                        lblEmailcount.Visible = true;
                        lblEmailcount.Text = fillfields.completionData.Email_Sent.ToString();
                    }

                    txt_completion_Availability.Text = fillfields.completionData.Availability.ToString();
                    txt_completion_ProfessionalCompetence.Text = fillfields.completionData.Professional_Competence.ToString();
                    txt_completion_ReactionTime.Text = fillfields.completionData.Reaction_Time.ToString();
                    txt_completion_Kindness.Text = fillfields.completionData.Kindness.ToString();
                    txt_completion_Text.Text  = fillfields.completionData.Text.ToString();
                }
                #endregion

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }

        }

        /* OLD
         *  public void LoadTabsData(int requestid)
          {

              try
              {

                  ServiceInfoVM fillfields = TabClasses.ServiceInfoOperations.LoadServiceInfoData(requestid);                 

                  #region "Basic Data Load"
                      if (fillfields.Request_id != 0)
                      {

                      txtRequestID.Text = requestid.ToString();
                      txtService.Text = requestid.ToString(); ; // this.mainCustomerDataDisplay.CurrentRow.Cells[0].Value.ToString();
                      txtDateofEntry.Text = fillfields.date_added.ToString();// this.mainCustomerDataDisplay.CurrentRow.Cells[7].Value.ToString();
                      if (fillfields.status != "")
                      {
                          cmbStatus.SelectedValue = Convert.ToInt32(fillfields.status);
                      }
                      txtPrio.Text = fillfields.priority.ToString(); //this.mainCustomerDataDisplay.CurrentRow.Cells[5].Value.ToString();

                          txtCustomerId.Text = fillfields.customer_id.ToString();
                          //cmbIssues.SelectedValue = Convert.ToInt32(fillfields.issue);
                          txtFile.Text = fillfields.customer_file;


                          // textcname.Text = fillfields.cname;
                          //  textAddress.Text = fillfields.address;                            
                          textzip.Text = fillfields.Zipcode.ToString();
                          textcountry.Text = fillfields.Country.ToString();
                          textstreet.Text = fillfields.street.ToString();
                          //textRefnum.Text = fillfields.CustomerRefNo;
                          textcompany.Text = fillfields.company.ToString();
                          txtManager.Text = fillfields.worker.ToString();
                          textRefnumb.Text = fillfields.CustomerRefNo.ToString();
                          txtReason.Text = fillfields.error_description;

                          if (fillfields.priority == "1")
                          {
                              txtPrio.BackColor = Color.Red;
                          }
                          else if (fillfields.priority == "2")
                          {
                              txtPrio.BackColor = Color.Orange;
                          }
                          else if (fillfields.priority == "3")
                          {
                              txtPrio.BackColor = Color.Green;
                          }


                          if (fillfields.contactpersons != null)
                          {
                              txtcp1Name.Text = fillfields.contactpersons[0].name.ToString();
                              txtcp1Email.Text = fillfields.contactpersons[0].email.ToString();
                              txtcp1Phone.Text = fillfields.contactpersons[0].phone.ToString();
                              textperson1_contactid.Text = fillfields.contactpersons[0].Contact_id.ToString();

                              txtcp2Name.Text = fillfields.contactpersons[1].name.ToString();
                              txtcp2Email.Text = fillfields.contactpersons[1].email.ToString();
                              txtcp2Phone.Text = fillfields.contactpersons[1].phone.ToString();
                              textperson2_contactid.Text = fillfields.contactpersons[1].Contact_id.ToString();
                          }

                      }



                  #endregion

                  #region "Order Data Load"
                //  tbl_OrderData orderData = TabClasses.OrderFunctions.LoadOrderData(Convert.ToInt32(b.txtRequestID.Text));
                  if (fillfields.Order_id != null)
                  {                   
                          txt_ord_id.Text = fillfields.Order_id.ToString();
                          Txt_ord_Quantity.Text = fillfields.Quantity.ToString();
                          Txt_ord_Cust_Numb.Text = fillfields.CustomerNumber_FrmSheet.ToString();
                          Txt_ord__Cust_Num_Org_ord.Text = fillfields.CustomerNumber_Org.ToString();
                          Txt_ord_Original_OrdNum.Text = fillfields.OrginalOrderNumber.ToString();
                          Txt_ord_Orignal_Quantity.Text = fillfields.Orignal_Quantity.ToString();
                          dt_Ord_DeliveryDate.Value = fillfields.DeliveryDate ?? DateTime.Now;
                          if (fillfields.Email_Sent != null)
                          {
                              if (fillfields.Email_Sent == 1)
                              {
                             // BtnOrderEmail.Enabled = false;
                              BtnOrderEmail.Visible = false;
                              btn_Order_EmEdit.Enabled = false;                            
                              lbl_ord_EmailDate.Visible = true;
                                  lbl_ord_EmailDate.Text = fillfields.Email_date.ToString();
                                  labelorderEmailSent.Visible = true;
                              }
                          }
                          if (fillfields.Confirmation == "Yes")
                          {
                             Rdb_Yes.Checked = true;
                          }
                          else if (fillfields.Confirmation == "No")
                          {
                              Rdb_No.Checked = true;
                          }
                          else
                          {
                              Rdb_not_necessary.Checked = true;
                          }

                          if (fillfields.Waranty == "Inside Period")
                          {
                              rdb_Inside_Period.Checked = true;
                          }
                          else
                          {
                              rdb_Outside_Period.Checked = true;
                          }


                  }
                  #endregion

                  #region "InspectionDataLoad"

                  IEnumerable<tbl_Departments> DepartmentList = TabClasses.InspectionFunctions.LoadDepartmentsCMB();
                  cmb_ins_department.DataSource = DepartmentList;
                  cmb_ins_department.DisplayMember = "Dep_Name";
                  cmb_ins_department.ValueMember = "DepartmentID";

                  IEnumerable<tbl_Diagnosis> DiagnosisList = TabClasses.InspectionFunctions.LoadDiagnosisCMB();
                  cmb_Ins_Diagnosis.DataSource = DiagnosisList;
                  cmb_Ins_Diagnosis.DisplayMember = "Diagnosis";
                  cmb_Ins_Diagnosis.ValueMember = "DiagnosisID";

                  IEnumerable<tbl_Reason> ReasonList = TabClasses.InspectionFunctions.LoadReasonCMB();
                  cmb_Ins_Reason.DataSource = ReasonList;
                  cmb_Ins_Reason.DisplayMember = "Reason";
                  cmb_Ins_Reason.ValueMember = "ReasonID";

                  IEnumerable<tbl_ServiceTask> ServiceList = TabClasses.InspectionFunctions.LoadServiceTaskCMB();
                  cmb_Ins_ServiceTask.DataSource = ServiceList;
                  cmb_Ins_ServiceTask.DisplayMember = "Categories";
                  cmb_Ins_ServiceTask.ValueMember = "DiagnosisCatID";

                 // tbl_Inspection InspectionData = TabClasses.InspectionFunctions.LoadInspectionData(Convert.ToInt32(txtRequestID.Text));
                  if (fillfields != null)
                  {
                      if (fillfields.RequestId != null)
                      {
                          txt_ins_InspectionID.Text = fillfields.InspectionID.ToString();
                          cmb_ins_department.SelectedValue = fillfields.Department;
                          txt_ins_Operator.Text = fillfields.Operator;
                          if (fillfields.Complaint == "Yes")
                          {
                              RDB_ins_yes.Checked = true;
                          }
                          else
                          {
                              rdb_ins_No.Checked = true;
                          }
                          cmb_Ins_ServiceTask.SelectedValue = fillfields.ServiceTask;
                          cmb_Ins_Diagnosis.SelectedValue = fillfields.Diagnosis;
                          cmb_Ins_Reason.SelectedValue = fillfields.Reason;
                          txt_ins_Desc.Text = fillfields.Description;
                          txt_ins_rep_done.Text = fillfields.ReportDone;
                          txt_ins_8D_rep.Text = fillfields.report8DDone;
                          if (fillfields.Email_Sent1 != null)
                          {
                              if (fillfields.Email_Sent1 == 1)
                              {
                                  lb_ins_emailSent.Text = "Sent On: " + fillfields.Email_date1;
                                  lb_ins_emailSent.Visible = true;
                                  btn_ins_Email.Visible = false;

                                  btn_ins_email_edit.Enabled = false;
                              }
                          }

                      }
                  }


                  #endregion

                  #region "SolutionDataLoad"

                  SolutionVM SolutionData = TabClasses.SolutionOperations.LoadSolutionData(requestid);
                  if (SolutionData != null)
                  {
                      if (SolutionData.solution != null)
                      {
                          txt_Sol_SolutionId.Text = SolutionData.solution.solution_id.ToString();
                          txt_sol_statement.Text = SolutionData.solution.statement;
                          txt_sol_notes.Text = SolutionData.solution.Notes;
                          txt_sol_rem1.Text = SolutionData.solution.reminder1;
                          txt_sol_rem2.Text = SolutionData.solution.reminder2;
                      }
                      if (SolutionData.options != null)
                      {
                          foreach (var option in SolutionData.options)
                          {
                              if (option.Options == "Repair")
                              {
                                  Cb_Repair_optact.Checked = true;
                                  txt_sol_Repair.Text = option.price.ToString();
                                  Cb_Repair_deccust.Checked = option.decision ?? false;
                                  txt_sol_Repair.Enabled = true;
                                  Cb_Repair_deccust.Enabled = true;
                              }
                              else if (option.Options == "Retour")
                              {
                                  Cb_Retour_optact.Checked = true;
                                  txt_Sol_Retour.Text = option.price.ToString();
                                  Cb_Retour_deccust.Checked = option.decision ?? false;
                                  txt_Sol_Retour.Enabled = true;
                                  Cb_Retour_deccust.Enabled = true;
                              }
                              else if (option.Options == "Modification")
                              {
                                  Cb_Modification_optact.Checked = true;
                                  txt_sol_Modification.Text = option.price.ToString();
                                  Cb_Modification_deccust.Checked = option.decision ?? false;
                                  txt_sol_Modification.Enabled = true;
                                  Cb_Modification_deccust.Enabled = true;
                              }
                              else if (option.Options == "New Product")
                              {
                                  Cb_newprd_optact.Checked = true;
                                  txt_sol_New_Product.Text = option.price.ToString();
                                  Cb_newprd_deccust.Checked = option.decision ?? false;
                                  txt_sol_New_Product.Enabled = true;
                                  Cb_newprd_deccust.Enabled = true;
                              }
                              else if (option.Options == "Disposal")
                              {
                                  Cb_Disposal_optact.Checked = true;
                                  txt_sol_Disposal.Text = option.price.ToString();
                                  Cb_disposal_deccust.Checked = option.decision ?? false;
                                  txt_sol_Disposal.Enabled = true;
                                  Cb_disposal_deccust.Enabled = true;
                              }
                              else if (option.Options == "Credit Note")
                              {
                                  Cb_cednote_optact.Checked = true;
                                  txt_Sol_Credit_note.Text = option.price.ToString();
                                  Cb_crdnote_deccust.Checked = option.decision ?? false;
                                  txt_Sol_Credit_note.Enabled = true;
                                  Cb_crdnote_deccust.Enabled = true;
                              }
                              else if (option.Options == "Special Options")
                              {
                                  Cb_splopt_optact.Checked = true;
                                  txt_sol_SpclOption.Enabled = true;
                                  Cb_splopt_deccust.Enabled = true;
                                  txt_sol_SpclOption.Text = option.price.ToString();
                                  Cb_splopt_deccust.Checked = option.decision ?? false;
                              }
                          }

                      }
                  }
                          #endregion

              }
              catch (Exception ex)
              {
                  string error = ex.Message.ToString();
              }

          }*/

        public IEnumerable<tbl_status> loadbasicDataCmbStatus()
        {
            try
            {
                //DataTable dt = new DataTable();
                // dt = opr.mainTableDataLoadData(info);

                IEnumerable<tbl_status> statusData = new List<tbl_status>();
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);


                    // Get grid data
                    //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                    string url = " api/_BasicData/GetStatusDropdown";
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        statusData = response.Content.ReadAsAsync<IEnumerable<tbl_status>>().Result;
                        return statusData;
                    }
                    else
                    {
                        return statusData;
                    }

                   

                }               
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                 IEnumerable < tbl_status > st= new List<tbl_status>();
                return st;
            }
        }
      
        private void btnFileOPen_Click(object sender, EventArgs e)
        {
            string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
            string FolderPath = UriPath + "\\files\\Customer_Request_" + txtRequestID.Text;
            System.IO.Directory.CreateDirectory(FolderPath);
            System.Diagnostics.Process.Start("explorer.exe", FolderPath);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {            
            DialogResult m = MessageBox.Show("Do You want to continue?", "Update", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {
                bool check = Manager_validation();
                if (check)
                {

                    int customerID = Convert.ToInt32(txtCustomerId.Text);
                    tbl_customer_request custReq = new tbl_customer_request();
                    custReq.Request_id = Convert.ToInt32(txtRequestID.Text);
                    custReq.worker = txtManager.Text;                    
                        custReq.status = cmbStatus.SelectedValue.ToString();                    
                    if (txtPrio.Text != "--Select--")
                    {
                        custReq.priority = txtPrio.Text.ToString();
                    }

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                        //client.BaseAddress = new Uri("http://localhost:58989/");
                        var request = Newtonsoft.Json.JsonConvert.SerializeObject(custReq);
                        HttpResponseMessage response = client.PutAsJsonAsync("api/_CustomerRequest/UpdateBasicManager", request).Result;
                        var result = response.Content.ReadAsAsync<string>().Result;
                        if (result == "Successful")
                        {
                            MessageBox.Show("Information Modified!");
                        }
                    }
                  
                }
            }
        }

        private void btnOrdSave_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Do You want to continue?", "Basic Data Update", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {

                bool check = Basic_validation();
                if (check)
                {
                    BasicdataVM basicdata = new BasicdataVM();
                    //basicdata.cname = textcname.Text;
                    //basicdata.address = textAddress.Text;
                    basicdata.company = textcompany.Text;
                    basicdata.street = textstreet.Text;
                    basicdata.zipcode = textzip.Text;
                    basicdata.country = textcountry.Text;

                    basicdata.Request_id = Convert.ToInt32(txtRequestID.Text);
                    basicdata.issue = Convert.ToInt32(cmbIssues.SelectedValue) ;
                    basicdata.error_description = txtReason.Text;

                    basicdata.CustomerRefNo = textRefnumb.Text;
                    // info.contactPerson1 = txtContactPerson1.Text;
                    //  info.contactPerson2 = txtContactPerson2.Text;

                    basicdata.Customer_id = Convert.ToInt32(txtCustomerId.Text);
                    basicdata.contactpersons = new List<tbl_contact_person>();


                    tbl_contact_person contactP = new tbl_contact_person();
                    contactP.Contact_id = Convert.ToInt32(textperson1_contactid.Text);
                    contactP.name = txtcp1Name.Text;
                    contactP.phone = txtcp1Phone.Text;
                    contactP.email = txtcp1Email.Text;
                    basicdata.contactpersons.Add(contactP);


                    tbl_contact_person contactP1 = new tbl_contact_person();
                    if (textperson2_contactid.Text != "")
                    {
                        contactP1.Contact_id = Convert.ToInt32(textperson2_contactid.Text);
                    }
                    contactP1.name = txtcp2Name.Text;
                    contactP1.phone = txtcp2Phone.Text;
                    contactP1.email = txtcp2Email.Text;
                    basicdata.contactpersons.Add(contactP1);



                    using (HttpClient client = new HttpClient())
                    {
                        // client.DefaultRequestHeaders.Accept.Clear();
                        client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                          //client.BaseAddress = new Uri("http://localhost:58989/");
                        //client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                        var Basicrequest = Newtonsoft.Json.JsonConvert.SerializeObject(basicdata);
                        HttpResponseMessage response = client.PutAsJsonAsync("api/_BasicData/UpdateBasicCustomer", Basicrequest).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsAsync<string>().Result;
                            if (result == "Successful")
                            {
                                MessageBox.Show("Information Modified!");
                            }
                        }
                    }




                }
            }

        }

        private void txtPrio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }           

        }

        private void txtPrio_Leave(object sender, EventArgs e)
        {
            if (txtPrio.Text == "1")
            {
                txtPrio.BackColor = Color.Red;
            }
            else if (txtPrio.Text == "2")
            {
                txtPrio.BackColor = Color.Orange;
            }
            else if (txtPrio.Text == "3")
            {
                txtPrio.BackColor = Color.Green;
            }

        }


        #region Validations 
        private bool Manager_validation()
        {
            if (txtManager.Text == "")
            {
                MessageBox.Show("Enter Manager");
                txtManager.Focus();
                return false;
            }
            else if (cmbStatus.Text == "")
            {
                MessageBox.Show("Select Status");
                cmbStatus.Focus();
                return false;
            }
            return true;
        }

        private bool Basic_validation()
        {

            //if (textcname.Text == "")
            //{
            //    MessageBox.Show("Enter Customer Name");
            //    textcname.Focus();
            //    return false;
            //}
            //else if (textAddress.Text == "")
            //{
            //    MessageBox.Show("Enter Address");
            //    textAddress.Focus();
            //    return false;
            //}
            //else 
            if (textcompany.Text == "")
            {
                MessageBox.Show("Enter Company");
                textcompany.Focus();
                return false;
            }
            else if (textstreet.Text == "")
            {
                MessageBox.Show("Enter Street");
                textstreet.Focus();
                return false;
            }
            else if (textzip.Text == "")
            {
                MessageBox.Show("Enter Zip Code");
                textzip.Focus();
                return false;
            }
            else if (textcountry.Text == "")
            {
                MessageBox.Show("Enter Country");
                textcountry.Focus();
                return false;
            }           
            
            //else if (txtReason.Text == "")
            //{
            //    MessageBox.Show("Enter Error Description");
            //    txtReason.Focus();
            //    return false;
            //}
            else if (textRefnumb.Text == "")
            {
                MessageBox.Show("Enter Customer Reference Number");
                textRefnumb.Focus();
                return false;
            }
            return true;
        
        }

        private bool Order_validation()
        {

            //if (Txt_ord_Quantity.Text == "")
            //{
            //    MessageBox.Show("Enter Quantity");
            //    Txt_ord_Quantity.Focus();
            //    return false;
            //}
             if (Txt_ord_Cust_Numb.Text == "")
            {
                MessageBox.Show("Enter Customer Number(FormSheet)");
                Txt_ord_Cust_Numb.Focus();
                return false;
            }
            //else if (Txt_ord__Cust_Num_Org_ord.Text == "")
            //{
            //    MessageBox.Show("Enter Customer Number(Orignal Order)");
            //    Txt_ord__Cust_Num_Org_ord.Focus();
            //    return false;
            //}
            else if (Txt_ord_Original_OrdNum.Text == "")
            {
                MessageBox.Show("Enter Orignal Order Number");
                Txt_ord_Original_OrdNum.Focus();
                return false;
            }
            //else if (dt_Ord_DeliveryDate.Text == "")
            //{
            //    MessageBox.Show("Enter Order Delivery Date");
            //    dt_Ord_DeliveryDate.Focus();
            //    return false;
            //}
            //else if (Txt_ord_Orignal_Quantity.Text == "")
            //{
            //    MessageBox.Show("Enter Orignal Quantity");
            //    Txt_ord_Orignal_Quantity.Focus();
            //    return false;
            //}
            return true;
        }

        private bool Inspection_validation()
        {

            //if (txt_ins_Assess_Dep.Text == "")
            //{
            //    MessageBox.Show("Enter Assesment Department");
            //    txt_ins_Assess_Dep.Focus();
            //    return false;
            //}
            // else
            //if (txt_ins_Operator.Text == "")
            //{
            //    MessageBox.Show("Enter Operator");
            //    txt_ins_Operator.Focus();
            //    return false;
            //}
            //else if (txt_ins_Desc.Text == "")
            //{
            //    MessageBox.Show("Enter Description");
            //    txt_ins_Desc.Focus();
            //    return false;
            //}
            //else if (txt__ins_Diagnosis.Text == "")
            //{
            //    MessageBox.Show("Enter Diagnosis");
            //    txt__ins_Diagnosis.Focus();
            //    return false;
            //}
            //else if (txt_ins_Reason.Text == "")
            //{
            //    MessageBox.Show("Enter Reason");
            //    txt_ins_Reason.Focus();
            //    return false;
            //}
            //else if (Txt_ord_Orignal_Quantity.Text == "")
            //{
            //    MessageBox.Show("Enter Orignal Quantity");
            //    Txt_ord_Orignal_Quantity.Focus();
            //    return false;
            //}
            return true;
        }

        private bool Solution_validation()
        {

            //if (txt_sol_statement.Text == "")
            //{
            //    MessageBox.Show("Enter Statement");
            //    txt_sol_statement.Focus();
            //    return false;
            //}
            //else if (txt_sol_notes.Text == "")
            //{
            //    MessageBox.Show("Enter Notes");
            //    txt_sol_notes.Focus();
            //    return false;
            //}
            //else 
            if ((Cb_Repair_optact.Checked == true) && (txt_sol_Repair.Text == ""))
            {
                MessageBox.Show("Enter Repair Price");
                txt_sol_Repair.Focus();
                return false;
            }
            else if ((Cb_Retour_optact.Checked == true) && (txt_Sol_Retour.Text == ""))
            {
                MessageBox.Show("Enter Retour Price");
                txt_Sol_Retour.Focus();
                return false;
            }
            else if ((Cb_Modification_optact.Checked == true) && (txt_sol_Modification .Text == ""))
            {
                MessageBox.Show("Enter Modification Price");
                txt_sol_Modification.Focus();
                return false;
            }
            else if ((Cb_newprd_optact.Checked == true) && (txt_sol_New_Product.Text == ""))
            {
                MessageBox.Show("Enter New Product Price");
                txt_sol_New_Product.Focus();
                return false;
            }
            else if ((Cb_Disposal_optact.Checked == true) && (txt_sol_Disposal.Text == ""))
            {
                MessageBox.Show("Enter Disposal Price");
                txt_sol_Disposal.Focus();
                return false;
            }
            else if ((Cb_cednote_optact.Checked == true) && (txt_Sol_Credit_note.Text == ""))
            {
                MessageBox.Show("Enter Credit Note Price");
                txt_Sol_Credit_note.Focus();
                return false;
            }
            else if ((Cb_splopt_optact.Checked == true) && (txt_sol_SpclOption.Text == ""))
            {
                MessageBox.Show("Enter Special Options Price");
                txt_sol_SpclOption.Focus();
                return false;
            }

            return true;
        }

        #endregion

        private void BtnOrderEmail_Click(object sender, EventArgs e)
        {
            if (txt_ord_id.Text == "0")
            {
                MessageBox.Show("Save Order First");
                return;
            }
            string EmailCode = "";
            string ref_num = txtService.Text;
            // string Customer = textcname.Text;
            string RMA = "10xxx";
            string phone = "", Email = "";
            if (Rdb_Yes.Checked == true)
            {
                EmailCode = "Yes";
            }

            tbl_Company Company_Obj = TabClasses.CompanyOperations.LoadCompanyData();
            if (Company_Obj != null)
            {
                phone = Company_Obj.Phone_Num;
                Email = Company_Obj.Email;
            }

            string Bodytext = TabClasses.EmailOPerations.CreateBodyText(ref_num, "", EmailCode, RMA, phone, Email, "","");
            string subject = "RMA10xxx: Confirmation of your request";
            string to = txtcp1Email.Text;
            //string message = TabClasses.EmailOPerations.SendEmail(txtRequestID.Text, subject, to, Bodytext);
            string message = TabClasses.EmailOPerations.SendOutlookEmail(txtRequestID.Text, subject, to, Bodytext, "Order_Email_" + txtRequestID.Text);
            if (message == "Mail Sent")
            {
                tbl_OrderData ord = new tbl_OrderData();
                ord.Email_date = DateTime.Now;
                lbl_ord_EmailDate.Text = DateTime.Now.ToString();
                ord.Email_Sent = 1;
                ord.Order_id = Convert.ToInt32(txt_ord_id.Text);

                string res = TabClasses.OrderFunctions.UpdateOrderEmailSent(ord);
                if (res == "Successful")
                {
                    lbl_ord_EmailDate.Visible = true;
                    labelorderEmailSent.Visible = true;
                    //BtnOrderEmail.Enabled = false;
                    BtnOrderEmail.Visible = false;
                    btn_Order_EmEdit.Enabled = false;
                }


            }
            MessageBox.Show(message);
        }

        private void btn_Order_EmEdit_Click(object sender, EventArgs e)
        {
            string EmailCode = "";
            string ref_num = txtService.Text;
            // string Cutomer = textcname.Text;
            string RMA = "10xxx";
            string phone = "", Email = "";
            if (Rdb_Yes.Checked == true)
            {
                EmailCode = "Yes";
            }
            else if (Rdb_No.Checked == true)
            {
                EmailCode = "No";
            }
            else
            {
                EmailCode = "Not Necessary";
            }

            tbl_Company Company_Obj = TabClasses.CompanyOperations.LoadCompanyData();
            if (Company_Obj != null)
            {
                phone = Company_Obj.Phone_Num;
                Email = Company_Obj.Email;
            }
            FormEmailEdit form = new FormEmailEdit(ref_num, "", "", EmailCode, RMA, phone, Email, "", "");
            form.Show();
        }

        private void btn_Ord_OpenEmail_Click(object sender, EventArgs e)
        {
            string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
            string EmailFile = UriPath + "\\files\\Customer_Request_" + txtRequestID.Text + "\\Order_Email_" + txtRequestID.Text + ".txt";

            if (File.Exists(EmailFile))
            {
                System.Diagnostics.Process.Start(EmailFile);

            }
            else
            {
                MessageBox.Show("File Not Found");
            }
        }

        private void btnOrderSave_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Do You want to continue?", "Order Update", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {
                bool check = Order_validation();
                if (check)
                {

                    tbl_OrderData orderData = new tbl_OrderData();
                    orderData.Request_id = Convert.ToInt32(txtRequestID.Text);
                    if (Txt_ord_Quantity.Text != "")
                    {
                        orderData.Quantity = Convert.ToInt32(Txt_ord_Quantity.Text);
                    }
                     

                    orderData.CustomerNumber_FrmSheet = Txt_ord_Cust_Numb.Text;
                    orderData.CustomerNumber_Org = Txt_ord__Cust_Num_Org_ord.Text;
                    orderData.OrginalOrderNumber = Txt_ord_Original_OrdNum.Text;
                    orderData.DeliveryDate = dt_Ord_DeliveryDate.Value;
                    if (Txt_ord_Orignal_Quantity.Text != "")
                    {
                        orderData.Orignal_Quantity = Convert.ToInt32(Txt_ord_Orignal_Quantity.Text);
                    }
                    if (Rdb_Yes.Checked == true)
                    {
                        orderData.Confirmation = "Yes";
                    }
                    else if (Rdb_No.Checked == true)
                    {
                        orderData.Confirmation = "No";
                    }
                    else
                    {
                        orderData.Confirmation = "Not Necessary";
                    }


                    if (rdb_Inside_Period.Checked == true)
                    {
                        orderData.Waranty = "Inside Period";
                    }
                    else if (rdb_Outside_Period.Checked == true)
                    {
                        orderData.Waranty = "Outside Period";
                    }

                    //tbl_OrderData OrderInDb = TabClasses.OrderFunctions.LoadOrderData(Convert.ToInt32(txtRequestID.Text));
                    if (txt_ord_id.Text != "0")
                    {
                        //update
                        orderData.Order_id = Convert.ToInt32(txt_ord_id.Text);
                    }

                    string response = TabClasses.OrderFunctions.SaveOrderData(orderData);
                    if (response == "Successful")
                    {
                        MessageBox.Show("Order Updated");
                    }
                    else
                    {
                        txt_ord_id.Text = response;
                        MessageBox.Show("Order Created");
                    }


                }
            }
        }

        private void btn_ins_Email_Click(object sender, EventArgs e)
        {
            if (txt_ins_InspectionID.Text == "0")
            {
                MessageBox.Show("Save Inspection Infromation First");
                return;
            }
            string EmailCode = "";
            string ref_num = txtService.Text;
            // string Customer = textcname.Text;
            string RMA = "10xxx";
            EmailCode = "Inspection_ExternalDept";

            string to = "";
            tbl_Departments Depart_Obj = TabClasses.InspectionFunctions.LoadOneDepartment(Convert.ToInt32(cmb_ins_department.SelectedValue));
            if (Depart_Obj != null)
            {
                to = Depart_Obj.Email;
            }

            string Bodytext = TabClasses.EmailOPerations.CreateInspectionBodyText(ref_num, cmb_ins_department.Text, cmb_Ins_ServiceTask.Text, EmailCode, RMA, txt_ins_Operator.Text);
            string subject = "Subject: RMA10xxx: Task to do";
            string message = TabClasses.EmailOPerations.SendOutlookEmail(txtRequestID.Text, subject, to, Bodytext, "Inspection_Email_" + txt_ins_InspectionID.Text);
            if (message == "Mail Sent")
            {
                tbl_Inspection ins = new tbl_Inspection();
                ins.Email_date = DateTime.Now;
                lb_ins_emailSent.Text = "Sent On: " + DateTime.Now.ToString();
                ins.Email_Sent = 1;
                ins.InspectionID = Convert.ToInt32(txt_ins_InspectionID.Text);

                string res = TabClasses.InspectionFunctions.UpdateInspectionEmailSent(ins);
                if (res == "Successful")
                {
                    lb_ins_emailSent.Visible = false;
                    btn_ins_Email.Enabled = false;
                    // btn_ins_email_edit.Enabled = false;
                    btn_ins_email_edit.Visible = false;
                }


            }
            MessageBox.Show(message);
        }

        private void btn_ins_email_edit_Click(object sender, EventArgs e)
        {
            string EmailCode = "";
            string ref_num = txtService.Text;
            // string Cutomer = textcname.Text;
            string RMA = "10xxx";
            string phone = "", Email = "";
            EmailCode = "Inspection_ExternalDept";

            tbl_Company Company_Obj = TabClasses.CompanyOperations.LoadCompanyData();
            if (Company_Obj != null)
            {
                phone = Company_Obj.Phone_Num;
                Email = Company_Obj.Email;
            }
            FormEmailEdit form = new FormEmailEdit(ref_num, cmb_Ins_ServiceTask.Text, cmb_ins_department.Text, EmailCode, RMA, phone, Email,"", "");
            form.Show();
        }

        private void btn_ins_Openemail_Click(object sender, EventArgs e)
        {
            string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
            string EmailFile = UriPath + "\\files\\Customer_Request_" + txtRequestID.Text + "\\Inspection_Email_" + txt_ins_InspectionID.Text + ".txt";

            if (File.Exists(EmailFile))
            {
                System.Diagnostics.Process.Start(EmailFile);

            }
            else
            {
                MessageBox.Show("File Not Found");
            }
        }

        private void btn_Ins_CreateReport_Click(object sender, EventArgs e)
        {
            string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;            
            string FolderPath = UriPath + "\\files\\Customer_Request_" + txtRequestID.Text;
            System.IO.Directory.CreateDirectory(FolderPath);

            string EmailFile = UriPath + "\\files\\Customer_Request_" + txtRequestID.Text + "\\InspectionReport.xlsx";

            if (File.Exists(EmailFile))
            {
                System.Diagnostics.Process.Start(EmailFile);

            }
            else
            {
                var app = new Microsoft.Office.Interop.Excel.Application();
                var wb = app.Workbooks.Add();
                wb.SaveAs(EmailFile);
                wb.Close();
                System.Diagnostics.Process.Start(EmailFile);
                // MessageBox.Show("File Not Found");
            }
        }

        private void btn_Ins_Create8DReport_Click(object sender, EventArgs e)
        {
            string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
            string FolderPath = UriPath + "\\files\\Customer_Request_" + txtRequestID.Text;
            System.IO.Directory.CreateDirectory(FolderPath);

            string EmailFile = UriPath + "\\files\\Customer_Request_" + txtRequestID.Text + "\\8D-Report.xlsx";

            if (File.Exists(EmailFile))
            {
                System.Diagnostics.Process.Start(EmailFile);

            }
            else
            {
                var app = new Microsoft.Office.Interop.Excel.Application();
                var wb = app.Workbooks.Add();
                wb.SaveAs(EmailFile);
                wb.Close();
                System.Diagnostics.Process.Start(EmailFile);
                // MessageBox.Show("File Not Found");
            }
        }

        private void btn_ins_Save_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Do You want to continue?", "Inspection Update", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {
                bool check = Inspection_validation();
                if (check)
                {



                    tbl_Inspection InspectionData = new tbl_Inspection();
                    InspectionData.RequestId = Convert.ToInt32(txtRequestID.Text);
                    InspectionData.OrderId = Convert.ToInt32(txt_ord_id.Text);
                    InspectionData.InspectionID = Convert.ToInt32(txt_ins_InspectionID.Text);
                    InspectionData.Department = Convert.ToInt32(cmb_ins_department.SelectedValue);
                    InspectionData.Operator = txt_ins_Operator.Text;
                    if (RDB_ins_yes.Checked == true)
                    {
                        InspectionData.Complaint = "Yes";
                    }
                    else
                    {
                        InspectionData.Complaint = "No";
                    }
                    InspectionData.ServiceTask = Convert.ToInt32(cmb_Ins_ServiceTask.SelectedValue);
                    InspectionData.Diagnosis = Convert.ToInt32(cmb_Ins_Diagnosis.SelectedValue);
                    InspectionData.Reason = Convert.ToInt32(cmb_Ins_Reason.SelectedValue);
                    InspectionData.Description = txt_ins_Desc.Text;
                    InspectionData.ReportDone = txt_ins_rep_done.Text;
                    InspectionData.report8DDone = txt_ins_8D_rep.Text;

                    string response = TabClasses.InspectionFunctions.SaveInspectionData(InspectionData);
                    if (response == "Successful")
                    {
                        MessageBox.Show("Inspection Updated");
                    }
                    else
                    {
                        txt_ins_InspectionID.Text = response;
                        MessageBox.Show("Inspection Created");
                    }

                }
            }
        }

        private void Btn_Sol_Email_Click(object sender, EventArgs e)
        {
            string RMA = "10xxx";
            string phone = "", Email = "";           
            tbl_Company Company_Obj = TabClasses.CompanyOperations.LoadCompanyData();
            if (Company_Obj != null)
            {
                phone = Company_Obj.Phone_Num;
                Email = Company_Obj.Email;
            }

            string Bodytext = TabClasses.EmailOPerations.CreateBodyText(txtService.Text, "", "Solution", RMA, phone, Email,"","");
            string subject = "RMA10xxx: Confirmation of your request";
            string to = txtcp1Email.Text;
            string message = TabClasses.EmailOPerations.SendOutlookEmail(txtRequestID.Text, subject, to, Bodytext, "Solution_Email_" + txtRequestID.Text);
        }

        private void btn_sol_save_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Do You want to continue?", "Solution Update", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {
                bool check = Solution_validation();
                if (check)
                {
                    SolutionVM SolutionData = new SolutionVM();
                    SolutionData.solution = new tbl_Solution();
                    SolutionData.options = new List<tbl_SolutionOptions>();

                    SolutionData.solution.Notes = txt_sol_notes.Text;
                    SolutionData.solution.reminder1 = txt_sol_rem1.Text;
                    SolutionData.solution.reminder2 = txt_sol_rem2.Text;
                    SolutionData.solution.request_id = Convert.ToInt32(txtRequestID.Text);
                    SolutionData.solution.solution_id = Convert.ToInt32(txt_Sol_SolutionId.Text);
                    SolutionData.solution.statement = txt_sol_statement.Text;

                    

                    SolutionData.options = SelectedOptions(Convert.ToInt32(txt_Sol_SolutionId.Text), Convert.ToInt32(txtRequestID.Text));
                    if (SolutionData.options.Count() > 0)
                    {

                        string response = TabClasses.SolutionOperations.SaveSolutionData(SolutionData);
                        if (response == "Successful")
                        {
                            printSolPdf(SolutionData);
                            //pass solution data.
                            //
                          //  TabClasses.SolutionOperations.IronPdf(SolutionData);
                            MessageBox.Show("Solution Updated");
                        }
                        else
                        {
                            //TabClasses.SolutionOperations.IronPdf(SolutionData);
                            printSolPdf(SolutionData);
                            txt_Sol_SolutionId.Text = response;
                            MessageBox.Show("Solution Created");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select atleast 1 option for action");
                    }

                }
            }
        }

        private void txtPrio_SelectedValueChanged(object sender, EventArgs e)
        {
            if (txtPrio.SelectedIndex == 0)
            {
                txtPrio.BackColor = Color.Red;
            }
            else if (txtPrio.SelectedIndex == 1)
            {
                txtPrio.BackColor = Color.Orange;
            }
            else if (txtPrio.SelectedIndex == 2)
            {
                txtPrio.BackColor = Color.Green;
            }
        }
        
        private void Cb_Repair_optact_OnChange(object sender, EventArgs e)
        {
            if (Cb_Repair_optact.Checked == true)
            {
                txt_sol_Repair.Enabled = true;
                Cb_Repair_deccust.Enabled = true;
                txt_sol_Repair.HintForeColor = Color.Black;
                
            }
            else
            {
                txt_sol_Repair.Text = "";               
                txt_sol_Repair.Enabled = false;                
                Cb_Repair_deccust.Checked = false;
                Cb_Repair_deccust.Enabled = false;
            }
        }

        private void Cb_Retour_optact_OnChange(object sender, EventArgs e)
        {
            if (Cb_Retour_optact.Checked == true)
            {
                txt_Sol_Retour.Enabled = true;
                Cb_Retour_deccust.Enabled = true;
            }
            else
            {
                txt_Sol_Retour.Text = "";                
                txt_Sol_Retour.Enabled = false;
                Cb_Retour_deccust.Checked = false;
                Cb_Retour_deccust.Enabled = false;
            }
        }

        private void Cb_Modification_optact_OnChange(object sender, EventArgs e)
        {
            if (Cb_Modification_optact.Checked == true)
            {
                txt_sol_Modification.Enabled = true;
                Cb_Modification_deccust.Enabled = true;
            }
            else
            {
                txt_sol_Modification.Text = "";
                txt_sol_Modification.Enabled = false;
                Cb_Modification_deccust.Checked = false;
                Cb_Modification_deccust.Enabled = false;
            }
        }

        private void Cb_newprd_optact_OnChange(object sender, EventArgs e)
        {
            if (Cb_newprd_optact.Checked == true)
            {
                txt_sol_New_Product.Enabled = true;
                Cb_newprd_deccust.Enabled = true;
            }
            else
            {
                txt_sol_New_Product.Text = "";
                txt_sol_New_Product.Enabled = false;
                Cb_newprd_deccust.Checked = false;
                Cb_newprd_deccust.Enabled = false;
            }
        }

        private void Cb_Disposal_optact_OnChange(object sender, EventArgs e)
        {
            if (Cb_Disposal_optact.Checked == true)
            {
                txt_sol_Disposal.Enabled = true;
                Cb_disposal_deccust.Enabled = true;
            }
            else
            {
                txt_sol_Disposal.Text = "";
                txt_sol_Disposal.Enabled = false;
                Cb_disposal_deccust.Checked = false;
                Cb_disposal_deccust.Enabled = false;
            }
        }

        private void Cb_cednote_optact_OnChange(object sender, EventArgs e)
        {
            if (Cb_cednote_optact.Checked == true)
            {
                txt_Sol_Credit_note.Enabled = true;
                Cb_crdnote_deccust.Enabled = true;
            }
            else
            {
                txt_Sol_Credit_note.Text = "";
                txt_Sol_Credit_note.Enabled = false;
                Cb_crdnote_deccust.Checked = false;
                Cb_crdnote_deccust.Enabled = false;
            }
        }

        private void Cb_splopt_optact_OnChange(object sender, EventArgs e)
        {
            if (Cb_splopt_optact.Checked == true)
            {
                txt_sol_SpclOption.Enabled = true;
                Cb_splopt_deccust.Enabled = true;
            }
            else
            {
                txt_sol_SpclOption.Text = "";
                txt_sol_SpclOption.Enabled = false;
                Cb_splopt_deccust.Checked = false;
                Cb_splopt_deccust.Enabled = false;
            }
        }
        
        private IEnumerable<tbl_SolutionOptions> SelectedOptions (int solutionid, int requestid)
        {
            List<tbl_SolutionOptions> options = new List<tbl_SolutionOptions>();

            if (Cb_Repair_optact.Checked == true)
            {
                tbl_SolutionOptions opRepair = new tbl_SolutionOptions();
                opRepair.request_id = requestid;
                opRepair.solution_id = solutionid;
                opRepair.Options = "Repair";
                opRepair.price = Convert.ToDouble(txt_sol_Repair.Text);
                if (Cb_Repair_deccust.Checked)
                {
                    opRepair.decision = true;
                        }
                else
                {
                    opRepair.decision = false;
                }
                options.Add(opRepair);
            }

            if (Cb_Retour_optact.Checked == true)
            {
                tbl_SolutionOptions opRetour = new tbl_SolutionOptions();
                opRetour.request_id = requestid;
                opRetour.solution_id = solutionid;
                opRetour.Options = "Retour";
                opRetour.price = Convert.ToDouble(txt_Sol_Retour.Text);
                if (Cb_Retour_deccust.Checked)
                {
                    opRetour.decision = true;
                }
                else
                {
                    opRetour.decision = false;
                }
                options.Add(opRetour);
            }

            if (Cb_Modification_optact.Checked == true)
            {
                tbl_SolutionOptions opModification = new tbl_SolutionOptions();
                opModification.request_id = requestid;
                opModification.solution_id = solutionid;
                opModification.Options = "Modification";
                opModification.price = Convert.ToDouble(txt_sol_Modification.Text);
                if (Cb_Modification_deccust.Checked)
                {
                    opModification.decision = true;
                }
                else
                {
                    opModification.decision = false;
                }
                options.Add(opModification);
            }
           

            if (Cb_newprd_optact.Checked == true)
            {
                tbl_SolutionOptions opNewProd = new tbl_SolutionOptions();
                opNewProd.request_id = requestid;
                opNewProd.solution_id = solutionid;
                opNewProd.Options = "New Product";
                opNewProd.price = Convert.ToDouble(txt_sol_New_Product.Text);
                if (Cb_newprd_deccust.Checked)
                {
                    opNewProd.decision = true;
                }
                else
                {
                    opNewProd.decision = false;
                }
                options.Add(opNewProd);
            }

            if (Cb_Disposal_optact.Checked == true)
            {
                tbl_SolutionOptions opDisposal = new tbl_SolutionOptions();
                opDisposal.request_id = requestid;
                opDisposal.solution_id = solutionid;
                opDisposal.Options = "Disposal";
                opDisposal.price = Convert.ToDouble(txt_sol_Disposal .Text);
                if (Cb_disposal_deccust.Checked)
                {
                    opDisposal.decision = true;
                }
                else
                {
                    opDisposal.decision = false;
                }
                options.Add(opDisposal);
            }

            if (Cb_cednote_optact.Checked == true)
            {
                tbl_SolutionOptions opCredit = new tbl_SolutionOptions();
                opCredit.request_id = requestid;
                opCredit.solution_id = solutionid;
                opCredit.Options = "Credit Note";
                opCredit.price = Convert.ToDouble(txt_Sol_Credit_note.Text);
                if (Cb_crdnote_deccust.Checked)
                {
                    opCredit.decision = true;
                }
                else
                {
                    opCredit.decision = false;
                }
                options.Add(opCredit);
            }

            if (Cb_splopt_optact.Checked == true)
            {
                tbl_SolutionOptions opSpecialOption = new tbl_SolutionOptions();
                opSpecialOption.request_id = requestid;
                opSpecialOption.solution_id = solutionid;
                opSpecialOption.Options = "Special Options";
                opSpecialOption.price = Convert.ToDouble(txt_sol_SpclOption.Text);
                if (Cb_splopt_deccust.Checked)
                {
                    opSpecialOption.decision = true;
                }
                else
                {
                    opSpecialOption.decision = false;
                }
                options.Add(opSpecialOption);
            }

            return options;
        }

        private void btnPrintInfoFile_Click(object sender, EventArgs e)
        {
            // TabClasses.SolutionOperations.PrintInfoPdf();
            //TabClasses.SolutionOperations.testPrintFile();
            //SolutionVM testSol = new SolutionVM();
            //  testSol.solution.id
            //  TabClasses.SolutionOperations.IronPdf(testSol);


            string original = System.IO.File.ReadAllText(Application.StartupPath + @"\templates\temp1.html", Encoding.UTF8);
            string updated = original;
            string randomTempFileName = Path.GetTempFileName() + ".html";
            string randomTempFileNamePDF = Path.GetTempFileName() + ".pdf";

            updated = updated.Replace("(RMA)",  txtService.Text);
            updated = updated.Replace("(RMA-Nr.)", "RMA Number:   " + txtService.Text);
            updated = updated.Replace("(tt.mm.yyyy)", "Service Request Date:   "+ txtDateofEntry.Text);
            updated = updated.Replace("(Company)", txtCompany.Text);
            updated = updated.Replace("(Street)", txtStreet.Text);
            updated = updated.Replace("(Zip Code and city)", txtZipcode.Text);
            //updated = updated.Replace("(RMA)", txtService.Text);
            //updated = updated.Replace("(RMA)", txtService.Text);
            //updated = updated.Replace("(RMA)", txtService.Text);


            using (System.IO.StreamWriter writetext = new System.IO.StreamWriter(randomTempFileName))
            {
                writetext.Write(updated);
            }

            /// System.IO.File.WriteAllText(@"C:\Users\hp1\Desktop\templateupdated.html", updated);

            var startinfo = new ProcessStartInfo(Application.StartupPath + @"\wkhtmltopdf\wkhtmltopdf.exe")
            {
                WindowStyle = ProcessWindowStyle.Normal,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = string.Format(" --load-error-handling ignore {0} {1} ", randomTempFileName, randomTempFileNamePDF)
            };

            Process process = new Process { StartInfo = startinfo };

            process.OutputDataReceived += delegate (object sendere, DataReceivedEventArgs ee) { convert_OutputDataReceived(sendere, ee, process); };
            process.ErrorDataReceived += delegate (object sendere, DataReceivedEventArgs ee) { convert_ErrorDataReceived(sendere, ee, process); };
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();


            if (System.IO.File.Exists(randomTempFileNamePDF))
            {
                Process.Start(randomTempFileNamePDF);
            }
        }


        void convert_OutputDataReceived(object sender, DataReceivedEventArgs e, Process process)
        {
            if (!string.IsNullOrEmpty(e.Data))
                Console.WriteLine(e.Data);
        }

        void convert_ErrorDataReceived(object sender, DataReceivedEventArgs e, Process process)
        {
            if (!string.IsNullOrEmpty(e.Data))
                Console.WriteLine(e.Data);
        }


      void printSolPdf(SolutionVM solution)
        {           

            string original = System.IO.File.ReadAllText(Application.StartupPath + @"\templates\temp1.html", Encoding.UTF8);
            string updated = original;
            string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
            string randomTempFileName = UriPath + "\\files\\Customer_Request_" + txtService.Text + "\\" + "Infopaket_EN" + ".html";
            string randomTempFileNamePDF = UriPath + "\\files\\Customer_Request_" + txtService.Text + "\\" + "Info-PDF" + ".pdf";

            //  string randomTempFileName = Path.GetTempFileName() + ".html";
            //string randomTempFileNamePDF = Path.GetTempFileName() + ".pdf";//

            updated = updated.Replace("(RMA)", txtService.Text);
            updated = updated.Replace("(RMA-Nr.) (tt.mm.yyyy)", "RMA Number:   " + txtService.Text + "    Service Request Date: " + txtDateofEntry.Text );
            updated = updated.Replace("(tt.mm.yyyy)", dt_Ord_DeliveryDate.Value.ToString());
            updated = updated.Replace("(Date of Entry)",  txtDateofEntry.Text);
            updated = updated.Replace("(Customer Reference Number)", textRefnumb.Text);
            updated = updated.Replace("(Company)", textcompany.Text);
            updated = updated.Replace("(Street)", textstreet.Text);
            updated = updated.Replace("(Zip Code and city)", textzip.Text);
            updated = updated.Replace("(Country)", textcountry.Text);

            updated = updated.Replace("(Name)", txtcp1Name.Text);
            updated = updated.Replace("(Email)", txtcp1Email.Text);
            updated = updated.Replace("(Phone)", txtcp1Phone.Text);

            updated = updated.Replace("(Service Request)", cmbIssues.Text);
            updated = updated.Replace("(Reason from problem description)", txtReason.Text);
            updated = updated.Replace(" (from original quantity)", Txt_ord_Orignal_Quantity.Text);

            updated = updated.Replace("(From Diagnosis and Diagnosis Type Box)", cmb_Ins_Diagnosis.Text + " & " +cmb_Ins_ServiceTask.Text);
            updated = updated.Replace("(From Description Textbox in Inspection section)", txt_ins_Desc.Text);

            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            string OptionStr = "";
            foreach (var options in solution.options)
            { 
                OptionStr = OptionStr + "<tr><td width=\"312\" style=\"border-bottom:1pt solid black; \"><p>" + options.Options + ":</p></td> <td width =\"168\" style=\"border-bottom:1pt solid black; \"><p>" + options.price  + " EUR</p></td></tr>";
            }
            updated = updated.Replace("<tr>(options)</tr>", OptionStr);


            using (System.IO.StreamWriter writetext = new System.IO.StreamWriter(randomTempFileName))
            {
                writetext.Write(updated);
            }

            /// System.IO.File.WriteAllText(@"C:\Users\hp1\Desktop\templateupdated.html", updated);

            var startinfo = new ProcessStartInfo(Application.StartupPath + @"\wkhtmltopdf\wkhtmltopdf.exe")
            {
                WindowStyle = ProcessWindowStyle.Normal,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = string.Format(" --load-error-handling ignore {0} {1} ", randomTempFileName, randomTempFileNamePDF)
            };

            Process process = new Process { StartInfo = startinfo };

            process.OutputDataReceived += delegate (object sendere, DataReceivedEventArgs ee) { convert_OutputDataReceived(sendere, ee, process); };
            process.ErrorDataReceived += delegate (object sendere, DataReceivedEventArgs ee) { convert_ErrorDataReceived(sendere, ee, process); };
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();


            if (System.IO.File.Exists(randomTempFileNamePDF))
            {
                Process.Start(randomTempFileNamePDF);
            }
        }

       
        private void btn_completion_Save_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Do You want to continue?", "Completion Update", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {
                

                    tbl_Completion CompletionData = new tbl_Completion();
                    CompletionData.request_id = Convert.ToInt32(txtRequestID.Text);
                    CompletionData.order_number = txt_completion_orderNum.Text;
                    CompletionData.credite_note_number = txt_completion_CrediteNote.Text;
                    CompletionData.Disposal = txt_completion_Disposal.Text;



             //   CompletionData.

                    //tbl_OrderData OrderInDb = TabClasses.OrderFunctions.LoadOrderData(Convert.ToInt32(txtRequestID.Text));
                    if (txt_completionId.Text != "0")
                    {
                        //update
                        CompletionData.Completion_id = Convert.ToInt32(txt_completionId.Text);
                    }

                    string response = TabClasses.CompletionOperations.SaveCompletionData(CompletionData);
                    if (response == "Successful")
                    {
                        MessageBox.Show("Completion Updated");
                    }
                    else
                    {
                        txt_completionId.Text = response;
                        MessageBox.Show("Completion Created");
                    }


                }
            
        }

        private void btn_completion_email_Click(object sender, EventArgs e)
        {
            string message = TabClasses.EmailOPerations.SendOutlookEmail("", "", "", "", "Completion_Email_User");
        }

        private void btn_ArchiveScreen_Click(object sender, EventArgs e)
        {
            this.Hide();
            Archive archives = new Archive();
            archives.Show();
        }

        private void btn_completion_EvaluationEmail_Click(object sender, EventArgs e)
        {
            if ( txt_completionId.Text != "0")
                {
                    string EmailCode = "Evaluation";
                    string ref_num = txtService.Text;
                    // string Customer = textcname.Text;
                    string RMA = "10xxx";
                    string phone = "", Email = "", companyName = "", Evaluation = "";


                    tbl_Company Company_Obj = TabClasses.CompanyOperations.LoadCompanyData();
                    if (Company_Obj != null)
                    {
                        phone = Company_Obj.Phone_Num;
                        Email = Company_Obj.Email;
                        companyName = Company_Obj.Comapany_Name;

                    }
                    Evaluation = txt_completionId.Text;
                    string Bodytext = TabClasses.EmailOPerations.CreateBodyText(ref_num, "", EmailCode, RMA, phone, Email, companyName, Evaluation);
                    string subject = "RMA10xxx: Cutomer Service Evaluation Request";
                    string to = txtcp1Email.Text;
                    //string message = TabClasses.EmailOPerations.SendEmail(txtRequestID.Text, subject, to, Bodytext);
                    string message = TabClasses.EmailOPerations.SendOutlookEmail(txtRequestID.Text, subject, to, Bodytext, "Evaluation_Email_" + txtRequestID.Text);
                    if (message == "Mail Sent")
                    {

                        tbl_Completion Eval = new tbl_Completion();
                        Eval.Email_date = DateTime.Now;
                        lbl_completionDate.Text = DateTime.Now.ToString();
                        Eval.Email_Sent = Convert.ToInt32(txt_Emailcount.Text) + 1;
                        Eval.Completion_id = Convert.ToInt32(txt_completionId.Text);
                        txt_Emailcount.Text = (Eval.Email_Sent).ToString();

                        string res = TabClasses.CompletionOperations.UpdateCompletionEvalEmailSent(Eval);
                        if (res == "Successful")
                        {
                            lbl_completionEmail.Visible = true;
                            lbl_completionDate.Visible = true;
                            lblEmailcount.Visible = true;
                            lblEmailcounttext.Visible = true;
                            lblEmailcount.Text = txt_Emailcount.Text;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Save completion phase before sending email");
                }
        }

        private void btn_completionEditEmail_Click(object sender, EventArgs e)
        {            
            string ref_num = txtService.Text;
            // string Cutomer = textcname.Text;
            string RMA = "10xxx";
            string phone = "", Email = "", companyName="", evaluationLink="";
            string EmailCode = "Evaluation";

            tbl_Company Company_Obj = TabClasses.CompanyOperations.LoadCompanyData();
            if (Company_Obj != null)
            {
                phone = Company_Obj.Phone_Num;
                Email = Company_Obj.Email;
                companyName = Company_Obj.Comapany_Name;
               
            }
            evaluationLink = txt_completionId.Text;
            FormEmailEdit form = new FormEmailEdit(ref_num, cmb_Ins_ServiceTask.Text, txtcp1Name.Text, EmailCode, RMA, phone, Email,companyName, evaluationLink);
            form.Show();
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Sol_preview_Click(object sender, EventArgs e)
        {
            string UriPath = new Uri(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
            string FolderPath = UriPath +  "\\files\\Customer_Request_" + txtRequestID.Text + "\\Info-PDF.pdf";
            if (File.Exists(FolderPath))
            {
                System.Diagnostics.Process.Start("explorer.exe", FolderPath);
            }
            else
            {
                MessageBox.Show("Save Solution data first to preview file.");
            }

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
          //  MessageBox.Show("Please Save your work.");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Please Save your work.");
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
           // MessageBox.Show("Please Save your work.");
        }
    }
}
