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
using System.Diagnostics;
using System.Net.Http;

namespace customerServiceSoftware
{
    public partial class main : Form
    {
      
        public main()
        {
            InitializeComponent();
            ToolTip buttonToolTip = new ToolTip();    ;
           // buttonToolTip.SetToolTip(btn_main_departments, "Add Department");
            buttonToolTip.SetToolTip(btn_main_Diagnosis, "Add Diagnosis");
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
            loadGrid();

        }     

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

        //private void btn_main_departments_Click(object sender, EventArgs e)
        //{
        //    Add_department form = new Add_department();
        //    form.Show();
        //}

        private void btn_main_Diagnosis_Click(object sender, EventArgs e)
        {
            Add_Diagnosis form = new Add_Diagnosis();
            form.Show();
        }            

        private void btn_main_del_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = mainCustomerDataDisplay.CurrentRow;
            if (!row.IsNewRow)
            {
                DialogResult m = MessageBox.Show("Do You want to continue?", "Delete Case", MessageBoxButtons.YesNo);
                if (m == DialogResult.Yes)
                {
                    lblCase.Text = row.Cells["ID"].Value.ToString();

                    tbl_customer_request custReq = new tbl_customer_request();
                    custReq.Request_id = Convert.ToInt32(row.Cells["Request_id"].Value);                   

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                        //client.BaseAddress = new Uri("http://localhost:58989/");
                        var request = Newtonsoft.Json.JsonConvert.SerializeObject(custReq);
                        HttpResponseMessage response = client.PutAsJsonAsync("api/_CustomerRequest/DeleteServiceCase", request).Result;
                        var result = response.Content.ReadAsAsync<string>().Result;
                        if (result == "Successful")
                        {
                            //  mainCustomerDataDisplay.Rows.RemoveAt(mainCustomerDataDisplay.CurrentRow.Index);
                            loadGrid();
                            MessageBox.Show("Case Deleted!");
                        }
                    }


                }
            }
            else
            {
                MessageBox.Show("Select Service Case to delete");
            }
        }

        private void btn_main_archive_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = mainCustomerDataDisplay.CurrentRow;
            if (!row.IsNewRow)
            {
                DialogResult m = MessageBox.Show("Do You want to continue?", "Archive Case", MessageBoxButtons.YesNo);
                if (m == DialogResult.Yes)
                {
                    lblCase.Text = row.Cells["ID"].Value.ToString();

                    tbl_customer_request custReq = new tbl_customer_request();
                    custReq.Request_id = Convert.ToInt32(row.Cells["Request_id"].Value);

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                       // client.BaseAddress = new Uri("http://localhost:58989/");
                        var request = Newtonsoft.Json.JsonConvert.SerializeObject(custReq);
                        HttpResponseMessage response = client.PutAsJsonAsync("api/_CustomerRequest/ArchiveServiceCase", request).Result;
                        var result = response.Content.ReadAsAsync<string>().Result;
                        if (result == "Successful")
                        {
                            //  mainCustomerDataDisplay.Rows.RemoveAt(mainCustomerDataDisplay.CurrentRow.Index);
                            loadGrid();
                            MessageBox.Show("Case Archived!");
                        }
                    }


                }
            }
            else
            {
                MessageBox.Show("Select Service Case to Archive");
            }
        }

        public void loadGrid()
        {
            try
            {
                //DataTable dt = new DataTable();
                // dt = opr.mainTableDataLoadData(info);

                IEnumerable<MainDataVM> OfficeLevelOne = new List<MainDataVM>();
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.BaseAddress = new Uri(AppConfigReader.WebServiceUrl);
                    //client.BaseAddress = new Uri("http://localhost:58989/");
                    int companyID = Convert.ToInt32(AppConfigReader.CompanyId);

                    // Get grid data
                    //string url = " api/_CustomerRequest/GetAllCustomerRequests";
                    string url = " api/_CustomerRequest/GetMainRequest?CompanyID=" + companyID;
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        OfficeLevelOne = response.Content.ReadAsAsync<IEnumerable<MainDataVM>>().Result;
                        mainCustomerDataDisplay.DataSource = OfficeLevelOne;
                        mainCustomerDataDisplay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // to resize the coloumn with wrt window size
                        mainCustomerDataDisplay.ClearSelection();



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

        private void btn_main_add_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_ServiceCase service = new Add_ServiceCase();
            service.Show();
        }

        private void mainCustomerDataDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mainCustomerDataDisplay.RowCount > 0)
            {
                DataGridViewRow row = mainCustomerDataDisplay.CurrentRow;
                if (!row.IsNewRow)
                {
                    lblCase.Text = row.Cells["Case"].Value.ToString();
                    lblPriority.Text = row.Cells["Priority"].Value.ToString();
                    lblStatus.Text = row.Cells["Status"].Value.ToString();
                    System.DateTime date =  Convert.ToDateTime(row.Cells["Date"].Value.ToString());
                    lblCreatedOn.Text = date.ToString("MM/dd/yyyy");
                    date = Convert.ToDateTime(row.Cells["LastModified"].Value.ToString());
                    lblModifiedOn.Text = date.ToString("MM/dd/yyyy"); //row.Cells["LastModified"].Value.ToString();
                    lblServiceReason.Text = row.Cells["ServiceReason"].Value.ToString();
                }
            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            Window_change();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
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

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Window_change();
        }             

        private void btn_main_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }       

        private void mainCustomerDataDisplay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (mainCustomerDataDisplay.RowCount > 0)
                {
                    DataGridViewRow row = mainCustomerDataDisplay.CurrentRow;
                    if (!row.IsNewRow)
                    {
                        int req_id = Convert.ToInt32(row.Cells["Case"].Value);
                        this.Hide();
                        Form_ServiceInfo form = new Form_ServiceInfo(req_id, "");
                        form.Show();
                    }
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Do you want to copy the cases in Excel?", "Copy All Cases", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes)
            {
                copyAlltoClipboard();
                CopyTpExcel();
            }
        }

        private void copyAlltoClipboard()
        {
            mainCustomerDataDisplay.SelectAll();
            DataObject dataObj = mainCustomerDataDisplay.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void CopyTpExcel()
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void mainCustomerDataDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Copy"));                
                    int currentMouseOverRow = mainCustomerDataDisplay.HitTest(e.X, e.Y).RowIndex;
                    m.Show(mainCustomerDataDisplay, new Point(e.X, e.Y));
                DialogResult d = MessageBox.Show("Do you want to copy the cases in Excel?", "Copy Selected Cases", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    if (mainCustomerDataDisplay.GetCellCount(DataGridViewElementStates.Selected) > 0)
                    {
                        try
                        {
                            // Add the selection to the clipboard.
                            Clipboard.SetDataObject(mainCustomerDataDisplay.GetClipboardContent());
                            // Replace the text box contents with the clipboard text. 

                            CopyTpExcel();
                        }
                        catch (System.Runtime.InteropServices.ExternalException)
                        {

                            MessageBox.Show("The Clipboard could not be accessed. Please try again.");
                        }
                    }
                }

            }
            }

        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            Create_User_CompanyAdmin user = new Create_User_CompanyAdmin();
            user.Show();
        }

        private void btn_Add_Company_Click(object sender, EventArgs e)
        {
            CompanyControls_Owner company = new CompanyControls_Owner();
            company.Show();

        }
    }
}