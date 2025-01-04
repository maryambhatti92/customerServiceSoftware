using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using css.Data.Models;


namespace customerServiceSoftware
{
    public partial class SplashScreen : Form

    {
        Timer tmr;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void btn_Close_Home_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();

            //set time interval 3 sec

            tmr.Interval = 3000;

            //starts the timer
            string status = AppConfigReader.CompanyConfigurationStatus;
            if (status == "0")
            {
                string companId = AppConfigReader.CompanyId;
                string companyName = AppConfigReader.CompanyName;
                string companyLiscense = AppConfigReader.CompanyLiscense;

               tbl_Company companyData = TabClasses.CompanyOperations.LoadCompanyDataViaId(Convert.ToInt32(companId));

                if (companyData != null)
                {
                    if( companyData.Liscense == companyLiscense)
                    {                        
                        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                        config.AppSettings.Settings.Remove("COMPCONFIGURATION");
                        config.AppSettings.Settings.Add("COMPCONFIGURATION", "1");
                        config.Save(ConfigurationSaveMode.Minimal);
                    }
                    else
                    {
                        MessageBox.Show("Company Liscense not matched. Contact Sequware Ownership.");
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("Company Configuration failed. Reinstall application with correct company details and lisence");
                    Application.Exit();
                }

            }

            tmr.Start();
            
            tmr.Tick += tmr_Tick;
        }

        void tmr_Tick(object sender, EventArgs e)

        {

            //after 10 sec stop the timer

            tmr.Stop();

            //display mainform

            sequware_login mf = new sequware_login();

            mf.Show();

            //hide this form

            this.Hide();

        }

       
    }
}
