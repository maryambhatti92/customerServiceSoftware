namespace customerServiceSoftware
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.mainCustomerDataDisplay = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Header_main = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuTileButton3 = new Bunifu.Framework.UI.BunifuTileButton();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.bunifuTileButton2 = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuTileButton1 = new Bunifu.Framework.UI.BunifuTileButton();
            this.pictureBox6 = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblModifiedOn = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblCreatedOn = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblServiceReason = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblCase = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblStatus = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblPriority = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Btn_Home = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btn_Add_Company = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_CreateUser = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_main_del = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_main_archive = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_main_Diagnosis = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_main_add = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_main_home = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.mainDataVMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Case = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Request_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainCustomerDataDisplay)).BeginInit();
            this.Header_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Btn_Home.SuspendLayout();
            this.bunifuGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataVMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainCustomerDataDisplay
            // 
            this.mainCustomerDataDisplay.AllowUserToAddRows = false;
            this.mainCustomerDataDisplay.AllowUserToDeleteRows = false;
            this.mainCustomerDataDisplay.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mainCustomerDataDisplay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mainCustomerDataDisplay.AutoGenerateColumns = false;
            this.mainCustomerDataDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mainCustomerDataDisplay.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.mainCustomerDataDisplay.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.mainCustomerDataDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainCustomerDataDisplay.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainCustomerDataDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mainCustomerDataDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainCustomerDataDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Case,
            this.Priority,
            this.Status,
            this.Company,
            this.ServiceReason,
            this.Date,
            this.LastModified,
            this.ID,
            this.Request_id,
            this.File,
            this.Manager});
            this.mainCustomerDataDisplay.DataSource = this.mainDataVMBindingSource;
            this.mainCustomerDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainCustomerDataDisplay.DoubleBuffered = true;
            this.mainCustomerDataDisplay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.mainCustomerDataDisplay.EnableHeadersVisualStyles = false;
            this.mainCustomerDataDisplay.GridColor = System.Drawing.Color.Silver;
            this.mainCustomerDataDisplay.HeaderBgColor = System.Drawing.Color.Gainsboro;
            this.mainCustomerDataDisplay.HeaderForeColor = System.Drawing.Color.Black;
            this.mainCustomerDataDisplay.Location = new System.Drawing.Point(198, 77);
            this.mainCustomerDataDisplay.Name = "mainCustomerDataDisplay";
            this.mainCustomerDataDisplay.ReadOnly = true;
            this.mainCustomerDataDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.mainCustomerDataDisplay.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.mainCustomerDataDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainCustomerDataDisplay.Size = new System.Drawing.Size(715, 333);
            this.mainCustomerDataDisplay.TabIndex = 5;
            this.mainCustomerDataDisplay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainCustomerDataDisplay_CellClick);
            this.mainCustomerDataDisplay.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainCustomerDataDisplay_CellDoubleClick);
            this.mainCustomerDataDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainCustomerDataDisplay_MouseClick);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.Header_main;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Header_main
            // 
            this.Header_main.BackColor = System.Drawing.Color.DarkOrange;
            this.Header_main.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Header_main.BackgroundImage")));
            this.Header_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Header_main.Controls.Add(this.bunifuTileButton3);
            this.Header_main.Controls.Add(this.pictureBox5);
            this.Header_main.Controls.Add(this.bunifuTileButton2);
            this.Header_main.Controls.Add(this.bunifuTileButton1);
            this.Header_main.Controls.Add(this.pictureBox6);
            this.Header_main.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header_main.GradientBottomLeft = System.Drawing.Color.DarkSlateGray;
            this.Header_main.GradientBottomRight = System.Drawing.Color.WhiteSmoke;
            this.Header_main.GradientTopLeft = System.Drawing.Color.Orange;
            this.Header_main.GradientTopRight = System.Drawing.Color.White;
            this.Header_main.Location = new System.Drawing.Point(0, 0);
            this.Header_main.Name = "Header_main";
            this.Header_main.Quality = 10;
            this.Header_main.Size = new System.Drawing.Size(913, 35);
            this.Header_main.TabIndex = 19;
            // 
            // bunifuTileButton3
            // 
            this.bunifuTileButton3.AccessibleName = "";
            this.bunifuTileButton3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bunifuTileButton3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton3.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton3.colorActive = System.Drawing.Color.OrangeRed;
            this.bunifuTileButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton3.Font = new System.Drawing.Font("Century Gothic", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton3.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton3.Image = global::customerServiceSoftware.Properties.Resources.Minimize_icon;
            this.bunifuTileButton3.ImagePosition = 2;
            this.bunifuTileButton3.ImageZoom = 50;
            this.bunifuTileButton3.LabelPosition = 3;
            this.bunifuTileButton3.LabelText = " ";
            this.bunifuTileButton3.Location = new System.Drawing.Point(824, 4);
            this.bunifuTileButton3.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton3.Name = "bunifuTileButton3";
            this.bunifuTileButton3.Size = new System.Drawing.Size(39, 28);
            this.bunifuTileButton3.TabIndex = 33;
            this.bunifuTileButton3.Click += new System.EventHandler(this.bunifuTileButton3_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::customerServiceSoftware.Properties.Resources.Asset_3_4x;
            this.pictureBox5.Location = new System.Drawing.Point(15, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(177, 37);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 32;
            this.pictureBox5.TabStop = false;
            // 
            // bunifuTileButton2
            // 
            this.bunifuTileButton2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bunifuTileButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton2.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton2.colorActive = System.Drawing.Color.OrangeRed;
            this.bunifuTileButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton2.Font = new System.Drawing.Font("Century Gothic", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton2.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton2.Image = global::customerServiceSoftware.Properties.Resources.Icon_maximize;
            this.bunifuTileButton2.ImagePosition = 2;
            this.bunifuTileButton2.ImageZoom = 50;
            this.bunifuTileButton2.LabelPosition = 3;
            this.bunifuTileButton2.LabelText = " ";
            this.bunifuTileButton2.Location = new System.Drawing.Point(824, 5);
            this.bunifuTileButton2.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton2.Name = "bunifuTileButton2";
            this.bunifuTileButton2.Size = new System.Drawing.Size(39, 26);
            this.bunifuTileButton2.TabIndex = 16;
            this.bunifuTileButton2.Visible = false;
            this.bunifuTileButton2.Click += new System.EventHandler(this.bunifuTileButton2_Click);
            // 
            // bunifuTileButton1
            // 
            this.bunifuTileButton1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bunifuTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bunifuTileButton1.color = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.colorActive = System.Drawing.Color.OrangeRed;
            this.bunifuTileButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTileButton1.Font = new System.Drawing.Font("Century Gothic", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton1.ForeColor = System.Drawing.Color.White;
            this.bunifuTileButton1.Image = global::customerServiceSoftware.Properties.Resources.Mini;
            this.bunifuTileButton1.ImagePosition = 2;
            this.bunifuTileButton1.ImageZoom = 50;
            this.bunifuTileButton1.LabelPosition = 3;
            this.bunifuTileButton1.LabelText = " ";
            this.bunifuTileButton1.Location = new System.Drawing.Point(789, 4);
            this.bunifuTileButton1.Margin = new System.Windows.Forms.Padding(6);
            this.bunifuTileButton1.Name = "bunifuTileButton1";
            this.bunifuTileButton1.Size = new System.Drawing.Size(40, 29);
            this.bunifuTileButton1.TabIndex = 15;
            this.bunifuTileButton1.Click += new System.EventHandler(this.bunifuTileButton1_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.color = System.Drawing.Color.Transparent;
            this.pictureBox6.colorActive = System.Drawing.Color.OrangeRed;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Font = new System.Drawing.Font("Century Gothic", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBox6.ForeColor = System.Drawing.Color.White;
            this.pictureBox6.Image = global::customerServiceSoftware.Properties.Resources.Close_icon;
            this.pictureBox6.ImagePosition = 2;
            this.pictureBox6.ImageZoom = 50;
            this.pictureBox6.LabelPosition = 3;
            this.pictureBox6.LabelText = " ";
            this.pictureBox6.Location = new System.Drawing.Point(859, 4);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(39, 26);
            this.pictureBox6.TabIndex = 14;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Silver;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.tableLayoutPanel1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Gainsboro;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DimGray;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Gainsboro;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Silver;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(198, 410);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(715, 113);
            this.bunifuGradientPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.38267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.61732F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 325F));
            this.tableLayoutPanel1.Controls.Add(this.lblModifiedOn, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCreatedOn, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblServiceReason, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.bunifuCustomLabel6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.bunifuCustomLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bunifuCustomLabel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.bunifuCustomLabel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCase, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bunifuCustomLabel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.bunifuCustomLabel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPriority, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(715, 113);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblModifiedOn
            // 
            this.lblModifiedOn.AutoSize = true;
            this.lblModifiedOn.BackColor = System.Drawing.Color.Silver;
            this.lblModifiedOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedOn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifiedOn.ForeColor = System.Drawing.Color.Maroon;
            this.lblModifiedOn.Location = new System.Drawing.Point(391, 80);
            this.lblModifiedOn.Name = "lblModifiedOn";
            this.lblModifiedOn.Size = new System.Drawing.Size(321, 33);
            this.lblModifiedOn.TabIndex = 10;
            this.lblModifiedOn.Text = ". . . .";
            // 
            // lblCreatedOn
            // 
            this.lblCreatedOn.AutoSize = true;
            this.lblCreatedOn.BackColor = System.Drawing.Color.Silver;
            this.lblCreatedOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedOn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedOn.ForeColor = System.Drawing.Color.Maroon;
            this.lblCreatedOn.Location = new System.Drawing.Point(391, 40);
            this.lblCreatedOn.Name = "lblCreatedOn";
            this.lblCreatedOn.Size = new System.Drawing.Size(321, 40);
            this.lblCreatedOn.TabIndex = 11;
            this.lblCreatedOn.Text = ". . . .";
            // 
            // lblServiceReason
            // 
            this.lblServiceReason.AutoSize = true;
            this.lblServiceReason.BackColor = System.Drawing.Color.Silver;
            this.lblServiceReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServiceReason.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceReason.ForeColor = System.Drawing.Color.Maroon;
            this.lblServiceReason.Location = new System.Drawing.Point(391, 0);
            this.lblServiceReason.Name = "lblServiceReason";
            this.lblServiceReason.Size = new System.Drawing.Size(321, 40);
            this.lblServiceReason.TabIndex = 12;
            this.lblServiceReason.Text = ". . . .";
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(278, 80);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(107, 33);
            this.bunifuCustomLabel6.TabIndex = 13;
            this.bunifuCustomLabel6.Text = "Last Modified:";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(3, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(55, 40);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Case:";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(3, 80);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(55, 33);
            this.bunifuCustomLabel4.TabIndex = 3;
            this.bunifuCustomLabel4.Text = "Status:";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(3, 40);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(55, 40);
            this.bunifuCustomLabel5.TabIndex = 4;
            this.bunifuCustomLabel5.Text = "Priority:";
            // 
            // lblCase
            // 
            this.lblCase.AutoSize = true;
            this.lblCase.BackColor = System.Drawing.Color.Silver;
            this.lblCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCase.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCase.ForeColor = System.Drawing.Color.Maroon;
            this.lblCase.Location = new System.Drawing.Point(64, 0);
            this.lblCase.Name = "lblCase";
            this.lblCase.Size = new System.Drawing.Size(208, 40);
            this.lblCase.TabIndex = 6;
            this.lblCase.Text = ". . . .";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(278, 40);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(107, 40);
            this.bunifuCustomLabel2.TabIndex = 1;
            this.bunifuCustomLabel2.Text = "Created On:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Silver;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Maroon;
            this.lblStatus.Location = new System.Drawing.Point(64, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(208, 33);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = ". . . .";
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(278, 0);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(107, 40);
            this.bunifuCustomLabel3.TabIndex = 2;
            this.bunifuCustomLabel3.Text = "Service Reason:";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.BackColor = System.Drawing.Color.Silver;
            this.lblPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPriority.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.ForeColor = System.Drawing.Color.Maroon;
            this.lblPriority.Location = new System.Drawing.Point(64, 40);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(208, 40);
            this.lblPriority.TabIndex = 9;
            this.lblPriority.Text = ". . . .";
            // 
            // Btn_Home
            // 
            this.Btn_Home.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Home.BackgroundImage")));
            this.Btn_Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Home.Controls.Add(this.btn_Add_Company);
            this.Btn_Home.Controls.Add(this.btn_CreateUser);
            this.Btn_Home.Controls.Add(this.bunifuFlatButton1);
            this.Btn_Home.Controls.Add(this.btn_main_del);
            this.Btn_Home.Controls.Add(this.btn_main_archive);
            this.Btn_Home.Controls.Add(this.btn_main_Diagnosis);
            this.Btn_Home.Controls.Add(this.btn_main_add);
            this.Btn_Home.Controls.Add(this.btn_main_home);
            this.Btn_Home.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_Home.GradientBottomLeft = System.Drawing.Color.SlateGray;
            this.Btn_Home.GradientBottomRight = System.Drawing.Color.Black;
            this.Btn_Home.GradientTopLeft = System.Drawing.Color.Gainsboro;
            this.Btn_Home.GradientTopRight = System.Drawing.Color.DarkSlateGray;
            this.Btn_Home.Location = new System.Drawing.Point(0, 77);
            this.Btn_Home.Name = "Btn_Home";
            this.Btn_Home.Quality = 10;
            this.Btn_Home.Size = new System.Drawing.Size(198, 446);
            this.Btn_Home.TabIndex = 6;
            // 
            // btn_Add_Company
            // 
            this.btn_Add_Company.Activecolor = System.Drawing.Color.Transparent;
            this.btn_Add_Company.BackColor = System.Drawing.Color.Transparent;
            this.btn_Add_Company.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Add_Company.BorderRadius = 0;
            this.btn_Add_Company.ButtonText = "          Add Company";
            this.btn_Add_Company.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add_Company.DisabledColor = System.Drawing.Color.Gray;
            this.btn_Add_Company.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_Add_Company.Iconimage = global::customerServiceSoftware.Properties.Resources.Icon_Add_New;
            this.btn_Add_Company.Iconimage_right = null;
            this.btn_Add_Company.Iconimage_right_Selected = null;
            this.btn_Add_Company.Iconimage_Selected = null;
            this.btn_Add_Company.IconMarginLeft = 0;
            this.btn_Add_Company.IconMarginRight = 0;
            this.btn_Add_Company.IconRightVisible = true;
            this.btn_Add_Company.IconRightZoom = 0D;
            this.btn_Add_Company.IconVisible = true;
            this.btn_Add_Company.IconZoom = 90D;
            this.btn_Add_Company.IsTab = false;
            this.btn_Add_Company.Location = new System.Drawing.Point(0, 373);
            this.btn_Add_Company.Name = "btn_Add_Company";
            this.btn_Add_Company.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_Add_Company.OnHovercolor = System.Drawing.Color.DarkOrange;
            this.btn_Add_Company.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_Add_Company.selected = false;
            this.btn_Add_Company.Size = new System.Drawing.Size(196, 48);
            this.btn_Add_Company.TabIndex = 23;
            this.btn_Add_Company.Text = "          Add Company";
            this.btn_Add_Company.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add_Company.Textcolor = System.Drawing.Color.White;
            this.btn_Add_Company.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_Company.Click += new System.EventHandler(this.btn_Add_Company_Click);
            // 
            // btn_CreateUser
            // 
            this.btn_CreateUser.Activecolor = System.Drawing.Color.Transparent;
            this.btn_CreateUser.BackColor = System.Drawing.Color.Transparent;
            this.btn_CreateUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CreateUser.BorderRadius = 0;
            this.btn_CreateUser.ButtonText = "          Create User";
            this.btn_CreateUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CreateUser.DisabledColor = System.Drawing.Color.Gray;
            this.btn_CreateUser.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_CreateUser.Iconimage = global::customerServiceSoftware.Properties.Resources.Icon_Add_New;
            this.btn_CreateUser.Iconimage_right = null;
            this.btn_CreateUser.Iconimage_right_Selected = null;
            this.btn_CreateUser.Iconimage_Selected = null;
            this.btn_CreateUser.IconMarginLeft = 0;
            this.btn_CreateUser.IconMarginRight = 0;
            this.btn_CreateUser.IconRightVisible = true;
            this.btn_CreateUser.IconRightZoom = 0D;
            this.btn_CreateUser.IconVisible = true;
            this.btn_CreateUser.IconZoom = 90D;
            this.btn_CreateUser.IsTab = false;
            this.btn_CreateUser.Location = new System.Drawing.Point(2, 325);
            this.btn_CreateUser.Name = "btn_CreateUser";
            this.btn_CreateUser.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_CreateUser.OnHovercolor = System.Drawing.Color.DarkOrange;
            this.btn_CreateUser.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_CreateUser.selected = false;
            this.btn_CreateUser.Size = new System.Drawing.Size(196, 48);
            this.btn_CreateUser.TabIndex = 22;
            this.btn_CreateUser.Text = "          Create User";
            this.btn_CreateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CreateUser.Textcolor = System.Drawing.Color.White;
            this.btn_CreateUser.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateUser.Click += new System.EventHandler(this.btn_CreateUser_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "          Copy Cases";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = global::customerServiceSoftware.Properties.Resources.copy_icon;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(1, 280);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.DarkOrange;
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(197, 48);
            this.bunifuFlatButton1.TabIndex = 21;
            this.bunifuFlatButton1.Text = "          Copy Cases";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // btn_main_del
            // 
            this.btn_main_del.Activecolor = System.Drawing.Color.Transparent;
            this.btn_main_del.BackColor = System.Drawing.Color.Transparent;
            this.btn_main_del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_main_del.BorderRadius = 0;
            this.btn_main_del.ButtonText = "          Delete Case";
            this.btn_main_del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_main_del.DisabledColor = System.Drawing.Color.Gray;
            this.btn_main_del.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_main_del.Iconimage = global::customerServiceSoftware.Properties.Resources.Delete_icon_New;
            this.btn_main_del.Iconimage_right = null;
            this.btn_main_del.Iconimage_right_Selected = null;
            this.btn_main_del.Iconimage_Selected = null;
            this.btn_main_del.IconMarginLeft = 0;
            this.btn_main_del.IconMarginRight = 0;
            this.btn_main_del.IconRightVisible = true;
            this.btn_main_del.IconRightZoom = 0D;
            this.btn_main_del.IconVisible = true;
            this.btn_main_del.IconZoom = 90D;
            this.btn_main_del.IsTab = false;
            this.btn_main_del.Location = new System.Drawing.Point(0, 114);
            this.btn_main_del.Name = "btn_main_del";
            this.btn_main_del.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_main_del.OnHovercolor = System.Drawing.Color.DarkOrange;
            this.btn_main_del.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_main_del.selected = false;
            this.btn_main_del.Size = new System.Drawing.Size(198, 48);
            this.btn_main_del.TabIndex = 20;
            this.btn_main_del.Text = "          Delete Case";
            this.btn_main_del.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_main_del.Textcolor = System.Drawing.Color.White;
            this.btn_main_del.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_main_del.Click += new System.EventHandler(this.btn_main_del_Click);
            // 
            // btn_main_archive
            // 
            this.btn_main_archive.Activecolor = System.Drawing.Color.Transparent;
            this.btn_main_archive.BackColor = System.Drawing.Color.Transparent;
            this.btn_main_archive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_main_archive.BorderRadius = 0;
            this.btn_main_archive.ButtonText = "          Archive";
            this.btn_main_archive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_main_archive.DisabledColor = System.Drawing.Color.Gray;
            this.btn_main_archive.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_main_archive.Iconimage = global::customerServiceSoftware.Properties.Resources.archive_icon_new;
            this.btn_main_archive.Iconimage_right = null;
            this.btn_main_archive.Iconimage_right_Selected = null;
            this.btn_main_archive.Iconimage_Selected = null;
            this.btn_main_archive.IconMarginLeft = 0;
            this.btn_main_archive.IconMarginRight = 0;
            this.btn_main_archive.IconRightVisible = true;
            this.btn_main_archive.IconRightZoom = 0D;
            this.btn_main_archive.IconVisible = true;
            this.btn_main_archive.IconZoom = 90D;
            this.btn_main_archive.IsTab = false;
            this.btn_main_archive.Location = new System.Drawing.Point(3, 168);
            this.btn_main_archive.Name = "btn_main_archive";
            this.btn_main_archive.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_main_archive.OnHovercolor = System.Drawing.Color.DarkOrange;
            this.btn_main_archive.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_main_archive.selected = false;
            this.btn_main_archive.Size = new System.Drawing.Size(195, 48);
            this.btn_main_archive.TabIndex = 19;
            this.btn_main_archive.Text = "          Archive";
            this.btn_main_archive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_main_archive.Textcolor = System.Drawing.Color.White;
            this.btn_main_archive.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_main_archive.Click += new System.EventHandler(this.btn_main_archive_Click);
            // 
            // btn_main_Diagnosis
            // 
            this.btn_main_Diagnosis.Activecolor = System.Drawing.Color.Transparent;
            this.btn_main_Diagnosis.BackColor = System.Drawing.Color.Transparent;
            this.btn_main_Diagnosis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_main_Diagnosis.BorderRadius = 0;
            this.btn_main_Diagnosis.ButtonText = "          Diagnosis";
            this.btn_main_Diagnosis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_main_Diagnosis.DisabledColor = System.Drawing.Color.Gray;
            this.btn_main_Diagnosis.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_main_Diagnosis.Iconimage = global::customerServiceSoftware.Properties.Resources.Diagnosis_123;
            this.btn_main_Diagnosis.Iconimage_right = null;
            this.btn_main_Diagnosis.Iconimage_right_Selected = null;
            this.btn_main_Diagnosis.Iconimage_Selected = null;
            this.btn_main_Diagnosis.IconMarginLeft = 0;
            this.btn_main_Diagnosis.IconMarginRight = 0;
            this.btn_main_Diagnosis.IconRightVisible = true;
            this.btn_main_Diagnosis.IconRightZoom = 0D;
            this.btn_main_Diagnosis.IconVisible = true;
            this.btn_main_Diagnosis.IconZoom = 90D;
            this.btn_main_Diagnosis.IsTab = false;
            this.btn_main_Diagnosis.Location = new System.Drawing.Point(1, 222);
            this.btn_main_Diagnosis.Name = "btn_main_Diagnosis";
            this.btn_main_Diagnosis.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_main_Diagnosis.OnHovercolor = System.Drawing.Color.DarkOrange;
            this.btn_main_Diagnosis.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_main_Diagnosis.selected = false;
            this.btn_main_Diagnosis.Size = new System.Drawing.Size(197, 48);
            this.btn_main_Diagnosis.TabIndex = 18;
            this.btn_main_Diagnosis.Text = "          Diagnosis";
            this.btn_main_Diagnosis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_main_Diagnosis.Textcolor = System.Drawing.Color.White;
            this.btn_main_Diagnosis.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_main_Diagnosis.Click += new System.EventHandler(this.btn_main_Diagnosis_Click);
            // 
            // btn_main_add
            // 
            this.btn_main_add.Activecolor = System.Drawing.Color.Transparent;
            this.btn_main_add.BackColor = System.Drawing.Color.Transparent;
            this.btn_main_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_main_add.BorderRadius = 0;
            this.btn_main_add.ButtonText = "          Add Service Case";
            this.btn_main_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_main_add.DisabledColor = System.Drawing.Color.Gray;
            this.btn_main_add.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_main_add.Iconimage = global::customerServiceSoftware.Properties.Resources.Icon_Add_New;
            this.btn_main_add.Iconimage_right = null;
            this.btn_main_add.Iconimage_right_Selected = null;
            this.btn_main_add.Iconimage_Selected = null;
            this.btn_main_add.IconMarginLeft = 0;
            this.btn_main_add.IconMarginRight = 0;
            this.btn_main_add.IconRightVisible = true;
            this.btn_main_add.IconRightZoom = 0D;
            this.btn_main_add.IconVisible = true;
            this.btn_main_add.IconZoom = 90D;
            this.btn_main_add.IsTab = false;
            this.btn_main_add.Location = new System.Drawing.Point(2, 60);
            this.btn_main_add.Name = "btn_main_add";
            this.btn_main_add.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_main_add.OnHovercolor = System.Drawing.Color.DarkOrange;
            this.btn_main_add.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_main_add.selected = false;
            this.btn_main_add.Size = new System.Drawing.Size(196, 48);
            this.btn_main_add.TabIndex = 17;
            this.btn_main_add.Text = "          Add Service Case";
            this.btn_main_add.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_main_add.Textcolor = System.Drawing.Color.White;
            this.btn_main_add.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_main_add.Click += new System.EventHandler(this.btn_main_add_Click);
            // 
            // btn_main_home
            // 
            this.btn_main_home.Activecolor = System.Drawing.Color.DarkOrange;
            this.btn_main_home.BackColor = System.Drawing.Color.Transparent;
            this.btn_main_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_main_home.BorderRadius = 0;
            this.btn_main_home.ButtonText = "         Home";
            this.btn_main_home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_main_home.DisabledColor = System.Drawing.Color.Gray;
            this.btn_main_home.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_main_home.Iconimage = global::customerServiceSoftware.Properties.Resources.Home_icon_4;
            this.btn_main_home.Iconimage_right = null;
            this.btn_main_home.Iconimage_right_Selected = null;
            this.btn_main_home.Iconimage_Selected = null;
            this.btn_main_home.IconMarginLeft = 0;
            this.btn_main_home.IconMarginRight = 0;
            this.btn_main_home.IconRightVisible = true;
            this.btn_main_home.IconRightZoom = 0D;
            this.btn_main_home.IconVisible = true;
            this.btn_main_home.IconZoom = 90D;
            this.btn_main_home.IsTab = false;
            this.btn_main_home.Location = new System.Drawing.Point(2, 6);
            this.btn_main_home.Name = "btn_main_home";
            this.btn_main_home.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_main_home.OnHovercolor = System.Drawing.Color.DarkOrange;
            this.btn_main_home.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_main_home.selected = false;
            this.btn_main_home.Size = new System.Drawing.Size(196, 48);
            this.btn_main_home.TabIndex = 16;
            this.btn_main_home.Text = "         Home";
            this.btn_main_home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_main_home.Textcolor = System.Drawing.Color.White;
            this.btn_main_home.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_main_home.Click += new System.EventHandler(this.btn_main_home_Click);
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackColor = System.Drawing.Color.Silver;
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.Controls.Add(this.label1);
            this.bunifuGradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.Black;
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.Gray;
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.Black;
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(0, 35);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(913, 42);
            this.bunifuGradientPanel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(415, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "CUSTOMER INFORMATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainDataVMBindingSource
            // 
            this.mainDataVMBindingSource.DataSource = typeof(css.Shared.ViewModels.MainDataVM);
            // 
            // Case
            // 
            this.Case.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Case.DataPropertyName = "Case";
            this.Case.HeaderText = "Case";
            this.Case.Name = "Case";
            this.Case.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Priority.DataPropertyName = "Prioritisation";
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Company
            // 
            this.Company.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Company.DataPropertyName = "Company";
            this.Company.HeaderText = "Company";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            // 
            // ServiceReason
            // 
            this.ServiceReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServiceReason.DataPropertyName = "ServiceReason";
            this.ServiceReason.HeaderText = "Service Reason";
            this.ServiceReason.Name = "ServiceReason";
            this.ServiceReason.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Visible = false;
            // 
            // LastModified
            // 
            this.LastModified.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastModified.DataPropertyName = "LastModified";
            this.LastModified.HeaderText = "LastModified";
            this.LastModified.Name = "LastModified";
            this.LastModified.ReadOnly = true;
            this.LastModified.Visible = false;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Request_id
            // 
            this.Request_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Request_id.DataPropertyName = "Request_id";
            this.Request_id.HeaderText = "Request_id";
            this.Request_id.Name = "Request_id";
            this.Request_id.ReadOnly = true;
            this.Request_id.Visible = false;
            // 
            // File
            // 
            this.File.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.File.DataPropertyName = "File";
            this.File.HeaderText = "File";
            this.File.Name = "File";
            this.File.ReadOnly = true;
            this.File.Visible = false;
            // 
            // Manager
            // 
            this.Manager.DataPropertyName = "Manager";
            this.Manager.HeaderText = "Manager";
            this.Manager.Name = "Manager";
            this.Manager.ReadOnly = true;
            this.Manager.Width = 85;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(913, 523);
            this.Controls.Add(this.mainCustomerDataDisplay);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.Btn_Home);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.Header_main);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Service Software";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainCustomerDataDisplay)).EndInit();
            this.Header_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Btn_Home.ResumeLayout(false);
            this.bunifuGradientPanel2.ResumeLayout(false);
            this.bunifuGradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataVMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid mainCustomerDataDisplay;
        private Bunifu.Framework.UI.BunifuGradientPanel Btn_Home;
        private Bunifu.Framework.UI.BunifuFlatButton btn_main_home;
        private Bunifu.Framework.UI.BunifuFlatButton btn_main_add;
        private Bunifu.Framework.UI.BunifuFlatButton btn_main_Diagnosis;
        private Bunifu.Framework.UI.BunifuFlatButton btn_main_del;
        private Bunifu.Framework.UI.BunifuFlatButton btn_main_archive;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private Bunifu.Framework.UI.BunifuCustomLabel lblServiceReason;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCreatedOn;
        private Bunifu.Framework.UI.BunifuCustomLabel lblModifiedOn;
        private Bunifu.Framework.UI.BunifuCustomLabel lblPriority;
        private Bunifu.Framework.UI.BunifuCustomLabel lblStatus;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCase;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
        private System.Windows.Forms.BindingSource mainDataVMBindingSource;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel Header_main;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton2;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton1;
        private Bunifu.Framework.UI.BunifuTileButton pictureBox6;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuFlatButton btn_CreateUser;
        private Bunifu.Framework.UI.BunifuFlatButton btn_Add_Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Case;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Request_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn File;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manager;
    }
}