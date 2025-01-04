namespace customerServiceSoftware
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnArchives = new Bunifu.Framework.UI.BunifuTileButton();
            this.btnCases = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_Close_Home = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.DimGray;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.btnArchives);
            this.bunifuGradientPanel1.Controls.Add(this.btnCases);
            this.bunifuGradientPanel1.Controls.Add(this.btn_Close_Home);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.DimGray;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DarkOrange;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.DarkSlateGray;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.DimGray;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(518, 331);
            this.bunifuGradientPanel1.TabIndex = 36;
            // 
            // btnArchives
            // 
            this.btnArchives.BackColor = System.Drawing.Color.Transparent;
            this.btnArchives.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnArchives.color = System.Drawing.Color.Transparent;
            this.btnArchives.colorActive = System.Drawing.Color.DarkOrange;
            this.btnArchives.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchives.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnArchives.ForeColor = System.Drawing.Color.Black;
            this.btnArchives.Image = global::customerServiceSoftware.Properties.Resources.archive_icon_new;
            this.btnArchives.ImagePosition = 20;
            this.btnArchives.ImageZoom = 50;
            this.btnArchives.LabelPosition = 41;
            this.btnArchives.LabelText = "Archive";
            this.btnArchives.Location = new System.Drawing.Point(258, 86);
            this.btnArchives.Margin = new System.Windows.Forms.Padding(6);
            this.btnArchives.Name = "btnArchives";
            this.btnArchives.Size = new System.Drawing.Size(127, 117);
            this.btnArchives.TabIndex = 37;
            this.btnArchives.Click += new System.EventHandler(this.btnArchives_Click);
            // 
            // btnCases
            // 
            this.btnCases.BackColor = System.Drawing.Color.Transparent;
            this.btnCases.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCases.color = System.Drawing.Color.Transparent;
            this.btnCases.colorActive = System.Drawing.Color.DarkOrange;
            this.btnCases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCases.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.btnCases.ForeColor = System.Drawing.Color.Black;
            this.btnCases.Image = global::customerServiceSoftware.Properties.Resources.icon_cases;
            this.btnCases.ImagePosition = 20;
            this.btnCases.ImageZoom = 50;
            this.btnCases.LabelPosition = 41;
            this.btnCases.LabelText = "Cases";
            this.btnCases.Location = new System.Drawing.Point(119, 86);
            this.btnCases.Margin = new System.Windows.Forms.Padding(6);
            this.btnCases.Name = "btnCases";
            this.btnCases.Size = new System.Drawing.Size(127, 117);
            this.btnCases.TabIndex = 36;
            this.btnCases.Click += new System.EventHandler(this.btnCases_Click);
            // 
            // btn_Close_Home
            // 
            this.btn_Close_Home.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Close_Home.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close_Home.color = System.Drawing.Color.Transparent;
            this.btn_Close_Home.colorActive = System.Drawing.Color.OrangeRed;
            this.btn_Close_Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close_Home.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close_Home.ForeColor = System.Drawing.Color.Black;
            this.btn_Close_Home.Image = null;
            this.btn_Close_Home.ImagePosition = 19;
            this.btn_Close_Home.ImageZoom = 50;
            this.btn_Close_Home.LabelPosition = 28;
            this.btn_Close_Home.LabelText = " Close";
            this.btn_Close_Home.Location = new System.Drawing.Point(458, 0);
            this.btn_Close_Home.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Close_Home.Name = "btn_Close_Home";
            this.btn_Close_Home.Size = new System.Drawing.Size(58, 31);
            this.btn_Close_Home.TabIndex = 35;
            this.btn_Close_Home.Click += new System.EventHandler(this.btn_Close_Home_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(518, 331);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuTileButton btn_Close_Home;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuTileButton btnCases;
        private Bunifu.Framework.UI.BunifuTileButton btnArchives;
    }
}