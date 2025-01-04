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
    public partial class Archive : Form
    {
        public Archive()
        {
            InitializeComponent();
            ToolTip buttonToolTip = new ToolTip(); ;
            // buttonToolTip.SetToolTip(btn_main_departments, "Add Department");
            buttonToolTip.SetToolTip(btn_unarchive, "Unarchive Case");
            buttonToolTip.SetToolTip(btn_main_home, "Home"); 
            loadGrid();
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

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            Window_change();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void Archive_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
            //this.Drag_Archive.TargetControl = Header_Archive;
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Window_change();
        }

        public void loadGrid()
        {

            IEnumerable <sp_GetArchiveGriddata_Result> gridData = TabClasses.ArchiveOperations.loadGrid();
            ArchiveCustomerDataDisplay.DataSource = gridData;
            ArchiveCustomerDataDisplay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // to resize the coloumn with wrt window size
          //  ArchiveCustomerDataDisplay.ClearSelection();
          //  LabelFilling();            
        }

        private void ArchiveCustomerDataDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LabelFilling();
        }


        public void LabelFilling()
        {
            if (ArchiveCustomerDataDisplay.RowCount > 0)
            {
                DataGridViewRow row = ArchiveCustomerDataDisplay.CurrentRow;
                //if (row == null)
                //{
                //    ArchiveCustomerDataDisplay.Rows[0].Selected = true;
                //    row = ArchiveCustomerDataDisplay.Rows[0].Selected;
                //}
                if (!row.IsNewRow)
                {
                    lbl_ArchCompany.Text = row.Cells["Company"].Value.ToString();
                    lbl_ArchStreet.Text = row.Cells["street"].Value.ToString();
                    lbl_Archzip.Text = row.Cells["Zipcode"].Value.ToString();
                    lbl_Archcountry.Text = row.Cells["Country"].Value.ToString();

                    if (row.Cells["Quantity"].Value.ToString() != "0")
                    {
                        lbl_Archquantity.Text = row.Cells["Quantity"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archquantity.Text = ".....";
                    }
                    if (row.Cells["Order_id"].Value.ToString() != "0")
                    {
                        lbl_Archorder.Text = row.Cells["Order_id"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archorder.Text = ".....";
                    }

                    if (row.Cells["Waranty"].Value.ToString() !="")
                    {
                        lbl_Archinside_period.Text = row.Cells["Waranty"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archinside_period.Text = ".....";
                    }

                    if (row.Cells["DeliveryDate"].Value  != null)
                    {
                        lbl_ArchDelivery_date.Text = row.Cells["DeliveryDate"].Value.ToString();
                    }
                    else
                    {
                        lbl_ArchDelivery_date.Text = ".....";
                    }
                    if (row.Cells["Orignal_Quantity"].Value.ToString() != "0")
                    {
                        lbl_Archorignal_quantity.Text = row.Cells["Orignal_Quantity"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archorignal_quantity.Text = ".....";
                    }

                    if (row.Cells["Dep_Name"].Value.ToString() != "")
                    {
                        lbl_Archassessment_Dept.Text = row.Cells["Dep_Name"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archassessment_Dept.Text = ".....";
                    }
                    if (row.Cells["Operator"].Value.ToString() != "")
                    {
                        lbl_Archoperator.Text = row.Cells["Operator"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archoperator.Text = ".....";
                    }
                    if (row.Cells["Complaint"].Value.ToString() != "")
                    {
                        lbl_Archcomplian.Text = row.Cells["Complaint"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archcomplian.Text = ".....";
                    }
                    if (row.Cells["Categories"].Value.ToString() != "")
                    {
                        lbl_Archdiagnosis_cat.Text = row.Cells["Categories"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archdiagnosis_cat.Text = ".....";
                    }
                    if (row.Cells["Diagnosis1"].Value.ToString() != "")
                    {
                        lbl_Archdiagnosis.Text = row.Cells["Diagnosis1"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archdiagnosis.Text = ".....";
                    }
                    if (row.Cells["Reason1"].Value.ToString() != "")
                    {
                        lbl_Archreason.Text = row.Cells["Reason1"].Value.ToString();
                    }
                    else
                    {
                        lbl_Archreason.Text = ".....";
                    }


                    if (row.Cells["Availability"].Value != null )
                    {
                        if (row.Cells["Availability"].Value.ToString() != "" && row.Cells["Availability"].Value.ToString() != "0")
                        {
                            lbl_ArchAvailability.Text = row.Cells["Availability"].Value.ToString();
                        }
                        else
                        {
                            lbl_ArchAvailability.Text = ".....";
                        }
                    }

                    if (row.Cells["Professional_Competence"].Value != null)
                    {
                        if (row.Cells["Professional_Competence"].Value.ToString() != "" && row.Cells["Professional_Competence"].Value.ToString() != "0")
                        {
                            lbl_ArchProfCompetence.Text = row.Cells["Professional_Competence"].Value.ToString();
                        }
                        else
                        {
                            lbl_ArchProfCompetence.Text = ".....";
                        }
                    }

                    if (row.Cells["Reaction_Time"].Value != null)
                    {
                        if (row.Cells["Reaction_Time"].Value.ToString() != "" && row.Cells["Reaction_Time"].Value.ToString() != "0")
                        {
                            lbl_ArchReaction.Text = row.Cells["Reaction_Time"].Value.ToString();
                        }
                        else
                        {
                            lbl_ArchReaction.Text = ".....";
                        }
                    }

                    if (row.Cells["Kindness"].Value != null)
                    {
                        if (row.Cells["Kindness"].Value.ToString() != "" && row.Cells["Kindness"].Value.ToString() != "0")
                        {
                            lbl_ArchKindness.Text = row.Cells["Kindness"].Value.ToString();
                        }
                        else
                        {
                            lbl_ArchKindness.Text = ".....";
                        }
                    }



                }
            }
        }

        private void btn_main_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            main main = new main();
            main.Show();
        }

        private void ArchiveCustomerDataDisplay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ArchiveCustomerDataDisplay.RowCount > 0)
                {
                    DataGridViewRow row = ArchiveCustomerDataDisplay.CurrentRow;
                    if (!row.IsNewRow)
                    {
                        int req_id = Convert.ToInt32(row.Cells["Case"].Value);
                        this.Hide();
                        Form_ServiceInfo form = new Form_ServiceInfo(req_id, "Archive");
                        //form.Enabled = false;                        
                        form.Show();                       
                    }
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }
        }

        private void btn_unarchive_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = ArchiveCustomerDataDisplay.CurrentRow;
            if (!row.IsNewRow)
            {
                DialogResult m = MessageBox.Show("Do You want to continue?", "Reactivate Case", MessageBoxButtons.YesNo);
                if (m == DialogResult.Yes)
                {
                    //lblCase.Text = row.Cells["ID"].Value.ToString();
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
                            MessageBox.Show("Case Reactivated!");
                        }
                    }


                }
            }
            else
            {
                MessageBox.Show("Select Service Case to Archive");
            }
        }

        private void ArchiveCustomerDataDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {


                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Copy"));
                int currentMouseOverRow = ArchiveCustomerDataDisplay.HitTest(e.X, e.Y).RowIndex;
                m.Show(ArchiveCustomerDataDisplay, new Point(e.X, e.Y));
                DialogResult d = MessageBox.Show("Do you want to copy the cases in Excel?", "Copy Selected Cases", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    if (ArchiveCustomerDataDisplay.GetCellCount(DataGridViewElementStates.Selected) > 0)
                    {
                        try
                        {
                            // Add the selection to the clipboard.
                            Clipboard.SetDataObject(ArchiveCustomerDataDisplay.GetClipboardContent());
                            // Replace the text box contents with the clipboard text. 

                            CopyToExcel();
                        }
                        catch (System.Runtime.InteropServices.ExternalException)
                        {

                            MessageBox.Show("The Clipboard could not be accessed. Please try again.");
                        }
                    }
                }

            }
        }

        private void CopyToExcel()
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

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lbl_Archcomplian_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btn_ExportFiles_Click(object sender, EventArgs e)
        {
            CopyToExcel();

        }
    }
}
