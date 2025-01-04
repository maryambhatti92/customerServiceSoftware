namespace customerServiceSoftware
{
    partial class AddCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCompany));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Header_Email = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.bunifuTileButton1 = new Bunifu.Framework.UI.BunifuTileButton();
            this.pictureBox6 = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCmpAddress = new System.Windows.Forms.RichTextBox();
            this.txtCmpEmail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtPhoneNo = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label41 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCmpName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtCmpLiscence = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnAddCmp = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_cmp_liscence = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Header_Email.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.bunifuGradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.Header_Email;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Header_Email
            // 
            this.Header_Email.BackColor = System.Drawing.Color.DarkOrange;
            this.Header_Email.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Header_Email.BackgroundImage")));
            this.Header_Email.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Header_Email.Controls.Add(this.pictureBox5);
            this.Header_Email.Controls.Add(this.bunifuTileButton1);
            this.Header_Email.Controls.Add(this.pictureBox6);
            this.Header_Email.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header_Email.GradientBottomLeft = System.Drawing.Color.DarkSlateGray;
            this.Header_Email.GradientBottomRight = System.Drawing.Color.WhiteSmoke;
            this.Header_Email.GradientTopLeft = System.Drawing.Color.Orange;
            this.Header_Email.GradientTopRight = System.Drawing.Color.White;
            this.Header_Email.Location = new System.Drawing.Point(0, 0);
            this.Header_Email.Name = "Header_Email";
            this.Header_Email.Quality = 10;
            this.Header_Email.Size = new System.Drawing.Size(658, 35);
            this.Header_Email.TabIndex = 76;
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
            this.bunifuTileButton1.Location = new System.Drawing.Point(566, 4);
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
            this.pictureBox6.Location = new System.Drawing.Point(604, 4);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(39, 26);
            this.pictureBox6.TabIndex = 14;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
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
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(658, 42);
            this.bunifuGradientPanel2.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(279, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "ADD COMPANY";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCmpAddress
            // 
            this.txtCmpAddress.Location = new System.Drawing.Point(190, 246);
            this.txtCmpAddress.Name = "txtCmpAddress";
            this.txtCmpAddress.Size = new System.Drawing.Size(378, 59);
            this.txtCmpAddress.TabIndex = 104;
            this.txtCmpAddress.Text = "";
            // 
            // txtCmpEmail
            // 
            this.txtCmpEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCmpEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCmpEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCmpEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCmpEmail.HintForeColor = System.Drawing.Color.Empty;
            this.txtCmpEmail.HintText = "";
            this.txtCmpEmail.isPassword = false;
            this.txtCmpEmail.LineFocusedColor = System.Drawing.Color.Orange;
            this.txtCmpEmail.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCmpEmail.LineMouseHoverColor = System.Drawing.Color.DarkOrange;
            this.txtCmpEmail.LineThickness = 3;
            this.txtCmpEmail.Location = new System.Drawing.Point(190, 178);
            this.txtCmpEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtCmpEmail.Name = "txtCmpEmail";
            this.txtCmpEmail.Size = new System.Drawing.Size(379, 34);
            this.txtCmpEmail.TabIndex = 101;
            this.txtCmpEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPhoneNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhoneNo.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPhoneNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPhoneNo.HintForeColor = System.Drawing.Color.Empty;
            this.txtPhoneNo.HintText = "";
            this.txtPhoneNo.isPassword = false;
            this.txtPhoneNo.LineFocusedColor = System.Drawing.Color.Orange;
            this.txtPhoneNo.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPhoneNo.LineMouseHoverColor = System.Drawing.Color.DarkOrange;
            this.txtPhoneNo.LineThickness = 3;
            this.txtPhoneNo.Location = new System.Drawing.Point(190, 138);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(378, 32);
            this.txtPhoneNo.TabIndex = 100;
            this.txtPhoneNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(66, 112);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(107, 17);
            this.label41.TabIndex = 92;
            this.label41.Tag = "";
            this.label41.Text = "Company Name:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 93;
            this.label2.Text = "Phone #:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 94;
            this.label3.Text = "Email:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(113, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 96;
            this.label5.Text = "Address:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(109, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 98;
            this.label7.Text = "Liscence:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtCmpName
            // 
            this.txtCmpName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCmpName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCmpName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCmpName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCmpName.HintForeColor = System.Drawing.Color.Empty;
            this.txtCmpName.HintText = "";
            this.txtCmpName.isPassword = false;
            this.txtCmpName.LineFocusedColor = System.Drawing.Color.Orange;
            this.txtCmpName.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCmpName.LineMouseHoverColor = System.Drawing.Color.DarkOrange;
            this.txtCmpName.LineThickness = 3;
            this.txtCmpName.Location = new System.Drawing.Point(190, 96);
            this.txtCmpName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCmpName.Name = "txtCmpName";
            this.txtCmpName.Size = new System.Drawing.Size(378, 33);
            this.txtCmpName.TabIndex = 99;
            this.txtCmpName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtCmpLiscence
            // 
            this.txtCmpLiscence.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCmpLiscence.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCmpLiscence.Enabled = false;
            this.txtCmpLiscence.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCmpLiscence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCmpLiscence.HintForeColor = System.Drawing.Color.Empty;
            this.txtCmpLiscence.HintText = "";
            this.txtCmpLiscence.isPassword = false;
            this.txtCmpLiscence.LineFocusedColor = System.Drawing.Color.Orange;
            this.txtCmpLiscence.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCmpLiscence.LineMouseHoverColor = System.Drawing.Color.DarkOrange;
            this.txtCmpLiscence.LineThickness = 3;
            this.txtCmpLiscence.Location = new System.Drawing.Point(190, 318);
            this.txtCmpLiscence.Margin = new System.Windows.Forms.Padding(4);
            this.txtCmpLiscence.Name = "txtCmpLiscence";
            this.txtCmpLiscence.Size = new System.Drawing.Size(339, 28);
            this.txtCmpLiscence.TabIndex = 103;
            this.txtCmpLiscence.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnAddCmp
            // 
            this.btnAddCmp.ActiveBorderThickness = 1;
            this.btnAddCmp.ActiveCornerRadius = 20;
            this.btnAddCmp.ActiveFillColor = System.Drawing.Color.DarkOrange;
            this.btnAddCmp.ActiveForecolor = System.Drawing.Color.White;
            this.btnAddCmp.ActiveLineColor = System.Drawing.Color.DarkOrange;
            this.btnAddCmp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddCmp.BackColor = System.Drawing.Color.White;
            this.btnAddCmp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddCmp.BackgroundImage")));
            this.btnAddCmp.ButtonText = "Add";
            this.btnAddCmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCmp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCmp.ForeColor = System.Drawing.Color.Black;
            this.btnAddCmp.IdleBorderThickness = 1;
            this.btnAddCmp.IdleCornerRadius = 20;
            this.btnAddCmp.IdleFillColor = System.Drawing.Color.White;
            this.btnAddCmp.IdleForecolor = System.Drawing.Color.Black;
            this.btnAddCmp.IdleLineColor = System.Drawing.Color.Black;
            this.btnAddCmp.Location = new System.Drawing.Point(483, 400);
            this.btnAddCmp.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddCmp.Name = "btnAddCmp";
            this.btnAddCmp.Size = new System.Drawing.Size(147, 43);
            this.btnAddCmp.TabIndex = 1110;
            this.btnAddCmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddCmp.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btn_cmp_liscence
            // 
            this.btn_cmp_liscence.Image = ((System.Drawing.Image)(resources.GetObject("btn_cmp_liscence.Image")));
            this.btn_cmp_liscence.Location = new System.Drawing.Point(535, 314);
            this.btn_cmp_liscence.Name = "btn_cmp_liscence";
            this.btn_cmp_liscence.Size = new System.Drawing.Size(33, 32);
            this.btn_cmp_liscence.TabIndex = 1111;
            this.btn_cmp_liscence.UseVisualStyleBackColor = true;
            this.btn_cmp_liscence.Click += new System.EventHandler(this.btn_cmp_liscence_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 17);
            this.label4.TabIndex = 1112;
            this.label4.Text = "Liscence Expiry Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 371);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(378, 20);
            this.dateTimePicker1.TabIndex = 1113;
            // 
            // AddCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(658, 464);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_cmp_liscence);
            this.Controls.Add(this.btnAddCmp);
            this.Controls.Add(this.txtCmpAddress);
            this.Controls.Add(this.txtCmpEmail);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCmpName);
            this.Controls.Add(this.txtCmpLiscence);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.Header_Email);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Company";
            this.Load += new System.EventHandler(this.FormEmailEdit_Load);
            this.Header_Email.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.bunifuGradientPanel2.ResumeLayout(false);
            this.bunifuGradientPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuGradientPanel Header_Email;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Bunifu.Framework.UI.BunifuTileButton bunifuTileButton1;
        private Bunifu.Framework.UI.BunifuTileButton pictureBox6;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtCmpAddress;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCmpEmail;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPhoneNo;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCmpName;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCmpLiscence;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddCmp;
        public System.Windows.Forms.Button btn_cmp_liscence;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
    }
}